using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessengerClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private Socket Client;
        private IPAddress ip = null;
        private int port = 0;
        bool IsConnected = false;

        public MainWindow()
        {
            InitializeComponent();

            CreateClientInfo("146.0.1.0:55555");
            ParseIpFromFile();
        }
        public void ParseIpFromFile()
        {
            try
            {
                var sr = new StreamReader(@"Client_info/data_info.txt");
                string buffer = sr.ReadToEnd();
                sr.Close();
                string[] connect_info = buffer.Split(':');
                ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);
                Info.Text = "IP: " + connect_info[0] + '\n' + "Port: " + connect_info[1];
            }
            catch
            {
                Info.Text = "Info: Не удалось подключиться";
            }
        }

        public void CreateClientInfo(string IPport)
        {
            try
            {
                DirectoryInfo data = new DirectoryInfo("Client_info");
                data.Create();
                using (var sw = new StreamWriter(@"Client_info/data_info.txt"))
                {
                    sw.WriteLine(IPport);
                }
            }
            catch {
                Info.Text = "Не удалось записать в файл IPport";
            }
        }

        public void ConnectUser()
        {
            if(!IsConnected)
            {
                ConnectButton.Content = "Отключиться";
            }
        }

        public void DisconnectUser()
        {
            if(IsConnected)
            {
                ConnectButton.Content = "Подключиться";
            }
        }



    }
}
