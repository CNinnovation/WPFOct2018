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

namespace VSMSample
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

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(rootGrid, "EditMode", false);
        }

        private void OnRead(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(rootGrid, "ReadMode", false);
        }
    }
}
