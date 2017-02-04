using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;

namespace CircleDetection_withVideoFile
{
    public partial class Form1 : Form
    {
        // Variables /////////////////////////////////////
        private bool bInFilePlaying = false;
        private Capture capture = null;
        private Image<Bgr, byte> image;

        // images
        private Image<Bgr, byte> imgOrginal;
        private Image<Bgr, byte> imgSmoothed;
        private Image<Gray, byte> imgGray;
        private Image<Bgr, byte> imgCircles;
        private Image<Gray, byte> imgCanny;
        // trcking path
        private List<Point> centrePoints = new List<Point>();
        private Boolean startingPointFound = false;
        private int pointNum = 0;


        // Constructure ////////////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
        }

        // if button is pressed to play file //////////////////////////////
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                 capture = new Capture(@"C:\Users\Martin\Videos\Logitech Webcam\Video 1.wmv");
            }

            if (bInFilePlaying)
            {
                timer1.Enabled = false;
                bInFilePlaying = false;
                btnPlayPause.Text = "Play";
                Application.Idle -= ProcessFrameAndUpdateGui;
            }
            else
            {
                timer1.Enabled = true;
                bInFilePlaying = true;
                btnPlayPause.Text = "Pause";
                Application.Idle += ProcessFrameAndUpdateGui;
            }
        }

        // place cirles and path on orginal image //////////////////////////
        private void chkbCirclesOnOrginal_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        
        
        // ////////////////////////////////////////////////////// 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (capture.QueryFrame() != null)
            {
                image = (capture.QueryFrame()).ToImage<Bgr, byte>();
            }
            else
            {
                timer1.Enabled = false;
                bInFilePlaying = false;
                Application.Idle -= ProcessFrameAndUpdateGui;
                btnPlayPause.Text = "Play";
                capture = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        // process images /////////////////////////////////////////////////////////
        private void ProcessFrameAndUpdateGui(object sender, EventArgs arg)
        {
            imgOrginal = image;
            if (imgOrginal == null) return; //if not getting frame, bail


            //smoothing
            imgSmoothed = imgOrginal;
            imgSmoothed.PyrDown();
            imgSmoothed.PyrUp();
            imgSmoothed._SmoothGaussian(3);             // gaussian smooth, argument is the size of fliter window

            //Turn Gray
            imgGray = imgSmoothed.Convert<Gray, byte>();
            imgGray._SmoothGaussian(3);

            //Canny Threshold
            var grayCannyThreshold = 250.0; // used first all dection 
            var grayCirclesAccumThreshold = 100.0; // second canny threshold for circle detection more selective 

            // get circles
            imgCircles = imgOrginal.CopyBlank();

            double dblAccumRes = 2.0;   //resolution used to detect the centre of the cirlces
            double dblMinDistBetweenCircles = imgGray.Height / 4;   //min distance from detected centers of detected circles
            int intMinRaduis = 50;      // min raduis of circles
            int intMaxRaduis = 200;    // max raduis of circles

            CircleF[] circles =
                imgGray.HoughCircles(new Gray(grayCannyThreshold), new Gray(grayCirclesAccumThreshold),
                    dblAccumRes,
                    dblMinDistBetweenCircles, intMinRaduis, intMaxRaduis)[0];
            
            foreach (CircleF circle in circles)
            {
                imgCircles.Draw(circle, new Bgr(Color.Red), 2);
                if (chkbCirclesOnOrginal.Checked)
                {
                    imgOrginal.Draw(circle, new Bgr(Color.Red), 2);
                }

                Point point = new Point((int)circle.Center.X, (int)circle.Center.X);
                centrePoints.Add(point);
                pointNum++;
                //if (startingPointFound==false)
                //{
                //    centrePoints.Add( point);
                //    pointNum++;
                //    startingPointFound = true;
                //}else if ((new LineSegment2D(centrePoints[pointNum - 1], point).Length) < 10.0)
                //{
                //    centrePoints.Add(point);
                //    pointNum++;
                //}
            }

            int i;
            for (i = pointNum; i > 1; i--)
            {
                Point[] points = centrePoints.ToArray();
                LineSegment2D line = new LineSegment2D(points[i - 1], points[i - 2]);
                imgCircles.Draw(line, new Bgr(Color.Red), ((i / pointNum) * 2));
                if (chkbCirclesOnOrginal.Checked)
                {
                    imgOrginal.Draw(line, new Bgr(Color.Red), 2);
                }
            }

            imgCanny = imgGray.Canny(grayCannyThreshold, grayCirclesAccumThreshold);
            //output images
            ibOrginal.Image = imgGray; 
            ibGray.Image = imgCanny;
            ibCircles.Image = imgCircles;
        }
    }
}
