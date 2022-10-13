﻿using System;
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

namespace SimpleSocketClient {
    public partial class Form1 : Form {

        public int min, max;
        Socket socket;
        byte[] bytes;

        public Form1() {
            InitializeComponent();

            StartClient(this);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        public static void StartClient(Form1 f1) {
            f1.bytes = new byte[1024];

            try {
                IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

                f1.socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try {
                    f1.socket.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        f1.socket.RemoteEndPoint.ToString());

                    f1.min = f1.socket.Receive(f1.bytes);
                    f1.min = int.Parse(Encoding.ASCII.GetString(f1.bytes, 0, f1.min));
                    Console.WriteLine("min: " + f1.min);

                    f1.max = f1.socket.Receive(f1.bytes);
                    f1.max = int.Parse(Encoding.ASCII.GetString(f1.bytes, 0, f1.max));
                    Console.WriteLine("max: " + f1.max);

                    f1.label_min.Text = f1.min.ToString();
                    f1.label_max.Text = f1.max.ToString();

                }
                catch (ArgumentNullException ane) {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se) {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e) {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public static void invia(Form1 f1) {

        }

        private void button1_Click(object sender, EventArgs e) {
            int invio;
            if (textBox_invio.Text != null && Int32.TryParse(textBox_invio.Text, out invio) && int.Parse(textBox_invio.Text) < max && int.Parse(textBox_invio.Text) > min) {
                byte[] msg = Encoding.ASCII.GetBytes(textBox_invio.Text + ".");

                int bytesSent = socket.Send(msg);

                int bytesRec = socket.Receive(bytes);
                Console.WriteLine("Number generated: {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            else {
                MessageBox.Show("Input errato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_invio.Text = null;
            }
        }
    }
}