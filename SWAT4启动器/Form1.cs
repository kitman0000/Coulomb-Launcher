using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.GZip;
using System.Diagnostics;
namespace SWAT4启动器
{

    public partial class Form1 : CCWin.CCSkinMain
    {
        SocketHelper SocketHelper = new SocketHelper();
        ClientSocketHelper clientSocketHelper = new ClientSocketHelper();
        string userini;
        public List<Download> DownloadQueue = new List<Download>();
        List<Point> drawpoint = new List<Point>();
        List<Pen> drawpen = new List<Pen>();
        public Form1()
        {
            InitializeComponent();
            //检测是否正确安装
            if (!File.Exists(@"Content\System\Swat4.exe"))
            {
               new ErrorPosition().ShowDialog();
                this.Dispose();
            }
            Console.WriteLine(INIHelper.Read("launcher", "msg", "launcher.ini"));
            if (INIHelper.Read("launcher", "window", "launcher.ini") == "on")
            {
                window_checkBox.Checked = true;
            }
            if (INIHelper.Read("launcher", "delLnk", "launcher.ini") == "on")
            {
                DelLnk.Checked = true;
            }


        }

        private void SetWindowOn()
        {
        
            if (File.Exists("Swat4.ini"))//是否是原版
            {
                string oldFile = File.ReadAllText("Swat4.ini");
                 File.WriteAllText("Swat4.ini",oldFile.Replace("Suppress=WindowedMode", ";Suppress=WindowedMode"));
            }
            else//若不存在swat4.ini则为资料片
            {
                string oldFile = File.ReadAllText("Swat4x.ini");
                File.WriteAllText("Swat4x.ini", oldFile.Replace("Suppress=WindowedMode", ";Suppress=WindowedMode"));
            }

        }

        private void SetWindowOff()
        {
            try
            {
                if (File.Exists("Swat4.ini"))//是否是原版
                {
                    string oldFile = File.ReadAllText("Swat4.ini");
                    File.WriteAllText("Swat4.ini", oldFile.Replace(";Suppress=WindowedMode", "Suppress=WindowedMode"));
                }
                else//若不存在swat4.ini则为资料片
                {
                    string oldFile = File.ReadAllText("Swat4x.ini");
                    File.WriteAllText("Swat4x.ini", oldFile.Replace(";Suppress=WindowedMode", "Suppress=WindowedMode"));
                }
            }
            catch { }
        }
        //INIHelper.Write("Engine.Input", "3", "CommandOrEquip Row_NumberKeys 3 | say[c = 0080FF][b]閃光彈![c = 0080FF][\b]","user.ini");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string exe = null;

                //System.IO.Directory.SetCurrentDirectory(@"ContentExpansion\System");
                foreach (ListButton btn in flowLayoutPanel1.Controls)
                {
                    if (btn.check)
                    {
                        exe = btn._file;
                        info inf = new info(btn.GameName);
                        inf.ShowDialog();
                        break;
                    }
                }
                if (exe == null)
                    return;
                exe = exe.Replace(@"\", "分");
                string[] files = System.Text.RegularExpressions.Regex.Split(exe, @"分");
                exe = exe.Replace("分", @"\");
                System.IO.Directory.SetCurrentDirectory(exe.Replace(files[files.Length - 1], string.Empty));
                if (window_checkBox.Checked)
                {
                    SetWindowOn();
                }
                else
                {
                    SetWindowOff();
                }
                System.Diagnostics.Process.Start(files[files.Length - 1]);


    

                if (DelLnk.Checked)
                {
                    try
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\游侠对战平台.lnk");
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Error error = new Error(ex.ToString());
                error.Show();      
            }
            Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);
        }

