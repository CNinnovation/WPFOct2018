using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace MySimpleEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ViewModel = new MainWindowViewModel(new WPFDialogService());
            InitializeComponent();
            this.DataContext = this;
        }

        public MainWindowViewModel ViewModel { get; }

        private void OnClose(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void OnOpen(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                text1.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void OnAction1(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Action 1");
        }
    }
}
