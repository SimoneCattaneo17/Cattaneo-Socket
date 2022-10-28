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
    public partial class Form1 : Form {

        public static string data = null;
        byte[] bytes = new Byte[1024];
        public bool end = false;
        int min = 0, max = 0;

        Socket listener;
        Socket handler;

        IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");

        operazioni o;

        bool btn = false;

        public Form1() {
            InitializeComponent();
            o = new operazioni(this);
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

                        byte[] message = Encoding.ASCII.GetBytes(min.ToString() + ";" + max.ToString());
                        handler.Send(message);

                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf(".") > -1) {
                            break;
                        }
                    }

                    Console.WriteLine(data);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception exception) {
                Console.WriteLine("OPERA:"+exception.ToString());
            }

        }

        //probabilmente inutile
        public class operazioni {
            public Form1 f { get; set; }
            public bool end = false;
            public operazioni(Form1 f) {
                this.f = f;
            }
            public void operazione() {
                IPEndPoint localEndPoint = new IPEndPoint(f.ipAddress, 5000);

                Socket listener = new Socket(f.ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);

                    while (!end) {
                        Socket handler = listener.Accept();
                        data = null;

                        while (!end) {
                            Random random = new Random();
                            int max = random.Next(256);
                            int min = random.Next(max);
                            f.label6.Text = min.ToString();
                            f.label8.Text = max.ToString();


                            byte[] message = Encoding.ASCII.GetBytes(min.ToString() + ";" + max.ToString());
                            handler.Send(message);

                            int bytesRec = handler.Receive(f.bytes);
                            data += Encoding.ASCII.GetString(f.bytes, 0, bytesRec);
                            if (data.IndexOf(".") > -1) {
                                break;
                            }
                        }

                        //f.label7.Text = data;

                        byte[] msg = Encoding.ASCII.GetBytes(data);

                        handler.Send(msg);
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }

                }
                catch (Exception exception) {
                    Console.WriteLine(exception.ToString());
                }
            }
        }

        //togliere il timer
        private void timer1_Tick(object sender, EventArgs e) {
            label6.Text = min.ToString();
            label8.Text = max.ToString();
            label7.Text = data;
        }

        private void label7_Click(object sender, EventArgs e) {

        }
    }
}
