using BindingSample.Models;
using BindingSample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BindingSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> _books;
        public MainWindow()
        {
            _books = new ObservableCollection<Book>(new BooksService().GetBooks());
            InitializeComponent();
            this.DataContext = this;
            Person = new Person { FirstName = "Katharina", LastName = "Nagel" };
        }

        public IEnumerable<Book> Books => _books;

        public Person Person { get; set; }

        private void OnChangeBook(object sender, RoutedEventArgs e)
        {
            _books.First().Title = "Professional C# with .NET Core 1.0";
        }

        private void OnChangeBooks(object sender, RoutedEventArgs e)
        {
            _books.Add(new Book { Title = "Professional C# 8", Publisher = "Wrox Press" });
        }
    }
}
