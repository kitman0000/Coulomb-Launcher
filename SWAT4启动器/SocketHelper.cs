using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SWAT4启动器
{
    class SocketHelper
    {
        static public Form1 form1;
        static bool state;//socket开关
        static Socket socket;
        static List<Socket> UsersSockets = new List<Socket>();
        static Thread Listenthread;
        public static void CreateServer(Form1 f)
        {
            form1 = f;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            string strAddr = ipEntry.AddressList[0].ToString();
            IPAddress iPAddress = IPAddress.Parse(strAddr);
            IPEndPoint IPe = new IPEndPoint(iPAddress, 12552);
            socket.Bind(IPe);
            state = true;
            Listenthread = new Thread(Startlisten);
            Listenthread.Start();
        }
        private static void Startlisten()
        {
             socket.Listen(10);
            while (state)
            {
                Socket Tsocket = socket.Accept();
                Console.WriteLine("连接成功");
                Thread ReadThread = new Thread(Read);
                ReadThread.Start(Tsocket);
            }
        }
        private static void Read(object o)
        {
            Socket ClientSocket = o as Socket;
            UsersSockets.Add(ClientSocket);
            form1.Text = "库伦启动器     房间人数:" + (UsersSockets.Count + 1).ToString();
            try
            {
                while (true)
                {
                    byte[] b = new byte[2048];
                    int count = ClientSocket.Receive(b);
                    string data = UnicodeEncoding.UTF8.GetString(b, 0, count);
                    Console.WriteLine("服务端接收:" + data);
                    form1.ReciveData(data);
                }
            }
            catch {
                UsersSockets.Remove(ClientSocket);
                form1.Text = "库伦启动器     房间人数:" + (UsersSockets.Count+1).ToString();
            }
        }
        public static void send(string data)
        {
            byte[] b = UnicodeEncoding.UTF8.GetBytes(data);
            foreach (Socket socket in UsersSockets)
            {
                try
                {
                    socket.Send(b);
                }
                catch(Exception x) { Console.WriteLine(x.ToString()); }
            }
        }

        public static void CloseServer()
        {
            if (!state) return;
            send("end&&");
            socket.Close();
            socket = null;
            UsersSockets.Clear();
            Listenthread.Abort();
        }
    }
}
