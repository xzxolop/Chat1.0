using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessengerClient
{
    public partial class Form1 : Form
    {
        static private Socket Client;
        private IPAddress ip = null;
        private int port = 0;

        public Form1()
        {
            InitializeComponent();

            ChatTextBox.Enabled = false;
            WriteMessageTextBox.Enabled = false;
            send.Enabled = false;

            try
            {
                using var sr = new StreamReader(@"Client_info/data_info.txt");
                string buffer = sr.ReadToEnd();
                string[] connect_info = buffer.Split(':');
                ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);

                info.ForeColor = Color.Green;
                info.Text = "Настройки: \n IP Сервера: " + connect_info[0] + "\n Порт сервера: " + connect_info[1];


            }
            catch (Exception ex)
            {
                info.ForeColor= Color.Red;
                info.Text = "Настройки не найдены!";
                Options options = new Options();
            }

        }



        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        void SendMessage(string message)
        {
            if (message!="" && message!=" ")
            {
                byte[] buffer = new byte[1024];
                buffer = Encoding.UTF8.GetBytes(message);
                Client.Send(buffer);
            }
        }

        void RecvMessage()
        {
            byte[] buffer = new byte[1024];
            for (int i = 0; i<buffer.Length; i++)
            {
                buffer[i]=0;
            }
            while (true)
            {
                try
                {
                    Client.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer);
                    int count = message.IndexOf(";;;5"); //конец сообщения
                    if (count == -1)
                    {
                        continue;
                    }

                    string ClearMessage = "";
                    for (int i = 0; i < count; i++)
                    {
                        ClearMessage += message[i];
                    }

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        ChatTextBox.AppendText(ClearMessage);
                    });
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void Connect_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" &&  textBox1.Text!=" ")
            {
                send.Enabled = true;
                WriteMessageTextBox.Enabled=true;
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (ip!=null)
                {
                    Client.Connect(ip, port);
                }

            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            SendMessage("\n" + textBox1 + ": " + WriteMessageTextBox.Text + ";;;5");
            WriteMessageTextBox.Clear();
        }
    }
}