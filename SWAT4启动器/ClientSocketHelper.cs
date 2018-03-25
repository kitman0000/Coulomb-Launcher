using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SWAT4启动器
{
    class ClientSocketHelper
    {
        Form1 form1;
         Socket socket;
        Thread ReadThread;
        public  void connect(string ip,Form1 _form1)
        {
            form1 = _form1;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEnd = new IPEndPoint(iPAddress, 12552);
            socket.Connect(iPEnd);
            ReadThread = new Thread(Read);
            ReadThread.Start();
        }
        public  void  Send(string data)
        {
            socket.Send(UnicodeEncoding.UTF8.GetBytes(data));
        }
        private  void Read()
        {
            while (true)
            {
                try
                {
                    byte[] b = new byte[2048];
                    int count= socket.Receive(b);
                    string data = UnicodeEncoding.UTF8.GetString(b,0,count);
                    Console.WriteLine("客户端接收:" + data);
                    form1.ReciveData(data);
                }
                catch { }
            }
        }
        public void shutdown()
        {
            if (socket == null) return;
            socket.Close();
            ReadThread.Abort();
        }
    }
}
