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
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace BackgroundSubtraction
{
    public partial class Win : Form
    {
        //vairables////////////////////////////////////////////////////////////
        //images to display and locate moving objects
        private Image<Bgr, byte> currentFrame;
        private Image<Gray, byte> currentFrameGray;
        private Image<Gray, byte> backgroundFrame;
        private Image<Gray, byte> perviousFrame;
        private Image<Gray, byte> differenceFrame;
        private Image<Gray, byte> oblectImage;
        //needed to get frames
        private Capture capture=null;
        private string file;
        //check for end of video
        private int TotalFrame = 0;
        private int FrameNum = 0;

        public Win()
        {
            InitializeComponent();
        }

        //button to find and load new video
        private void SearchFile_button_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                capture.Dispose();
                currentFrame = null;
                backgroundFrame = null;
                differenceFrame = null;
                perviousFrame = null;
                FrameNum = 0;
            }

            //file explorer to get video file
            OpenFileDialog choosefile =new OpenFileDialog();
            choosefile.Filter = @"Media Files| * .mpg;* .avi;* .wma;* .mov;* .wav;* .mp3;* .mp4;* .wmv | All Files | *.*";
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
            TotalFrame = (int) capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            TotalFrame_text.Text = TotalFrame.ToString();
            // current frame
            CurrentFrame_Text.Text = FrameNum.ToString();
        }

        private void NextFrame_button_Click(object sender, EventArgs e)
        {
            //check if at end of file
            if (FrameNum > TotalFrame)
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
            
        }
    }
}
