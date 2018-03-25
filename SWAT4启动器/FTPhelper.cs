using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;


namespace SWAT4启动器
{
    class  FTPhelper:IDisposable
    {
        
        private FtpWebRequest request;
        public string Server,User, pzw,file;
        Download dl;
        int totalSize;
        public FTPhelper(Download _download,string _server,string _user,string _pzw,string _file,int size)
        {
            dl = _download;
            Server = _server;
            User = _user;
            pzw = _pzw;
            file = _file;
            totalSize = size;
        }
        private void  LoginFTP()
        {
            try
            {
                request = (FtpWebRequest)WebRequest.Create("ftp://" + Server);
                request.Credentials = new NetworkCredential(User, pzw);
                //request.Method = WebRequestMethods.Ftp.ListDirectory;
                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //response.Close();
                download();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Error error = new Error(ex.ToString());
                error.Show();
            }

        }

        private FileStream fs;
        private void download()
        {
                fs = new FileStream(Environment.CurrentDirectory + @"\" + file, FileMode.Create);
                request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + Server + "/" + file));
                request.Credentials = new NetworkCredential(User, pzw);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UseBinary = true;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream ftpsteam = response.GetResponseStream();
                long cl = request.ContentLength;
                int bufferSize = 2048;
                int readcount;
                byte[] buffer = new byte[bufferSize];
                readcount = ftpsteam.Read(buffer, 0, bufferSize);
                int readSize = 0;//已经读取的字节
                while (readcount > 0)
                {
                    fs.Write(buffer, 0, readcount);
                    readcount = ftpsteam.Read(buffer, 0, bufferSize);
                    readSize += readcount;
                   dl.DownloadByte=(int)(((float)  readSize/totalSize)*100);
                   
                }
                ftpsteam.Close();
                fs.Close();
            dl.install();
            dl.Setup();
            this.Dispose();
        }


        public void login()
        {
            Thread th = new Thread(LoginFTP);
            th.Start();
        }

        public void Download()
        {
            Thread th = new Thread(download);
            th.Start();
        }
        public void Dispose() {
            request = null;
        }
    }
}
