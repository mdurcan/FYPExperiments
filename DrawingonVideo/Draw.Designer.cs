using System.Windows.Forms;

namespace DrawingonVideo
{
    partial class Draw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GetFile = new System.Windows.Forms.Button();
            this.NextFrame = new System.Windows.Forms.Button();
            this.XY_Co = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Image = new Emgu.CV.UI.ImageBox();
            this.ResetFrame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(57, 13);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(98, 35);
            this.GetFile.TabIndex = 3;
            this.GetFile.Text = "File";
            this.GetFile.UseVisualStyleBackColor = true;
            this.GetFile.Click += new System.EventHandler(this.GetFile_Click);
            // 
            // NextFrame
            // 
            this.NextFrame.Enabled = false;
            this.NextFrame.Location = new System.Drawing.Point(209, 13);
            this.NextFrame.Name = "NextFrame";
            this.NextFrame.Size = new System.Drawing.Size(85, 35);
            this.NextFrame.TabIndex = 4;
            this.NextFrame.Text = "next Frame";
            this.NextFrame.UseVisualStyleBackColor = true;
            this.NextFrame.Click += new System.EventHandler(this.NextFrame_Click);
            // 
            // XY_Co
            // 
            this.XY_Co.Location = new System.Drawing.Point(416, 12);
            this.XY_Co.Name = "XY_Co";
            this.XY_Co.Size = new System.Drawing.Size(100, 20);
            this.XY_Co.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "co-ordinates";
            // 
            // Image
            // 
            this.Image.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image.Cursor = System.Windows.Forms.Cursors.Default;
            this.Image.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.Image.Location = new System.Drawing.Point(12, 66);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(1000, 600);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image.TabIndex = 2;
            this.Image.TabStop = false;
            this.Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Image_MouseClick);
            this.Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Image_MouseMove);
            this.Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);
            // 
            // ResetFrame
            // 
            this.ResetFrame.Location = new System.Drawing.Point(858, 18);
            this.ResetFrame.Name = "ResetFrame";
            this.ResetFrame.Size = new System.Drawing.Size(106, 30);
            this.ResetFrame.TabIndex = 9;
            this.ResetFrame.Text = "Reset Frame";
            this.ResetFrame.UseVisualStyleBackColor = true;
            this.ResetFrame.Click += new System.EventHandler(this.ResetFrame_Click);
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 691);
            this.Controls.Add(this.ResetFrame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XY_Co);
            this.Controls.Add(this.NextFrame);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.Image);
            this.Name = "Draw";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GetFile;
        private System.Windows.Forms.Button NextFrame;
        private System.Windows.Forms.TextBox XY_Co;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox Image;
        private Button ResetFrame;
    }
}

