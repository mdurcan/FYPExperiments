namespace CircleDetection_withVideoFile
{
    partial class Form1
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
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.tlpImages = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrginal = new System.Windows.Forms.Label();
            this.lblGray = new System.Windows.Forms.Label();
            this.lblCircles = new System.Windows.Forms.Label();
            this.ibOrginal = new Emgu.CV.UI.ImageBox();
            this.ibGray = new Emgu.CV.UI.ImageBox();
            this.ibCircles = new Emgu.CV.UI.ImageBox();
            this.chkbCirclesOnOrginal = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tlpImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibOrginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibCircles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(452, 12);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(74, 22);
            this.btnPlayPause.TabIndex = 2;
            this.btnPlayPause.Text = "Play";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // tlpImages
            // 
            this.tlpImages.ColumnCount = 3;
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpImages.Controls.Add(this.lblOrginal, 0, 0);
            this.tlpImages.Controls.Add(this.lblGray, 1, 0);
            this.tlpImages.Controls.Add(this.lblCircles, 2, 0);
            this.tlpImages.Controls.Add(this.ibOrginal, 0, 1);
            this.tlpImages.Controls.Add(this.ibGray, 1, 1);
            this.tlpImages.Controls.Add(this.ibCircles, 2, 1);
            this.tlpImages.Location = new System.Drawing.Point(12, 46);
            this.tlpImages.Name = "tlpImages";
            this.tlpImages.RowCount = 2;
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImages.Size = new System.Drawing.Size(961, 343);
            this.tlpImages.TabIndex = 3;
            // 
            // lblOrginal
            // 
            this.lblOrginal.AutoSize = true;
            this.lblOrginal.Location = new System.Drawing.Point(3, 0);
            this.lblOrginal.Name = "lblOrginal";
            this.lblOrginal.Size = new System.Drawing.Size(43, 13);
            this.lblOrginal.TabIndex = 0;
            this.lblOrginal.Text = "Orginal ";
            // 
            // lblGray
            // 
            this.lblGray.AutoSize = true;
            this.lblGray.Location = new System.Drawing.Point(323, 0);
            this.lblGray.Name = "lblGray";
            this.lblGray.Size = new System.Drawing.Size(29, 13);
            this.lblGray.TabIndex = 1;
            this.lblGray.Text = "Gray";
            // 
            // lblCircles
            // 
            this.lblCircles.AutoSize = true;
            this.lblCircles.Location = new System.Drawing.Point(643, 0);
            this.lblCircles.Name = "lblCircles";
            this.lblCircles.Size = new System.Drawing.Size(38, 13);
            this.lblCircles.TabIndex = 2;
            this.lblCircles.Text = "Circles";
            // 
            // ibOrginal
            // 
            this.ibOrginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOrginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibOrginal.Enabled = false;
            this.ibOrginal.Location = new System.Drawing.Point(3, 16);
            this.ibOrginal.Name = "ibOrginal";
            this.ibOrginal.Size = new System.Drawing.Size(314, 324);
            this.ibOrginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibOrginal.TabIndex = 2;
            this.ibOrginal.TabStop = false;
            // 
            // ibGray
            // 
            this.ibGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibGray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibGray.Enabled = false;
            this.ibGray.Location = new System.Drawing.Point(323, 16);
            this.ibGray.Name = "ibGray";
            this.ibGray.Size = new System.Drawing.Size(314, 324);
            this.ibGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibGray.TabIndex = 2;
            this.ibGray.TabStop = false;
            // 
            // ibCircles
            // 
            this.ibCircles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibCircles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibCircles.Enabled = false;
            this.ibCircles.Location = new System.Drawing.Point(643, 16);
            this.ibCircles.Name = "ibCircles";
            this.ibCircles.Size = new System.Drawing.Size(315, 324);
            this.ibCircles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibCircles.TabIndex = 2;
            this.ibCircles.TabStop = false;
            // 
            // chkbCirclesOnOrginal
            // 
            this.chkbCirclesOnOrginal.AutoSize = true;
            this.chkbCirclesOnOrginal.Location = new System.Drawing.Point(553, 14);
            this.chkbCirclesOnOrginal.Name = "chkbCirclesOnOrginal";
            this.chkbCirclesOnOrginal.Size = new System.Drawing.Size(138, 17);
            this.chkbCirclesOnOrginal.TabIndex = 4;
            this.chkbCirclesOnOrginal.Text = "place circles on orginak";
            this.chkbCirclesOnOrginal.UseVisualStyleBackColor = true;
            this.chkbCirclesOnOrginal.CheckedChanged += new System.EventHandler(this.chkbCirclesOnOrginal_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 401);
            this.Controls.Add(this.chkbCirclesOnOrginal);
            this.Controls.Add(this.tlpImages);
            this.Controls.Add(this.btnPlayPause);
            this.Name = "Form1";
            this.Text = "Circle Detection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tlpImages.ResumeLayout(false);
            this.tlpImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibOrginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibCircles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.TableLayoutPanel tlpImages;
        private System.Windows.Forms.Label lblOrginal;
        private System.Windows.Forms.Label lblGray;
        private System.Windows.Forms.Label lblCircles;
        private Emgu.CV.UI.ImageBox ibOrginal;
        private Emgu.CV.UI.ImageBox ibGray;
        private Emgu.CV.UI.ImageBox ibCircles;
        private System.Windows.Forms.CheckBox chkbCirclesOnOrginal;
        private System.Windows.Forms.Timer timer1;
    }
}

