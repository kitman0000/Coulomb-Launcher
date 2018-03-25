namespace SWAT4启动器
{
    partial class Download
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Modname = new System.Windows.Forms.Label();
            this.DocumentSize = new System.Windows.Forms.Label();
            this.Developer = new System.Windows.Forms.Label();
            this.instruction = new System.Windows.Forms.Label();
            this.timer_unfold = new System.Windows.Forms.Timer(this.components);
            this.timer_fold = new System.Windows.Forms.Timer(this.components);
            this.unfold = new System.Windows.Forms.PictureBox();
            this.downloadButton1 = new SWAT4启动器.DownloadButton();
            ((System.ComponentModel.ISupportInitialize)(this.unfold)).BeginInit();
            this.SuspendLayout();
            // 
            // Modname
            // 
            this.Modname.AutoSize = true;
            this.Modname.Location = new System.Drawing.Point(26, 22);
            this.Modname.Name = "Modname";
            this.Modname.Size = new System.Drawing.Size(41, 12);
            this.Modname.TabIndex = 0;
            this.Modname.Text = "名称：";
            // 
            // DocumentSize
            // 
            this.DocumentSize.AutoSize = true;
            this.DocumentSize.Location = new System.Drawing.Point(197, 22);
            this.DocumentSize.Name = "DocumentSize";
            this.DocumentSize.Size = new System.Drawing.Size(41, 12);
            this.DocumentSize.TabIndex = 1;
            this.DocumentSize.Text = "大小：";
            // 
            // Developer
            // 
            this.Developer.AutoSize = true;
            this.Developer.Location = new System.Drawing.Point(363, 22);
            this.Developer.Name = "Developer";
            this.Developer.Size = new System.Drawing.Size(53, 12);
            this.Developer.TabIndex = 2;
            this.Developer.Text = "开发者：";
            // 
            // instruction
            // 
            this.instruction.Location = new System.Drawing.Point(26, 55);
            this.instruction.Name = "instruction";
            this.instruction.Size = new System.Drawing.Size(445, 101);
            this.instruction.TabIndex = 3;
            this.instruction.Text = "介绍：";
            this.instruction.Visible = false;
            // 
            // timer_unfold
            // 
            this.timer_unfold.Interval = 15;
            this.timer_unfold.Tick += new System.EventHandler(this.timer_unfold_Tick);
            // 
            // timer_fold
            // 
            this.timer_fold.Interval = 15;
            this.timer_fold.Tick += new System.EventHandler(this.timer_fold_Tick);
            // 
            // unfold
            // 
            this.unfold.Image = global::SWAT4启动器.Properties.Resources.more;
            this.unfold.Location = new System.Drawing.Point(497, 67);
            this.unfold.Name = "unfold";
            this.unfold.Size = new System.Drawing.Size(25, 25);
            this.unfold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.unfold.TabIndex = 4;
            this.unfold.TabStop = false;
            this.unfold.Click += new System.EventHandler(this.unfold_Click);
            // 
            // downloadButton1
            // 
            this.downloadButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.downloadButton1.Location = new System.Drawing.Point(190, 170);
            this.downloadButton1.Name = "downloadButton1";
            this.downloadButton1.Size = new System.Drawing.Size(165, 25);
            this.downloadButton1.TabIndex = 5;
            this.downloadButton1.Click += new System.EventHandler(this.downloadButton1_Click);
            this.downloadButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.downloadButton1_MouseDown);
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.downloadButton1);
            this.Controls.Add(this.unfold);
            this.Controls.Add(this.instruction);
            this.Controls.Add(this.Developer);
            this.Controls.Add(this.DocumentSize);
            this.Controls.Add(this.Modname);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Margin = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.Name = "Download";
            this.Size = new System.Drawing.Size(535, 195);
            this.Load += new System.EventHandler(this.Download_Load);
            this.Click += new System.EventHandler(this.Download_Click);
            ((System.ComponentModel.ISupportInitialize)(this.unfold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Modname;
        public System.Windows.Forms.Label DocumentSize;
        public System.Windows.Forms.Label Developer;
        public System.Windows.Forms.Label instruction;
        private System.Windows.Forms.PictureBox unfold;
        private System.Windows.Forms.Timer timer_unfold;
        private System.Windows.Forms.Timer timer_fold;
        private DownloadButton downloadButton1;
    }
}
