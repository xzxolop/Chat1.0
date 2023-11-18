using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;


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
        Dictionary<string, string> ClientInfo;


        public MainWindow()
        {
            InitializeComponent();
            
            InitializeClientInfo();
            CreateFileInfo("127.0.0.1:7770");
            ParseIpFromFile();
        }

        private void InitializeClientInfo()
        {
            ClientInfo = new Dictionary<string, string>();
            ClientInfo["ip"] = "";
            ClientInfo["port"] = "";
            ClientInfo["status"] = "";
        }

        private void ShowInfo()
        {
            InfoBlock.Text = "Info:";
            if (!string.IsNullOrEmpty(ClientInfo["ip"]))
                InfoBlock.Text += "\n Ip: " + ClientInfo["ip"];
            if (!string.IsNullOrEmpty(ClientInfo["port"]))
                InfoBlock.Text += "\n Port: " + ClientInfo["port"];
            if (!string.IsNullOrEmpty(ClientInfo["status"]))
                InfoBlock.Text += "\n Status: " + ClientInfo["status"];
        }

        

        private void ParseIpFromFile()
        {
            try
            {
                var sr = new StreamReader(@"Client_info/data_info.txt");
                string buffer = sr.ReadToEnd();
                sr.Close();
                string[] connect_info = buffer.Split(':');
                ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);
                ClientInfo["ip"] = ip.ToString();
                ClientInfo["port"] = port.ToString();
                ShowInfo();
            }
            catch
            {
                ClientInfo["status"] = "Не удалось считать IP из файла";
                ShowInfo();
            }
        }

        private void CreateFileInfo(string IPport)
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
                ClientInfo["status"] = "Не удалось записать в файл IPport";
                ShowInfo();
            }
        }

        private void ConnectUser()
        {
            try
            {
                if (!IsConnected)
                {
                    Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    SendMessageButton.IsEnabled = true;
                    WriteMessageBox.IsEnabled = true;

                    if (ip!=null)
                    {
                        Client.Connect(ip, port);
                        IsConnected = true;
                        ConnectButton.Content = "Отключиться";
                    }
                }
            }
            catch {
                ClientInfo["status"] = "Не удалось подключиться к серверу";
                ShowInfo();
            }
        }

        private void DisconnectUser()
        {
            if(IsConnected)
            {
                Client.Disconnect(false);
                IsConnected = false;
                ConnectButton.Content = "Подключиться";

            }
        }

        public void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(WriteMessageBox.Text);
            Client.Send(buffer);
        }
    }
}
