using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread th = new Thread(Refresh);
            th.IsBackground = true;
            th.Start();

        }
        public void Refresh()
        {
            while (true)
            {
                
                this.Dispatcher.Invoke(() => 
                {
                    lvMain.ItemsSource = Process.GetProcesses().ToList();
                    lvMain.SelectedIndex = SlectionIndex;
                });
               
                Thread.Sleep(400);
            }

        }
        public int SlectionIndex = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process process = lvMain.SelectedItem as Process;
            process.Kill();
        }

        private void lvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvMain.SelectedIndex!=-1)
            SlectionIndex = lvMain.SelectedIndex;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
