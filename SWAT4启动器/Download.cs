using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.GZip;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;

namespace SWAT4启动器
{

    public partial class Download : UserControl
    {
        public FlowLayoutPanel manager;
        public FlowLayoutPanel ModLister;
        public Form1 frm1;//主窗口
        public string ModID;
        public string add;//是否安装后添加到Mod列表，如果值为"false"则为不需要，否则为启动路径
        public string ftpHost;
        public string ftpUser;
        public string ftpPassword;
        public int size;
        public Download()
        {
            InitializeComponent();
            downloadButton1.mouse = this.downloadButton1_Click;
        }
        public int DownloadByte
        {
            set {
                this.downloadButton1.TextLabel.Text ="已下载" + value + "%";
                this.downloadButton1.setProgress(value);
            }
        }
        private void timer_unfold_Tick(object sender, EventArgs e)
        {
            if (Height <= 95 * 2)
            {
                Height += 5;
                unfold.Top = Height - unfold.Height;
            }
            else
            {
                timer_unfold.Stop();
            }
        }

        private void timer_fold_Tick(object sender, EventArgs e)
        {
            if (Height > 95)
            {
                Height -= 5;
                unfold.Top = Height - unfold.Height;
            }
            else
            {
                timer_fold.Stop();
            }
        }

        private void unfold_Click(object sender, EventArgs e)
        {
            if (Height >= 95 * 2)
            {
                instruction.Hide();
                unfold.Image = Properties.Resources.more;
                timer_fold.Start();
            }
            else if (Height == 95)
            {
                instruction.Show();
                unfold.Image = Properties.Resources.less;
                timer_unfold.Start();
            }
        }

        private void Download_Load(object sender, EventArgs e)
        {
            Height = 95;
            string mods = INIHelper.Read("launcher", "download", "launcher.ini");
            if (mods.Contains(ModID + ":"))
                downloadButton1.TextLabel.Text = "已安装";
        }

        public void Setup()
        {
            if(File.Exists("setup_" + ModID + ".bat"))
            Process.Start("setup_" + ModID+".bat");
        }

        public void unzip(string zip, string unzip)
        {
            // Perform simple parameter checking.
            if (zip.Length < 1)
            {
                Console.WriteLine("Usage UnzipFile NameOfFile");
                return;
            }

            if (!File.Exists(zip))
            {
                Console.WriteLine("Cannot find file '{0}'", zip);
                return;
            }
            
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zip)))
            {
                FileInfo fi = new FileInfo(zip);
                Console.WriteLine(fi.Length.ToString());
                ZipEntry theEntry;
                int readed = 0;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    Console.WriteLine((int)(((float)readed / fi.Length) * 100));
                    downloadButton1.setProgress((int)(((float)readed / fi.Length)*100));
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(theEntry.Name))
                        {
   
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                    readed += size;
                                }
                                else {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }


        private void downloadButton1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        FTPhelper ftp;
        private void downloadButton1_Click(object sender, EventArgs e)
        {
            if (downloadButton1.TextLabel.Text != "下载")
                return;
            frm1.DownloadQueue.Add(this);
            downloadButton1.TextLabel.Text = "连接下载服务器中";
            ftp = new FTPhelper(this, ftpHost, ftpUser, ftpPassword,"KL_"+ModID+".zip",size);
            ftp.login();
            //Thread th = new Thread(install);
            //th.Start();

        }
        public void install()
        {
            try
            {
                downloadButton1.TextLabel.Text = "安装中..";
                unzip("KL_" + ModID + ".zip", System.Environment.CurrentDirectory);
                downloadButton1.setProgress(0);
                downloadButton1.TextLabel.Text = "已安装";
                ModManager MM = new ModManager();
                MM.ModID = ModID;
                MM.ModName = this.Modname.Text.Replace("名称：", string.Empty);
                this.Invoke(new EventHandler(delegate
                {
                    manager.Controls.Add(MM);
                    //添加mod到目录
                    if (add != "false")
                    {
                        ListButton btn = new ListButton(MM.ModName, frm1, add, true);
                        ModLister.Controls.Add(btn);
                        string oldmods = INIHelper.Read("launcher", "mod", "launcher.ini");
                        if (oldmods == "on")
                        {
                            oldmods = string.Empty;
                        }
                        INIHelper.Write("launcher", "mod", oldmods + MM.ModName + "%file%" + add + "%mod%", "launcher.ini");

                    }
                }));
                //添加到管理目录
                string old = INIHelper.Read("launcher", "download", "launcher.ini");
                old = old == "on" ? string.Empty : old;
                INIHelper.Write("launcher", "download", old + ModID + ":" + Modname.Text.Replace("名称：", string.Empty) + ";", "launcher.ini");
                frm1.DownloadQueue.Remove(this);
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }
        private void Download_Click(object sender, EventArgs e)
        {

        }


    }
}
