namespace SWAT4启动器
{
    partial class DownloadButton
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
            this.TextLabel = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Progress)).BeginInit();
            this.SuspendLayout();
            // 
            // TextLabel
            // 
            this.TextLabel.BackColor = System.Drawing.Color.Transparent;
            this.TextLabel.ForeColor = System.Drawing.Color.White;
            this.TextLabel.Location = new System.Drawing.Point(3, 0);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(162, 24);
            this.TextLabel.TabIndex = 0;
            this.TextLabel.Text = "下载";
            this.TextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextLabel.Click += new System.EventHandler(this.TextLabel_Click);
            this.TextLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextLabel_MouseClick);
            this.TextLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextLabel_MouseDown);
            this.TextLabel.MouseEnter += new System.EventHandler(this.TextLabel_MouseEnter);
            this.TextLabel.MouseLeave += new System.EventHandler(this.TextLabel_MouseLeave);
            this.TextLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextLabel_MouseUp);
            // 
            // Progress
            // 
            this.Progress.BackColor = System.Drawing.Color.White;
            this.Progress.Location = new System.Drawing.Point(0, 22);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(0, 2);
            this.Progress.TabIndex = 1;
            this.Progress.TabStop = false;
            // 
            // DownloadButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.TextLabel);
            this.Name = "DownloadButton";
            this.Size = new System.Drawing.Size(165, 25);
            this.Load += new System.EventHandler(this.DownloadButton_Load);
            this.Click += new System.EventHandler(this.DownloadButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Progress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.PictureBox Progress;
    }
}
