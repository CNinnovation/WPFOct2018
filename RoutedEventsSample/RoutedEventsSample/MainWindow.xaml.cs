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

namespace RoutedEventsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler MyEvent;

        private EventHandler _myEvent1;
        public event EventHandler MyEvent1
        {
            add
            {
                _myEvent1 += value;
            }
            remove
            {
                _myEvent1 -= value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnInnerButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("inner button");
        }

        private void OnOuterButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("outer button");
            e.Handled = true;
        }

        private void OnButtonClickInStackPanel(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button within stackpanel");
        }
    }
}
