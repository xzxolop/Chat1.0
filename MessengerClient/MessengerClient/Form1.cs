using System.Net;
using System.Net.Sockets;


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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}