namespace BenchDemo
{
    partial class BackGroundSubtractionDemo
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
            this.BS_Image_box = new Emgu.CV.UI.ImageBox();
            this.Image_box = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Pause_Play_btn = new System.Windows.Forms.Button();
            this.restart_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Image_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_box)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BS_Image_box, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Image_box, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BS_Image_box
            // 
            this.BS_Image_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BS_Image_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BS_Image_box.Location = new System.Drawing.Point(411, 18);
            this.BS_Image_box.Name = "BS_Image_box";
            this.BS_Image_box.Size = new System.Drawing.Size(400, 345);
            this.BS_Image_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BS_Image_box.TabIndex = 5;
            this.BS_Image_box.TabStop = false;
            // 
            // Image_box
            // 
            this.Image_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image_box.Location = new System.Drawing.Point(4, 18);
            this.Image_box.Name = "Image_box";
            this.Image_box.Size = new System.Drawing.Size(400, 345);
            this.Image_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image_box.TabIndex = 4;
            this.Image_box.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background Subtraction";
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(19, 12);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(82, 32);
            this.Search_btn.TabIndex = 1;
            this.Search_btn.Text = "Select file";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Pause_Play_btn
            // 
            this.Pause_Play_btn.Enabled = false;
            this.Pause_Play_btn.Location = new System.Drawing.Point(142, 12);
            this.Pause_Play_btn.Name = "Pause_Play_btn";
            this.Pause_Play_btn.Size = new System.Drawing.Size(80, 32);
            this.Pause_Play_btn.TabIndex = 2;
            this.Pause_Play_btn.Text = "Play";
            this.Pause_Play_btn.UseVisualStyleBackColor = true;
            this.Pause_Play_btn.Click += new System.EventHandler(this.Pause_Play_btn_Click);
            // 
            // restart_btn
            // 
            this.restart_btn.Enabled = false;
            this.restart_btn.Location = new System.Drawing.Point(259, 12);
            this.restart_btn.Name = "restart_btn";
            this.restart_btn.Size = new System.Drawing.Size(80, 32);
            this.restart_btn.TabIndex = 3;
            this.restart_btn.Text = "Restart";
            this.restart_btn.UseVisualStyleBackColor = true;
            this.restart_btn.Click += new System.EventHandler(this.restart_btn_Click);
            // 
            // BackGroundSubtractionDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 439);
            this.Controls.Add(this.restart_btn);
            this.Controls.Add(this.Pause_Play_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BackGroundSubtractionDemo";
            this.Text = "Background Subtraction";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Image_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button Pause_Play_btn;
        private System.Windows.Forms.Button restart_btn;
        private Emgu.CV.UI.ImageBox BS_Image_box;
        private Emgu.CV.UI.ImageBox Image_box;
    }
}

