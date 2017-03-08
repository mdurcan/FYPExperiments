﻿using System;
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

namespace BackgroundSubtration
{
    public partial class BackgroundSubtraction : Form
    {
        //vairables////////////////////////////////////////////////////////////
        //images to display and locate moving objects
        private Image<Bgr, byte> currentFrame;
        private Image<Gray, byte> currentFrameGray;
        private Image<Gray, byte> backgroundFrame;
        private Image<Gray, byte> differenceFrame;
        private Image<Bgr, byte> objectImage;
        //needed to get frames
        private Capture capture = null;
        private string file;
        //check for end of video
        private int TotalFrame = 0;
        private int FrameNum = 0;
        // starting application
        private bool waitaframe = false;
        // tracking objects
        private List<TrackedObject> trackedObjects;

        public BackgroundSubtraction()
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
                FrameNum = 0;
            }

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
            differenceFrame = differenceFrame.SmoothGaussian(7);
            differenceFrame = differenceFrame.ThresholdBinary(new Gray(50), new Gray(255));

            //call the find object function
            List<CircleF> objects = GetMovingObjects();

            // determine if moving objects are what is already being tracked or something new to track
            DetermineTrackedObjects(objects);

            //display the tracked objects
            DisplayTrackedObjects();

            //display
            CurrentFrame_Image.Image = currentFrame;
            DifferenceFrame_Image.Image = differenceFrame;
            Object_Image.Image = objectImage;


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

            //for now draw all circles, and create list of circles to return 
            objectImage = currentFrame;
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
                        if (CheckSimilarity(detectedObject, tracked.getLastCircle()))
                        {
                            //adds to the tracked object new detection
                            tracked.AddNewDetection(detectedObject);
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

        // checks if points are close
        private bool CheckSimilarity(CircleF firstObject, CircleF secoundObject)
        {
            // variables for checking similarity
            double firstRaduis = firstObject.Radius;
            double secoundRaduis = secoundObject.Radius;
            double averageRaduis = (firstRaduis + secoundRaduis)/2;
            double xDistance = Math.Abs(Math.Abs(firstObject.Center.X) - Math.Abs(secoundObject.Center.X));
            double yDistance = Math.Abs(Math.Abs(firstObject.Center.Y) - Math.Abs(secoundObject.Center.Y));
            //distance from each other
            double distanceApart = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));

            //check if close to each other
            if (distanceApart < averageRaduis)
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
                objectImage.Draw(tracked.getLastCircle(), new Bgr(Color.Red), 4);
                objectImage.Draw(new CircleF(tracked.getLastCircle().Center,1), new Bgr(Color.Red), 4);
                //draw path
                List<PointF> path = tracked.GetPath();
                // if path length 1 no need to plot
                if (path.Count == 1) return;
                // gets first point
                PointF pointA = path[0];
                //plots all pointd
                foreach (PointF pointB in path)
                {
                    LineSegment2DF line = new LineSegment2DF(pointA,pointB);
                    objectImage.Draw(line,new Bgr(Color.Red), 2);
                    pointA = pointB;
                }
            }
        }


        // shows where the mouse is over in the image
        private void Object_Image_MouseMove(object sender, MouseEventArgs e)
        {
            XYCo.Text = $"X: {e.X}; Y: {e.Y}";
        }
    }
}
