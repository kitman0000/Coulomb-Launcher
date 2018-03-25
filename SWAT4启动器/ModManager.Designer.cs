namespace SWAT4启动器
{
    partial class ModManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.Remove = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Remove)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Remove
            // 
            this.Remove.Image = global::SWAT4启动器.Properties.Resources.delete;
            this.Remove.Location = new System.Drawing.Point(495, 13);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(20, 20);
            this.Remove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Remove.TabIndex = 0;
            this.Remove.TabStop = false;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Remove);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.Name = "ModManager";
            this.Size = new System.Drawing.Size(535, 50);
            ((System.ComponentModel.ISupportInitialize)(this.Remove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Remove;
        private System.Windows.Forms.Label label1;
    }
}