        private void skinHotKey1_HotKeyTrigger(object sender, CCWin.SkinControl.HotKeyEventArgs e)
        {
            Console.WriteLine(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //设置初始页面
                skinTabControl1.SelectTab(0);
                CheckForIllegalCrossThreadCalls = false;
                //抓取网页爬虫
                Thread thread = new Thread(CheckUpdate);
                thread.Start();
                point.Hide();
                //加载MOD
                ListButton oldversion = new ListButton("SWAT4原版1.1", this, @"Content\System\swat4.exe", false);
                flowLayoutPanel1.Controls.Add(oldversion);
                ListButton newversion = new ListButton("SWAT4资料片1.0", this, @"ContentExpansion\System\swat4x.exe", false);
                flowLayoutPanel1.Controls.Add(newversion);
                string data = INIHelper.Read("launcher", "mod", "launcher.ini");
                if (data != "on")
                {
                    string[] datas = System.Text.RegularExpressions.Regex.Split(data, "%mod%");
                    foreach (string s in datas)
                    {
                        if (s == string.Empty)
                            continue;
                        string[] parts = System.Text.RegularExpressions.Regex.Split(s, "%file%");
                        ListButton btn = new ListButton(parts[0], this, parts[1], true);
                        flowLayoutPanel1.Controls.Add(btn);
                    }
                }
                //加载下载内容
                string mods = INIHelper.Read("launcher", "download", "launcher.ini");
                if (mods != "on")
                {
                    string[] ModDetial = mods.Split(new char[] { ';' });
                    foreach (string mod in ModDetial)
                    {
                        if (mod == string.Empty) break;
                        ModManager MM = new ModManager();
                        string[] d = mod.Split(new char[] {':'});
                        MM.ModID = d[0];
                        MM.ModName = d[1];
                        flowLayoutPanel_manager.Controls.Add(MM);
                    }

                }
                //刷新下载项目
                new Thread(RefreshDownload).Start();
                LoadMaps();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private void CheckUpdate()
        {
            try
            {
                int a = Environment.TickCount;
                Console.WriteLine(System.Environment.TickCount);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebsiteAddress.Address);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());
                string data = sr.ReadToEnd();
                //Console.WriteLine(data);
                int index = data.IndexOf("目前启动器版本");
                string version = data.Substring(index + 7, 4);
                Console.WriteLine("版本：" + version);
                int msgstart = data.IndexOf("公告") + 2; int msgend = data.IndexOf("/公告");
                string msg = data.Substring(msgstart, msgend - msgstart);
                msg_textbox.Text = msg;
                if (msg != INIHelper.Read("launcher", "lastmsg", "launcher.ini"))
                {
                    point.Show();
                    INIHelper.Write("launcher", "lastmsg", msg, "launcher.ini");
                }
                if (version != "b1.1")
                {
                    MessageBox.Show("发现新版本，请前往下载！");
                    System.Diagnostics.Process.Start(@"https://kitman0000.github.io/ELET/kulun/%E5%BA%93%E4%BC%A6%E5%90%AF%E5%8A%A8%E5%99%A8.rar");
                }
                sr.Close();
                request = null;
                Console.WriteLine(System.Environment.TickCount);
                int b = Environment.TickCount;
                Console.WriteLine("计时" + (b - a));
                
            }
            catch(Exception x)
            {
                Console.WriteLine(x.ToString());
            }
        }
  

        private void DelLnk_CheckedChanged(object sender, EventArgs e)
        {
            if (DelLnk.Checked == false)
            {
                INIHelper.Write("launcher", "delLnk", "off", "launcher.ini");
            }
            else
            {
                INIHelper.Write("launcher", "delLnk", "on", "launcher.ini");
            }
        }


