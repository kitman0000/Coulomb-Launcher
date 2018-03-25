namespace SWAT4启动器
{
    partial class Server
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
            this.ip = new System.Windows.Forms.TextBox();
            this.mode = new System.Windows.Forms.TextBox();
            this.players = new System.Windows.Forms.TextBox();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.mod = new System.Windows.Forms.TextBox();
            this.version = new System.Windows.Forms.TextBox();
            this.map = new System.Windows.Forms.TextBox();
            this.ping = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ip
            // 
            this.ip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ip.Location = new System.Drawing.Point(27, 34);
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Size = new System.Drawing.Size(149, 14);
            this.ip.TabIndex = 0;
            this.ip.Text = "IP ";
            // 
            // mode
            // 
            this.mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.mode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.mode.Location = new System.Drawing.Point(27, 66);
            this.mode.Name = "mode";
            this.mode.ReadOnly = true;
            this.mode.Size = new System.Drawing.Size(149, 14);
            this.mode.TabIndex = 1;
            this.mode.Text = "模式 ";
            this.mode.TextChanged += new System.EventHandler(this.mode_TextChanged);
            // 
            // players
            // 
            this.players.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.players.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.players.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.players.Location = new System.Drawing.Point(378, 34);
            this.players.Name = "players";
            this.players.ReadOnly = true;
            this.players.Size = new System.Drawing.Size(149, 14);
            this.players.TabIndex = 2;
            this.players.Text = "玩家 ";
            this.players.TextChanged += new System.EventHandler(this.players_TextChanged);
            // 
            // ServerName
            // 
            this.ServerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ServerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ServerName.Location = new System.Drawing.Point(19, 7);
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            this.ServerName.Size = new System.Drawing.Size(408, 14);
            this.ServerName.TabIndex = 3;
            this.ServerName.Text = "服务器";
            // 
            // mod
            // 
            this.mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.mod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.mod.Location = new System.Drawing.Point(182, 66);
            this.mod.Name = "mod";
            this.mod.ReadOnly = true;
            this.mod.Size = new System.Drawing.Size(180, 14);
            this.mod.TabIndex = 4;
            this.mod.Text = "模组 ";
            this.mod.TextChanged += new System.EventHandler(this.mod_TextChanged);
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.version.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.version.Location = new System.Drawing.Point(378, 66);
            this.version.Name = "version";
            this.version.ReadOnly = true;
            this.version.Size = new System.Drawing.Size(149, 14);
            this.version.TabIndex = 5;
            this.version.Text = "版本 ";
            this.version.TextChanged += new System.EventHandler(this.version_TextChanged);
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.map.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.map.Location = new System.Drawing.Point(182, 34);
            this.map.Name = "map";
            this.map.ReadOnly = true;
            this.map.Size = new System.Drawing.Size(180, 14);
            this.map.TabIndex = 6;
            this.map.Text = "地图 ";
            // 
            // ping
            // 
            this.ping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ping.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ping.Location = new System.Drawing.Point(378, 7);
            this.ping.Name = "ping";
            this.ping.ReadOnly = true;
            this.ping.Size = new System.Drawing.Size(77, 14);
            this.ping.TabIndex = 7;
            this.ping.Text = "延时：测试中";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.ping);
            this.Controls.Add(this.map);
            this.Controls.Add(this.version);
            this.Controls.Add(this.mod);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.players);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.ip);
            this.Name = "Server";
            this.Size = new System.Drawing.Size(519, 95);
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip;
        public System.Windows.Forms.TextBox mode;
        public System.Windows.Forms.TextBox players;
        public System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.TextBox mod;
        private System.Windows.Forms.TextBox version;
        private System.Windows.Forms.TextBox map;
        public System.Windows.Forms.TextBox ping;
    }
}
