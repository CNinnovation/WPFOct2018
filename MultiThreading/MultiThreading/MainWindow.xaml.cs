using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MultiThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private object _syncSomeData = new object();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SomeData.Add("init");

            BindingOperations.EnableCollectionSynchronization(SomeData, _syncSomeData);

            Task t = SomeLoopAsync();

            //var t1 = new Task(async () =>
            //{
            //    int i = 0;
            //    while (true)
            //    {
            //        await Task.Delay(500);
            //        SomeText = $"value {i++}";
            //        text2.Text = $"value {i}";
            //        //     SomeData.Add($"value {i}");
            //    }
            //}, TaskCreationOptions.LongRunning);
            //t1.ConfigureAwait(false);
            //t1.Start();                      
        }

        private string _someText;

        public string SomeText
        {
            get { return _someText; }
            set
            {
                if (_someText != value)
                {
                    _someText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeText)));
                }
            }
        }

        public ObservableCollection<string> SomeData { get; } = new ObservableCollection<string>();


        public event PropertyChangedEventHandler PropertyChanged;

        public Task SomeLoopAsync()
        {
            return Task.Factory.StartNew(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(1000);
                    SomeText = $"value {++i}";

                    lock (_syncSomeData)
                    {
                        SomeData.Add($"value {i}");
                    }

                    //    Dispatcher.Invoke(() => {
                    //  //  text2.Text = $"value {i}";
                    //    SomeData.Add($"value {i}");
                    //});
                    //text2.Text = $"value {i}";
                    //SomeData.Add($"value {i}");
                }
            }, TaskCreationOptions.LongRunning);

        }
    }
}
