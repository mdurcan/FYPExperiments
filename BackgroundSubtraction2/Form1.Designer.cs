namespace BackgroundSubtraction2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentFrame_Image = new Emgu.CV.UI.ImageBox();
            this.BackgroundFrame_Image = new Emgu.CV.UI.ImageBox();
            this.DifferenceFrame_Image = new Emgu.CV.UI.ImageBox();
            this.Object_Image = new Emgu.CV.UI.ImageBox();
            this.SearchFile_button = new System.Windows.Forms.Button();
            this.NextFrame_button = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TotalFrame_text = new System.Windows.Forms.TextBox();
            this.FPS_text = new System.Windows.Forms.TextBox();
            this.CurrentFrame_Text = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.XYCo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentFrame_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundFrame_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DifferenceFrame_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Object_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CurrentFrame_Image, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BackgroundFrame_Image, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DifferenceFrame_Image, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Object_Image, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 318);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Frame";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(618, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Difference";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(925, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Object";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentFrame_Image
            // 
            this.CurrentFrame_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentFrame_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentFrame_Image.Location = new System.Drawing.Point(4, 21);
            this.CurrentFrame_Image.Name = "CurrentFrame_Image";
            this.CurrentFrame_Image.Size = new System.Drawing.Size(300, 293);
            this.CurrentFrame_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CurrentFrame_Image.TabIndex = 2;
            this.CurrentFrame_Image.TabStop = false;
            // 
            // BackgroundFrame_Image
            // 
            this.BackgroundFrame_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackgroundFrame_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundFrame_Image.Location = new System.Drawing.Point(311, 21);
            this.BackgroundFrame_Image.Name = "BackgroundFrame_Image";
            this.BackgroundFrame_Image.Size = new System.Drawing.Size(300, 293);
            this.BackgroundFrame_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackgroundFrame_Image.TabIndex = 2;
            this.BackgroundFrame_Image.TabStop = false;
            // 
            // DifferenceFrame_Image
            // 
            this.DifferenceFrame_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DifferenceFrame_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DifferenceFrame_Image.Location = new System.Drawing.Point(618, 21);
            this.DifferenceFrame_Image.Name = "DifferenceFrame_Image";
            this.DifferenceFrame_Image.Size = new System.Drawing.Size(300, 293);
            this.DifferenceFrame_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DifferenceFrame_Image.TabIndex = 2;
            this.DifferenceFrame_Image.TabStop = false;
            // 
            // Object_Image
            // 
            this.Object_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Object_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Object_Image.Location = new System.Drawing.Point(925, 21);
            this.Object_Image.Name = "Object_Image";
            this.Object_Image.Size = new System.Drawing.Size(302, 293);
            this.Object_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Object_Image.TabIndex = 2;
            this.Object_Image.TabStop = false;
            this.Object_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_Image_MouseMove);
            // 
            // SearchFile_button
            // 
            this.SearchFile_button.Location = new System.Drawing.Point(16, 12);
            this.SearchFile_button.Name = "SearchFile_button";
            this.SearchFile_button.Size = new System.Drawing.Size(107, 44);
            this.SearchFile_button.TabIndex = 1;
            this.SearchFile_button.Text = "Search File";
            this.SearchFile_button.UseVisualStyleBackColor = true;
            this.SearchFile_button.Click += new System.EventHandler(this.SearchFile_button_Click);
            // 
            // NextFrame_button
            // 
            this.NextFrame_button.Enabled = false;
            this.NextFrame_button.Location = new System.Drawing.Point(129, 12);
            this.NextFrame_button.Name = "NextFrame_button";
            this.NextFrame_button.Size = new System.Drawing.Size(110, 44);
            this.NextFrame_button.TabIndex = 2;
            this.NextFrame_button.Text = "next frame";
            this.NextFrame_button.UseVisualStyleBackColor = true;
            this.NextFrame_button.Click += new System.EventHandler(this.NextFrame_button_Click);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(261, 18);
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Size = new System.Drawing.Size(365, 20);
            this.FilePath.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(772, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Frames";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(775, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "FPS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(775, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Current Frame";
            // 
            // TotalFrame_text
            // 
            this.TotalFrame_text.Location = new System.Drawing.Point(865, 12);
            this.TotalFrame_text.Name = "TotalFrame_text";
            this.TotalFrame_text.ReadOnly = true;
            this.TotalFrame_text.Size = new System.Drawing.Size(100, 20);
            this.TotalFrame_text.TabIndex = 7;
            // 
            // FPS_text
            // 
            this.FPS_text.Location = new System.Drawing.Point(865, 36);
            this.FPS_text.Name = "FPS_text";
            this.FPS_text.ReadOnly = true;
            this.FPS_text.Size = new System.Drawing.Size(100, 20);
            this.FPS_text.TabIndex = 8;
            // 
            // CurrentFrame_Text
            // 
            this.CurrentFrame_Text.Location = new System.Drawing.Point(865, 62);
            this.CurrentFrame_Text.Name = "CurrentFrame_Text";
            this.CurrentFrame_Text.ReadOnly = true;
            this.CurrentFrame_Text.Size = new System.Drawing.Size(100, 20);
            this.CurrentFrame_Text.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1092, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            // 
            // XYCo
            // 
            this.XYCo.Location = new System.Drawing.Point(1092, 42);
            this.XYCo.Name = "XYCo";
            this.XYCo.ReadOnly = true;
            this.XYCo.Size = new System.Drawing.Size(100, 20);
            this.XYCo.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(971, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Detected Co-Ordinates";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1019, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "X-Y";
            // 
            // Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 415);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.XYCo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CurrentFrame_Text);
            this.Controls.Add(this.FPS_text);
            this.Controls.Add(this.TotalFrame_text);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.NextFrame_button);
            this.Controls.Add(this.SearchFile_button);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Win";
            this.Text = "Background Subtration Tracker";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentFrame_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundFrame_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DifferenceFrame_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Object_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox CurrentFrame_Image;
        private Emgu.CV.UI.ImageBox BackgroundFrame_Image;
        private Emgu.CV.UI.ImageBox DifferenceFrame_Image;
        private Emgu.CV.UI.ImageBox Object_Image;
        private System.Windows.Forms.Button SearchFile_button;
        private System.Windows.Forms.Button NextFrame_button;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TotalFrame_text;
        private System.Windows.Forms.TextBox FPS_text;
        private System.Windows.Forms.TextBox CurrentFrame_Text;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox XYCo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

