using BindingSample.Models;
using BindingSample.Services;
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

namespace BindingSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Book> _books;
        public MainWindow()
        {
            _books = new List<Book>(new BooksService().GetBooks());
            InitializeComponent();
            this.DataContext = Books;
        }

        public IEnumerable<Book> Books => _books;
    }
}
