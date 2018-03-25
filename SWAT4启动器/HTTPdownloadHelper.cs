using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace SWAT4启动器
{
    class HTTPdownloadHelper
    {
        public void download(string URL,Download downloadUI,string path)
        {
            downloadUI.DownloadByte = 0;
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            int readSize = 0;//已经读取的字节
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
                readSize += size;
                downloadUI.DownloadByte = (int)(((float)readSize/ responseStream.Length) * 100);
            }
            stream.Close();
            responseStream.Close();
        }
    }
}
