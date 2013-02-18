using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimerDispatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _timer = new Timer(1000);
            _timer.Elapsed += (sender, args) => SignalRProxyConnection.SendServerTime(DateTime.Now);
        }

        private void btnStartTimer_Click_1(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void btnStopTimer_Click_1(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}
