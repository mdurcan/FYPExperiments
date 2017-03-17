using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackgroundSubtraction;
using Emgu.CV;
using Emgu.CV.Structure;

namespace BenchDemo
{
    public partial class BackGroundSubtractionDemo : Form
    {
        //vairables///
        //images to display and locate moving objects
        private Image<Bgr, byte> currentFrame;
        private Image<Gray, byte> currentFrameGray;
        private Image<Gray, byte> backgroundFrame;
        private Image<Gray, byte> differenceFrame;
        //needed to get frames
        private Capture capture = null;
        private string file;
        //check for end of video
        private int TotalFrame = 0;
        private int FrameNum = 0;
        // tracking objects
        private List<TrackedObject> trackedObjects;
        //play pause
        private bool play = false;


        public BackGroundSubtractionDemo()
        {
            InitializeComponent();
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                //reset frames
                capture.Dispose();
                currentFrame = null;
                backgroundFrame = null;
                differenceFrame = null;
                //stop the process
                Application.Idle -= playing;
                //pause
                play = false;
                Pause_Play_btn.Text = "Play";
            }

            FrameNum = 0;
            // reset tracking
            trackedObjects = new List<TrackedObject>();


            //file explorer to get video file
            OpenFileDialog choosefile = new OpenFileDialog();
            choosefile.Filter = @"Media Files| * .mpg;* .avi;* .wma;* .MOV;* .wav;* .mp3;* .mp4;* .wmv | All Files | *.*";
            choosefile.Multiselect = false;

            if (choosefile.ShowDialog() == DialogResult.OK)
            {
                file = @choosefile.FileName;
            }

            //set Capture 
            capture = new Capture(file);

            // set total frames
             TotalFrame = (int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);

            //set size of images
            int height = capture.Height / 4;
            int width = capture.Width / 4;
            Image_box.Size=new Size(width,height);
            BS_Image_box.Size = new Size(width, height);

            //enable play
            Pause_Play_btn.Enabled = true;
            restart_btn.Enabled = true;
        }

        private void Pause_Play_btn_Click(object sender, EventArgs e)
        {
            if (play)
            {
                //stop the process
                Application.Idle -= playing;

                //pause
                play = false;
                Pause_Play_btn.Text = "Play";
            }
            else
            {
                //start process
                Application.Idle += playing;

                //play
                play = true;
                Pause_Play_btn.Text = "Pause";
            }
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            // play
            play = true;
            Pause_Play_btn.Text = "Pause";
            Pause_Play_btn.Enabled = true;
            Application.Idle += playing;

            // reset tracking
            trackedObjects = new List<TrackedObject>();

            //restart capture
            capture.Dispose();
            capture = new Capture(file);

            //reseting frame count
            FrameNum = 0;
        }

        private void playing(object sender, EventArgs e)
        {
            //if at end of video
            if (FrameNum == TotalFrame-1)
            {
                //reset button
                play = false;
                Pause_Play_btn.Text = "Play";
                Pause_Play_btn.Enabled = false;
                //stop process
                Application.Idle -= playing;
                return;
            }
            FrameNum++;

            Process();

            //delay
            Thread.Sleep(1000);
        }

        private void Process()
        {
            // set background
            if (backgroundFrame == null)
            {
                // sets the first frame as background
                Image<Bgr, byte> image = (capture.QueryFrame()).ToImage<Bgr, byte>();
                Image_box.Image = image;
                backgroundFrame = image.Convert<Gray, byte>();
            }

            // get the current frame
            currentFrame = (capture.QueryFrame()).ToImage<Bgr, byte>();
            currentFrameGray = currentFrame.Convert<Gray, byte>();
            currentFrameGray = currentFrameGray.SmoothGaussian(7);

            // get Difference
            differenceFrame = backgroundFrame.AbsDiff(currentFrameGray);
            differenceFrame = differenceFrame.SmoothGaussian(7);
            differenceFrame = differenceFrame.ThresholdBinary(new Gray(50), new Gray(255));

            //call the find object function
            List<CircleF> objects = GetMovingObjects();

            // determine if moving objects are what is already being tracked or something new to track
            DetermineTrackedObjects(objects);

            //Check if the tracked object has been updated, if not delete
            CleanTrackedObjects();

            //display the tracked objects
            DisplayTrackedObjects();

            //display
            Image_box.Image = currentFrame;
            BS_Image_box.Image = differenceFrame;
        }

