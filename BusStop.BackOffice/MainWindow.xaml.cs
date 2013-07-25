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
using BusStop.Sales.InternalMessages;

namespace BusStop.BackOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Example of full duplex messaging, the cancel order message is sent to the Backend, then a callback is registered for a command status response
            App.Bus.Send(new CancelOrder
            {
                OrderId = new Guid()
            })
                .Register<CommandStatus>(status =>
                {
                    textBox1.Text = status.ToString();
                });
        }

   
    }
}
