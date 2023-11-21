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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Options
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateFileInfo(string IPport)
        {
            DirectoryInfo data = new DirectoryInfo("Client_info");
            data.Create();
            using (var sw = new StreamWriter(@"Client_info/data_info.txt"))
            {
                sw.WriteLine(IPport);
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFileInfo(IpBox.Text);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFileInfo(IpBox.Text);
            this.Hide();

        }
    }
}
