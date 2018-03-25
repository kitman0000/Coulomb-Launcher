namespace SWAT4启动器
{
    partial class Error
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
        /// 
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ErrorCode_label = new System.Windows.Forms.Label();
            this.ErrorMsgrichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SWAT4启动器.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(40, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ErrorCode_label
            // 
            this.ErrorCode_label.AutoSize = true;
            this.ErrorCode_label.Font = new System.Drawing.Font("宋体", 15F);
            this.ErrorCode_label.Location = new System.Drawing.Point(183, 68);
            this.ErrorCode_label.Name = "ErrorCode_label";
            this.ErrorCode_label.Size = new System.Drawing.Size(109, 20);
            this.ErrorCode_label.TabIndex = 1;
            this.ErrorCode_label.Text = "库伦出错了";
            // 
            // ErrorMsgrichTextBox
            // 
            this.ErrorMsgrichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ErrorMsgrichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorMsgrichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ErrorMsgrichTextBox.Location = new System.Drawing.Point(187, 91);
            this.ErrorMsgrichTextBox.Name = "ErrorMsgrichTextBox";
            this.ErrorMsgrichTextBox.ReadOnly = true;
            this.ErrorMsgrichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ErrorMsgrichTextBox.Size = new System.Drawing.Size(276, 111);
            this.ErrorMsgrichTextBox.TabIndex = 2;
            this.ErrorMsgrichTextBox.Text = "";
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BorderColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(505, 249);
            this.CloseBoxSize = new System.Drawing.Size(15, 15);
            this.CloseDownBack = global::SWAT4启动器.Properties.Resources.关闭_按下;
            this.CloseMouseBack = global::SWAT4启动器.Properties.Resources.关闭_鼠标;
            this.CloseNormlBack = global::SWAT4启动器.Properties.Resources.关闭_普通;
            this.Controls.Add(this.ErrorMsgrichTextBox);
            this.Controls.Add(this.ErrorCode_label);
            this.Controls.Add(this.pictureBox1);
            this.EffectWidth = 0;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaxSize = new System.Drawing.Size(0, 0);
            this.MiniDownBack = global::SWAT4启动器.Properties.Resources.最小化_按下;
            this.MiniMouseBack = global::SWAT4启动器.Properties.Resources.最小化_鼠标;
            this.MiniNormlBack = global::SWAT4启动器.Properties.Resources.最小化_关闭;
            this.MiniSize = new System.Drawing.Size(15, 15);
            this.Name = "Error";
            this.ShadowWidth = 1;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "容错窗口";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ErrorCode_label;
        private System.Windows.Forms.RichTextBox ErrorMsgrichTextBox;
    }
}