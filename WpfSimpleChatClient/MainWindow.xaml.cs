using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace WpfSimpleChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private async void Start()
        {
            var hubConnection = new HubConnection("http://localhost:50308/");
            var chatHub = hubConnection.CreateHubProxy("chatHub");

            chatHub.On<string>("sendMessage", (message) => Dispatcher.Invoke(DispatcherPriority.Normal, new Action<string>(AddMessage), message));

            await hubConnection.Start();

            Send.Click += (sender, args) => chatHub.Invoke("Send", "WPF said:" + Message.Text);
        }

        private void AddMessage(string obj)
        {
            Messages.Text += Environment.NewLine + obj;
        }
    }
}