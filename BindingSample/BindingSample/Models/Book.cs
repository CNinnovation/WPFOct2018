using BindingSample.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSample.Models
{
    public class Book : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Publisher { get; set; }

        public string[] Authors { get; set; }


        public override string ToString() => Title;
    }
}