        private List<CircleF> GetMovingObjects()
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

            //create list of circles to return 
            List<CircleF> detectedObjects = new List<CircleF>();
            foreach (CircleF circle in circles)
            {
                detectedObjects.Add(circle);
            }

            return detectedObjects;
        }


        //Determine the moving objects, if they are already being tracked
        private void DetermineTrackedObjects(List<CircleF> detections)
        {
            //if no tracked objects excist start tracking all
            if (trackedObjects.Count == 0)
            {
                foreach (CircleF objects in detections)
                {
                    trackedObjects.Add(new TrackedObject(objects));
                }
            }
            else
            {
                foreach (CircleF detectedObject in detections)
                {
                    bool NewTrackedObject = true;
                    //first compares to all tracked objects
                    foreach (TrackedObject tracked in trackedObjects)
                    {
                        // check similarty, to see if same object being tracked
                        if (CheckSimilarity(detectedObject, tracked.getLastCircle()) && !tracked.CheckIfUpdated())
                        {
                            //adds to the tracked object new detection
                            tracked.AddNewDetection(detectedObject);
                            tracked.Update(true);
                            NewTrackedObject = false;
                        }
                    }
                    //if not new detection of an object it creates a new tracked object
                    if (NewTrackedObject)
                    {
                        trackedObjects.Add(new TrackedObject(detectedObject));
                    }
                }
            }
        }


        // Check tracked objects delete inactive
        private void CleanTrackedObjects()
        {
            if (trackedObjects.Count == 1) return;

            //goes through tracked objects a deletes unpdated 
            for (int i = 0; i < trackedObjects.Count; i++)
            {
                if (!trackedObjects[i].CheckIfUpdated() && trackedObjects[i].GetPath().Count ==1)
                {
                    trackedObjects.RemoveAt(i);
                }
                else
                {
                    trackedObjects[i].Update(false);
                }
            }
        }

        // checks if points are close
        private bool CheckSimilarity(CircleF firstObject, CircleF secoundObject)
        {
            // variables for checking similarity
            double firstRaduis = firstObject.Radius;
            double secoundRaduis = secoundObject.Radius;
            double averageRaduis = (firstRaduis + secoundRaduis) / 2;
            double xDistance = Math.Abs(Math.Abs(firstObject.Center.X) - Math.Abs(secoundObject.Center.X));
            double yDistance = Math.Abs(Math.Abs(firstObject.Center.Y) - Math.Abs(secoundObject.Center.Y));
            //distance from each other
            double distanceApart = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));

            //check if close to each other
            if (distanceApart < averageRaduis*1.5)
            {
                return true;
            }
            return false;
        }


        // display the tracked objects and there location
        private void DisplayTrackedObjects()
        {
           foreach (TrackedObject tracked in trackedObjects)
            {

                //draw last circle and centre
                currentFrame.Draw(tracked.getLastCircle(), new Bgr(Color.Red), 4);
                currentFrame.Draw(new CircleF(tracked.getLastCircle().Center, 1), new Bgr(Color.Red), 4);

                //draw path
                List<PointF> path = tracked.GetPath();
                // if path length 1 no need to plot
                if (path.Count == 1) continue;
                // gets first point
                PointF pointA = path[0];
                //plots all pointd
                foreach (PointF pointB in path)
                {
                    LineSegment2DF line = new LineSegment2DF(pointA, pointB);
                    currentFrame.Draw(line, new Bgr(Color.Red), 2);
                    pointA = pointB;
                }

                tracked.Update(false);
            }
        }
    }
}
