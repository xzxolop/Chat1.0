using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace MessengerClient
{
    /// <summary>
    /// Логика взаимодействия для Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public MainWindow mainWindow; 
        public Options()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CreateFileInfo(IpBox.Text);
            mainWindow.ParseIpFromFile();
            mainWindow.ShowInfo();

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyButton_Click(sender, e);
            this.Close();
        }
    }
}
