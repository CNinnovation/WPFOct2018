﻿namespace BooksDemo.Models
{
    public class Book : BindableObject
    {
        public Book(string title, string publisher, string isbn, params string[] authors)
        {
            Title = title;
            Publisher = publisher;
            Isbn = isbn;
            Authors = authors;
        }
        public Book()
          : this("unknown", "unknown", "unknown")
        {
        }


        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        private string _publisher;
        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                SetProperty(ref _publisher, value);
            }
        }
        private string _isbn;
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                SetProperty(ref _isbn, value);
            }
        }

        public string[] Authors { get; }


        public override string ToString() => Title;

    }
}
