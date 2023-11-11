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

            richTextBox1.Enabled = false;
            richTextBox2.Enabled = false;
            button1.Enabled = false;

            try
            {
                using var sr = new StreamReader(@"Client_info/data_info.txt");
                string buffer = sr.ReadToEnd();
                string[] connect_info = buffer.Split(':');
                ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);

                label4.ForeColor = Color.Green;
                label4.Text = "Настройки: \n IP Сервера: " + connect_info[0] + "\n Порт сервера: " + connect_info[1];


            }
            catch (Exception ex)
            {
                label4.ForeColor= Color.Red;
                label4.Text = "Настройки не найдены!";
                Options options = new Options();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }
    }
}