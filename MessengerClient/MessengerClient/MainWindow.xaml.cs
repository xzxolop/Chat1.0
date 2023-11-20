using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Threading;

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
        private Thread th;

        public MainWindow()
        {
            InitializeComponent();
            ChatBox.IsEnabled = false;
            WriteMessageBox.IsEnabled = false;
            SendMessageButton.IsEnabled = false;
            
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
            InfoBlock.Text = "";
            if (!string.IsNullOrEmpty(ClientInfo["ip"]))
                InfoBlock.Text += "Ip: " + ClientInfo["ip"] + "\n";
            if (!string.IsNullOrEmpty(ClientInfo["port"]))
                InfoBlock.Text += "Port: " + ClientInfo["port"] + "\n";
            if (!string.IsNullOrEmpty(ClientInfo["status"]))
                InfoBlock.Text += "Status: " + ClientInfo["status"] + "\n";
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
                if (!IsConnected & !string.IsNullOrWhiteSpace(UserNameBox.Text))
                {
                    Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    SendMessageButton.IsEnabled = true;
                    WriteMessageBox.IsEnabled = true;
                    

                    if (ip!=null)
                    {
                        Client.Connect(ip, port);
                        IsConnected = true;
                        ConnectButton.Content = "Отключиться";

                        th = new Thread(delegate () { RecvMessage(); });
                        th.Start();
                    }
                }
                else if(string.IsNullOrWhiteSpace(UserNameBox.Text))
                {
                    ClientInfo["status"] = "Введите имя";
                    ShowInfo();
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
                
                SendMessageButton.IsEnabled = false;
                WriteMessageBox.IsEnabled = false;
                ChatBox.IsEnabled = false;

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
            string min = DateTime.Now.Minute.ToString();
            
            if (min.Length == 1)
            {
                min = "0" + min;
            }

            if (!string.IsNullOrWhiteSpace(WriteMessageBox.Text))
            {
                byte[] buffer = Encoding.UTF8.GetBytes("\n" + UserNameBox.Text + ": " + WriteMessageBox.Text +" | "+ DateTime.Now.Hour + ":" + min + ";;;5");
                Client.Send(buffer);
                WriteMessageBox.Clear();
            }
            
        }

        public void RecvMessage()
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
                    //receiving a message from the server
                    Client.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer);

                    var EndOfString = message.IndexOf(";;;5");

                    if (EndOfString == -1)
                    {
                        continue;
                    }

                    message = message.Substring(0, EndOfString);

                    for (int i=0; i<buffer.Length; i++)
                    {
                        buffer[i] = 0;
                    }

                    //print a message from the server
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        //message =  UserNameBox.Text + ": " + message +" | "+ DateTime.Now.Hour + ":" + DateTime.Now.Minute + "\n";
                        ChatBox.AppendText(message);
                        
                    }));

                }
                catch
                {
                    ClientInfo["status"] = "Не удалось получить сообщение от сервера";
                    ShowInfo();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
