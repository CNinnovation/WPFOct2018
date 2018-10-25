using BindingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSample.Services
{
    public class BooksService
    {
        public IEnumerable<Book> GetBooks() => new List<Book>()
            {
            new Book() { Title = "Professional C# 6", Publisher = "Wrox Press" },
            new Book { Title = "Enterprise Services", Publisher = "AWL" },
            new Book { Title = "Professional C# 7 and .NET Core 2.0", Publisher = "Wrox Press" },
            new Book {Title = "Beginning Visual C#", Publisher = "Wrox Press", Authors = new string[] {"Karli Watson", "christian Nagel", "Jay Glynn"}}

        };
    }
}
