using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DrawingonVideo
{
    public partial class Draw : Form
    {
        //variables
        private Image<Bgr, byte> currentFrame;
        private Image<Bgr, byte> newFrame;
        //needed to get frames
        private Capture capture = null;
        private string file;
        //check for end of video
        private int TotalFrame = 0;
        private int FrameNum = 0;
        //drawing square
        private Point upperRCorner;
        private Point lowerLCorner;
        private Point centre;
        private bool centreSelected=false;
        private bool drawing = false;
        private bool boxDrawn = false;
        //Create videos
        private VideoWriter videoWriter;
        private string Filepath;
        private bool setup = true;

        public Draw()
        {
            InitializeComponent();
            
        }


        private void GetFile_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                FrameNum = 0;
            }
            //file explorer to get video file
            OpenFileDialog choosefile = new OpenFileDialog();
            choosefile.Filter = @"Media Files| * .mpg;* .avi;* .wma;* .mov;* .wav;* .mp3;* .mp4;* .wmv | All Files | *.*";
            choosefile.Multiselect = false;

            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                file = @choosefile.FileName;
            }
            //enable next frame
            NextFrame.Enabled = true;

            //set Capture and enable play
            capture = new Capture(file);
            TotalFrame = (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
        }
 

        private void NextFrame_Click(object sender, EventArgs e)
        {
            //sets up for first frame
            if (setup)
            {
                videoWriter = new VideoWriter(@"C:\Users\Martin\Documents\4th_year\FYP\testData\ATestCompare1.avi",
                    VideoWriter.Fourcc('M', 'S', 'V', 'C'),
                    (int) capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps),
                    new Size(capture.Width, capture.Height),
                    true);

                setup = false;
            }
            else
            {
                videoWriter.Write(newFrame.Mat);
            }

            //check if at end of file
            if (FrameNum >= TotalFrame)
            {
                NextFrame.Enabled = false;
               
                return;
            }
            centreSelected = false;
            boxDrawn = false; 
            FrameNum++;
            //get current frame
            currentFrame= (capture.QueryFrame()).ToImage<Bgr, byte>();
            //get difference in size
            Image.Width = currentFrame.Width/2;
            Image.Height = currentFrame.Height/2;

            //set
            Image.Image = currentFrame;

            //create new franme
            newFrame = currentFrame.Clone();
        }

        //get centre
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            if (!centreSelected)
            {
                //centre of object
                centre = new Point(e.X * 2, e.Y *2);
                //draws dot
                CircleF circle = new CircleF(centre, 1);
                newFrame.Draw(circle, new Bgr(Color.Blue), 6);
                Image.Image = newFrame;
                //lets the box to be drawn
                centreSelected = true;
            }
        }

        //draw border box
        
        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (centreSelected && !boxDrawn)
            {
                // get upper corner of box
                upperRCorner = new Point(e.X*2,e.Y*2);
                //enables drawing
                drawing = true;
            }
        }

        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                //get bottom corner
                lowerLCorner = new Point(e.X * 2, e.Y * 2);

                //draw box on new frame
                Rectangle box = new Rectangle(upperRCorner.X, upperRCorner.Y, (lowerLCorner.X - upperRCorner.X),
                    (lowerLCorner.Y - upperRCorner.Y));
                newFrame.Draw(box, new Bgr(Color.Blue), 3);
                Image.Image = newFrame;
                drawing = false;
                boxDrawn = true;
            }
        }

        // show xy cordinates
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            XY_Co.Text = $"X: {e.X}; Y: {e.Y}";
        }

        //reset frame
        private void ResetFrame_Click(object sender, EventArgs e)
        {
            newFrame = currentFrame.Clone();
            Image.Image = newFrame;
            boxDrawn = false;
            centreSelected = false;
        }
    }
}
