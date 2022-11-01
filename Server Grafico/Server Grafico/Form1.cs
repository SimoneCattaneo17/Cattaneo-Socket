using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server_Grafico {
    public partial class Server : Form {

        public static string data = null;
        byte[] bytes = new Byte[1024];
        public bool end = false;
        int min = 0, max = 0;

        Socket listener;
        Socket handler;

        IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");

        bool btn = false;

        public Server() {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            if (listener != null) {
                listener.Close();
                listener = null;
            }

            Thread t1 = new Thread(opera);

            if (btn == false) {
                btn = true;
                end = false;
                button1.Text = "Chiudi connessione";
                label2.Text = "Operativo";

                t1.Start();
            }
            else {
                btn = false;
                end = true;
                button1.Text = "Apri connessione";
                label2.Text = "Non operativo";
                min = 0;
                max = 0;
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                listener.Close();
                listener = null;
            }
        }

        private void opera() {

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (!end) {
                    handler = listener.Accept();
                    data = null;

                    while (!end) {
                        Random random = new Random();
                        max = random.Next(256);
                        min = random.Next(max);

                        label6.Text = min.ToString();
                        label8.Text = max.ToString();
                        label7.Text = "";

                        byte[] message = Encoding.ASCII.GetBytes(min.ToString() + ";" + max.ToString());
                        handler.Send(message);

                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf(".") > -1) {
                            break;
                        }
                    }

                    data = data.Remove(data.Length - 1);
                    label7.Text = data;
                    Console.WriteLine(data);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception.ToString());
            }
        }
    }
}
