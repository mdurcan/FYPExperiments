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
            this.Image = new Emgu.CV.UI.ImageBox();
            this.GetFile = new System.Windows.Forms.Button();
            this.NextFrame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Image
            // 
            this.Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image.Location = new System.Drawing.Point(12, 66);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(797, 617);
            this.Image.TabIndex = 2;
            this.Image.TabStop = false;
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
            this.NextFrame.Location = new System.Drawing.Point(209, 13);
            this.NextFrame.Name = "NextFrame";
            this.NextFrame.Size = new System.Drawing.Size(85, 35);
            this.NextFrame.TabIndex = 4;
            this.NextFrame.Text = "next Frame";
            this.NextFrame.UseVisualStyleBackColor = true;
            this.NextFrame.Click += new System.EventHandler(this.NextFrame_Click);
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 695);
            this.Controls.Add(this.NextFrame);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.Image);
            this.Name = "Draw";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox Image;
        private System.Windows.Forms.Button GetFile;
        private System.Windows.Forms.Button NextFrame;
    }
}

