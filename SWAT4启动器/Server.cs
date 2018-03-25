using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace SWAT4启动器
{
    public partial class Server : UserControl
    {
        public static ManualResetEvent allDone =
    new ManualResetEvent(false);
        public Server(string Servername,string IP,string MAP,string PLAYERS,string MODE,string MOD,string VERSION)
        {
            InitializeComponent();
            ServerName.Text += Servername;
            ip.Text += IP;
            map.Text += MAP;
            players.Text += PLAYERS;
            mode.Text += MODE;
            mod.Text += MOD;
            version.Text += VERSION;
        }
        Socket socket;
        int a =0;
        int b = 0;
        private void Server_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(connt);
            th.Start();
        }
        void connt()
        {
            try
            {
                allDone.Reset();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipa = IPAddress.Parse((Regex.Split(ip.Text, ":")[0]).Replace("IP ",string.Empty));
                Console.WriteLine(ipa.Address);
                a = Environment.TickCount;
                socket.BeginConnect(ipa, 80, new AsyncCallback(ConnectCallback), socket);
                allDone.WaitOne(3000);
                if (!socket.Connected)
                {
                    ping.Text = "延时 超时";
                    ping.ForeColor = Color.Red;
                }
            }
            catch
            {
                ping.Text = "/";
            }
        }
        public  void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();
                if (socket.Connected)
                {
                    b = Environment.TickCount;
                    Socket s = (Socket)ar.AsyncState;
                    ping.Text = "延时 " + (b - a)/3 + "ms";
                    if ((b - a) <= 300)
                        ping.ForeColor = Color.LightGreen;
                    else if ((b - a) > 300 && b - a < 600)
                        ping.ForeColor = Color.Yellow;
                    else
                        ping.ForeColor = Color.Red;
                    s.EndConnect(ar);
                }
            }
            catch { }
        }

        private void players_TextChanged(object sender, EventArgs e)
        {

        }

        private void version_TextChanged(object sender, EventArgs e)
        {

        }

        private void mod_TextChanged(object sender, EventArgs e)
        {

        }

        private void mode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
