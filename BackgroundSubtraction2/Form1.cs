using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackgroundSubtraction;
using Emgu.CV;
using Emgu.CV.Structure;

namespace BackgroundSubtraction2
{
    public partial class Form1 : Form
    {//vairables////////////////////////////////////////////////////////////
        //images to display and locate moving objects
        private Image<Bgr, byte> currentFrame;
        private Image<Gray, byte> currentFrameGray;
        private Image<Gray, byte> backgroundFrame;
        private Image<Gray, byte> perviousFrame;
        private Image<Gray, byte> perviousFrame2;
        private Image<Gray, byte> differenceFrame;
        private Image<Gray, byte> pastDifferenceFrame;
        private Image<Gray, byte> totalDifferenceFrame;
        private Image<Bgr, byte> objectImage;
        //needed to get frames
        private Capture capture = null;
        private string file;
        //check for end of video
        private int TotalFrame = 0;
        private int FrameNum = 0;
        //
        private bool waitaframe = false;
        //tracking objects


        public Form1()
        {
            InitializeComponent();
        }

        //button to find and load new video
        private void SearchFile_button_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                //reset frames
                capture.Dispose();
                currentFrame = null;
                backgroundFrame = null;
                differenceFrame = null;
                perviousFrame = null;
                FrameNum = 0;
                //reset tracking
                pastDifferenceFrame = null;

            }

            //file explorer to get video file
            OpenFileDialog choosefile = new OpenFileDialog();
            choosefile.Filter = @"Media Files| * .mpg;* .avi;* .wma;* .MOV;* .wav;* .mp3;* .mp4;* .wmv | All Files | *.*";
            choosefile.Multiselect = false;

            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                file = @choosefile.FileName;
            }

            //set Capture and enable play
            capture = new Capture(file);
            NextFrame_button.Enabled = true;
            FilePath.Text = file;
            //get and display total frames
            TotalFrame = (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            TotalFrame_text.Text = TotalFrame.ToString();
            // current frame
            CurrentFrame_Text.Text = FrameNum.ToString();
        }

        private void NextFrame_button_Click(object sender, EventArgs e)
        {
            //check if at end of file
            if (FrameNum >= TotalFrame)
            {
                NextFrame_button.Enabled = false;
                return;
            }
            FrameNum++;
            CurrentFrame_Text.Text = FrameNum.ToString();

            //call  Detection and display, to show video and detect object
            DetectionAndDisplay();
        }


        private void DetectionAndDisplay()
        {
            // set background
            if (backgroundFrame == null)
            {
                Image<Bgr, byte> image = (capture.QueryFrame()).ToImage<Bgr, byte>();
                CurrentFrame_Image.Image = image;
                backgroundFrame = image.Convert<Gray, byte>();
                BackgroundFrame_Image.Image = backgroundFrame;
                return;
            }

            // get the current frame
            currentFrame = (capture.QueryFrame()).ToImage<Bgr, byte>();
            currentFrameGray = currentFrame.Convert<Gray, byte>();
            currentFrameGray = currentFrameGray.SmoothGaussian(7);

            // get Difference
            differenceFrame = backgroundFrame.AbsDiff(currentFrameGray);

            // differenceFrame = differenceFrame.SmoothGaussian(7);
            differenceFrame = differenceFrame.ThresholdBinary(new Gray(50), new Gray(255));

            // check difference from last one
            if (pastDifferenceFrame != null)
            {
                totalDifferenceFrame = pastDifferenceFrame.AbsDiff(differenceFrame);
            }
            pastDifferenceFrame = differenceFrame.Clone();

            //call the find object function
            List<DetectedObject> objects = GetMovingObjects();

            //for now draw all circles
            objectImage = currentFrame;
            foreach (DetectedObject circle in objects)
            {
                objectImage.Draw(circle.GetCircle(), new Bgr(Color.Red), 2);
            }

            //previous frame next background every 2 images
            if (perviousFrame == null)
            {
                perviousFrame = currentFrameGray;
                waitaframe = true;
                
            }
            else if (waitaframe)
            {
                perviousFrame2 = perviousFrame;
                perviousFrame = currentFrameGray;
                waitaframe = false;
            }
            else
            {
                backgroundFrame = perviousFrame2;
                BackgroundFrame_Image.Image = backgroundFrame;
                perviousFrame2 = perviousFrame;
                perviousFrame = currentFrameGray;
            }

            //display
            CurrentFrame_Image.Image = currentFrame;
            DifferenceFrame_Image.Image = totalDifferenceFrame;
            Object_Image.Image = objectImage;


        }

        private List<DetectedObject> GetMovingObjects()
        {
            double dblAccumRes = 2.0;   //resolution used to detect the centre of the cirlces
            double dblMinDistBetweenCircles = differenceFrame.Height / 4;   //min distance from detected centers of detected circles
            int intMinRaduis = 10;      // min raduis of circles
            int intMaxRaduis = differenceFrame.Height / 2;    // max raduis of circles

            //finds all circles
            CircleF[] circles =
                differenceFrame.HoughCircles(new Gray(100), new Gray(50),
                    dblAccumRes,
                    dblMinDistBetweenCircles, intMinRaduis, intMaxRaduis)[0];

            //creates list of detected circles
            List<DetectedObject> detectedObjects = new List<DetectedObject>();
            foreach (CircleF circle in circles)
            {
                detectedObjects.Add(new DetectedObject(circle));
            }

            return detectedObjects;
        }



        private void Object_Image_MouseMove(object sender, MouseEventArgs e)
        {
            XYCo.Text = $"X: {e.X}; Y: {e.Y}";
        }
    }
}