        private void skinTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinTabControl1.SelectedIndex == 1)
            {
                point.Hide();
            }
        }

        private void msg_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);
            ModFinderDialog.ShowDialog();
            if (ModFinderDialog.FileName != string.Empty)
            {
                Modname md = new Modname();
                md.ShowDialog();
                ListButton btn = new ListButton(md.name, this, ModFinderDialog.FileName, true);
                flowLayoutPanel1.Controls.Add(btn);
                string old = INIHelper.Read("launcher", "mod", "launcher.ini");
                if (old == "on")
                {
                    old = string.Empty;
                }
                INIHelper.Write("launcher", "mod", old + md.name + "%file%" + ModFinderDialog.FileName + "%mod%", "launcher.ini");
            }
        }

        private void ServerRefreshButton_Click(object sender, EventArgs e)
        {
            ServerRefreshButton.Text = "刷新中";
            ServerRefreshButton.Enabled = false;
            refreshtimer.Start();
            flowLayoutPanel2.Controls.Clear();
            Thread thread = new Thread(refresh);
            thread.Start();
        }
        List<Server> serverList;
        void refresh()
        {
            serverList = new List<Server>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://swat4stats.com/servers/");
            Encoding GBK = Encoding.GetEncoding(936);
            StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream(), GBK);
            string data = sr.ReadToEnd();
            string[] a = Regex.Split(data, "<a href=\"");
            foreach (string b in a)
            {
                if (b.StartsWith(@"/servers") && !b.StartsWith("/servers/?"))
                {
                    string ip = b.Replace(@"/servers/", string.Empty);
                    string[] temp = Regex.Split(ip, "/\">");
                    ip = temp[0];

                    temp = Regex.Split(temp[1], "</a");
                    string name = temp[0];
                    name = name.Replace("</span>", string.Empty);
                    temp = Regex.Split(name, ">");
                    name = temp[temp.Length - 1];

                    string[] x = Regex.Split(b, "<div>");
                    string num = x[1].Replace("</div>", string.Empty);
                    string mode = x[2].Replace("</div>", string.Empty);
                    string map = x[3].Replace("</div>", string.Empty);
                    string MOD = x[5].Replace("</div>", string.Empty);
                    string version = x[6].Replace("</div>", string.Empty);
                    //翻译模式
                    if (mode == "CO-OP")
                        mode = "合作模式";
                    if (mode == "Barricaded Suspects")
                        mode = "警匪对战";
                    if (mode == "VIP Escort")
                        mode = "VIP逃离";
                    Server server = new Server(name, ip, map, num, mode, MOD, version);
                    serverList.Add(server);
                    this.Invoke(new EventHandler(delegate
                    {
                        flowLayoutPanel2.Controls.Add(server);
                    }));

                }
            }
        }

        void CallBackMethod(IAsyncResult ar)
        {

        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {

            e.Cancel = true;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
        }

        private void refreshtimer_Tick(object sender, EventArgs e)
        {
            refreshtimer.Stop();
            ServerRefreshButton.Enabled = true;
            ServerRefreshButton.Text = "刷新";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Server[] servers = new Server[flowLayoutPanel2.Controls.Count];
                flowLayoutPanel2.Controls.CopyTo(servers,0);

                flowLayoutPanel2.Controls.Clear();
                if (checkBox1.Checked == true)
                {
                    foreach (Server s in servers)
                    {
                        if (!s.players.Text.StartsWith("玩家 0"))
                        {
                            flowLayoutPanel2.Controls.Add(s);
                        }
                    }
                }
                else
                {
                    foreach (Server s in serverList)
                    {
                        if(s.ServerName.Text.Contains(textBox2.Text))
                        flowLayoutPanel2.Controls.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Error error = new Error(ex.ToString());
                error.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();

                foreach (Server s in serverList)
                {
                    if (s.ServerName.Text.ToLower().Contains(textBox2.Text.ToLower()))
                    {
                        if(!(checkBox1.Checked && s.players.Text.StartsWith("玩家 0")))
                            flowLayoutPanel2.Controls.Add(s);
                    }
                }

            }
            catch (Exception ex)
            {
                Error error = new Error(ex.ToString());
                error.Show();
            }
        }
        //Debug only
        private void download1_Load(object sender, EventArgs e)
        {
        }
        void RefreshDownload()
        {
            try
            {
                closeAdv();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebsiteAddress.Address);
                //Encoding GBK = Encoding.GetEncoding(936);
                StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());
                string data = sr.ReadToEnd();
                Console.WriteLine(data);
                List<string> mods = new List<string>(Regex.Split(data, "<mod>"));
                //删除首项和末项，过滤信息
                mods.RemoveAt(0);
                mods.RemoveAt(mods.Count - 1);
                foreach (string info in mods)
                {
                    string[] i = info.Split(new char[] { ';' });
                    Console.WriteLine("ModID" + i[0]);
                    Console.WriteLine("ModName" + i[1]);
                    Console.WriteLine("ModSize" + i[2]);
                    Console.WriteLine("ModDeveloper" + i[3]);
                    Console.WriteLine("instruction" + i[4]);
                    Console.WriteLine("add" + i[5]);
                    Console.WriteLine("FTPhost" + i[6]);
                    Console.WriteLine("FTPuser" + i[7]);
                    Console.WriteLine("FTPpassword" + i[8]);
                    Download dl = new Download();
                    dl.ModID = i[0];
                    dl.Modname.Text += i[1];
                    int Dsize = int.Parse(i[2]);
                    dl.size = Dsize;
                    if (Dsize < 8 * 1024 * 1024)//kb为单位
                    {
                        i[2] = Dsize / 1024 + "KB";
                    }
                    else if (Dsize >= 8 * 1024 * 1024)//MB为单位
                    {
                        i[2] = Dsize / 1024 / 1024 + "MB";
                    }
                    dl.DocumentSize.Text += i[2];
                    dl.Developer.Text += i[3];
                    dl.instruction.Text += i[4];
                    dl.add = i[5];
                    dl.ftpHost = i[6];
                    dl.ftpUser = i[7];
                    dl.ftpPassword = i[8];
                    dl.manager = this.flowLayoutPanel_manager;
                    dl.frm1 = this;
                    dl.ModLister = this.flowLayoutPanel1;
                    this.Invoke(new EventHandler(delegate
                    {
                        flowLayoutPanel_download.Controls.Add(dl);
                    }));
                }

            }
            catch
            {
                //RefreshDownload();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DownloadQueue.Count != 0)
            {
                DialogResult dr = MessageBox.Show("下载队列尚未完成，关闭窗口后可能会出现未知bug。\r\n是否继续关闭？", "退出", MessageBoxButtons.OKCancel);
                e.Cancel = (dr == DialogResult.Cancel);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SocketHelper.CloseServer();
            clientSocketHelper.shutdown();
            Application.Exit();
        }

        private void window_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (window_checkBox.Checked == false)
            {
                INIHelper.Write("launcher", "window", "off", "launcher.ini");
            }
            else
            {
                INIHelper.Write("launcher", "window", "on", "launcher.ini");
            }
        }

        private void window_checkBox_MouseEnter(object sender, EventArgs e)
        {
            WindowWarn_label.Show();
        }

        private void window_checkBox_MouseLeave(object sender, EventArgs e)
        {
            WindowWarn_label.Hide();
        }
        private void closeAdv()
        {
            try
            {
                Process p1 = null; Process p2 = null;
                foreach (Process thisProc in Process.GetProcesses())
                {
                    if (thisProc.ProcessName != "ali213Pk") continue;
                    Console.WriteLine(thisProc.ProcessName);
                    //Console.Write("   "+thisProc.StartInfo);
                    Console.Write("   " + thisProc.StartTime + "\r");
                    if (p1 == null) p1 = thisProc; else p2 = thisProc;
                }
                if (p1 == null) return;
                if (p1.StartTime < p2.StartTime)
                {
                    p2.Kill();
                }
                else { p1.Kill(); }
            }
            catch { };
        }
        Graphics g;
        Pen pen;
        bool MapMouseDown;
        Point MapLastPoint;
        Color MapPenColor;
        Bitmap bm;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = pictureBox1.CreateGraphics();
                pen = new Pen(MapPenColor);
                pen.Width = 2;
                MapMouseDown = true;
                MapLastPoint = Point.Empty;
                SocketHelper.send("readyDraw&&1");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MapContextMenuStrip.Show(Control.MousePosition);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MapMouseDown = false;
            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MapMouseDown && !MapLastPoint.IsEmpty)
            {
                g.DrawLine(pen, pictureBox1.PointToClient(Control.MousePosition), MapLastPoint);
                drawpoint.Add(pictureBox1.PointToClient( Control.MousePosition));
                drawpen.Add(pen);
                if (UsingServer)
                {
                    SocketHelper.send("draw&&" + pen.Color.ToArgb()+ "&&" + pictureBox1.PointToClient(Control.MousePosition).X +"&&"+
                         pictureBox1.PointToClient(Control.MousePosition).Y+"&&"+ MapLastPoint.X+"&&"+MapLastPoint.Y);
                }
            }
            else if (MapMouseDown && MapLastPoint.IsEmpty)
            {
                g.DrawLine(pen, pictureBox1.PointToClient(Control.MousePosition).X, pictureBox1.PointToClient(Control.MousePosition).Y, pictureBox1.PointToClient(Control.MousePosition).X, pictureBox1.PointToClient(Control.MousePosition).Y);
                Console.WriteLine(pictureBox1.PointToClient(Control.MousePosition).X+","+pictureBox1.PointToClient(Control.MousePosition).Y + "," + pictureBox1.PointToClient(Control.MousePosition).X, pictureBox1.PointToClient(Control.MousePosition).Y);
                drawpoint.Add(pictureBox1.PointToClient(Control.MousePosition));
                drawpen.Add(pen);
                if (UsingServer)
                {
                    SocketHelper.send("draw&&" + pen.Color.ToArgb() + "&&" + pictureBox1.PointToClient(Control.MousePosition).X + "&&" + pictureBox1.PointToClient(Control.MousePosition).Y + "&&" +
                        pictureBox1.PointToClient(Control.MousePosition).X + "&&" + pictureBox1.PointToClient(Control.MousePosition).Y);
                }
            }

            MapLastPoint = pictureBox1.PointToClient(Control.MousePosition);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            drawpen.Clear();
            drawpoint.Clear();
            pictureBox1.Refresh();
            if (UsingServer) SocketHelper.send("clear");    
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            MapPenColor = colorDialog.Color;
        }
        private void LoadMaps()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory()+@"\MAPS");
            if (!directoryInfo.Exists)
            {
                MapWarnLabel.Show();
                return;
            }
            foreach (FileInfo map in directoryInfo.GetFiles())
            {
                ToolStripMenuItem mapItem = new ToolStripMenuItem(map.Name);
                ((ToolStripDropDownItem)MapContextMenuStrip.Items[1]).DropDownItems.Add(mapItem);
                mapItem.Click += new EventHandler(Changemaps);
            }
            
        }
        private void Changemaps(object sender,EventArgs e)
        {
            pictureBox1.Image=Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\MAPS\" + ((ToolStripMenuItem)sender).Text);
            if (UsingServer)
            {
                SocketHelper.send("changemap&&"+ ((ToolStripMenuItem)sender).Text);
            }
        }
        public void ReciveData(string data)
        {
            string[] datas = Regex.Split(data, "&&");
            string cmd = datas[0];//数据包为：指令&&参数1&&参数2……
            switch (cmd)
            {
                case "changemap":
                {
                        pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\MAPS\" +datas[1]);
                        break;
                }
                case "draw":
                {
                        Pen ServerPen = new Pen(Color.FromArgb(int.Parse(datas[1])));
                        ServerPen.Width = 2;
                        g.DrawLine(ServerPen ,float.Parse( datas[2]), float.Parse( datas[3]), float.Parse( datas[4]), float.Parse( datas[5]));
                        //Console.WriteLine((float)int.Parse(data[2]) + "," + (float)data[3] + "," + (float)data[4] + "," + (float)data[5]);
                        Point p = new Point(data[2], data[3]);
                        drawpoint.Add(p);
                        drawpen.Add(ServerPen);
                        return;
                }
                case "readyDraw":
                {
                        g = pictureBox1.CreateGraphics();
                        break;
                 }
                case "clear":
                {
                        drawpen.Clear();
                        drawpoint.Clear();
                        pictureBox1.Refresh();
                        return;
                }
                case "end":
               {
                        MessageBox.Show("房间已经关闭");
                        return;
               }
            }

        }
        bool UsingServer = false;
        private void 开启房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketHelper.CreateServer(this);
            UsingServer = true;
        }

        private void 连接房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPdialog dialog = new IPdialog();
            dialog.ShowDialog();
            string ip = dialog.IP;
            if (ip == "none") return;
            clientSocketHelper.connect(ip,this);
            clientSocketHelper.Send("Hello Not_K");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen fp = new Pen(Color.Red);
            for (int p = 0; p < drawpoint.Count-1; p++)
            {
               e.Graphics.DrawLine(drawpen[p], drawpoint[p], drawpoint[p + 1]);
               // e.Graphics.DrawLine(fp, drawpoint[0], drawpoint[drawpoint.Count - 1]);
            }
        }
    }
}
    
