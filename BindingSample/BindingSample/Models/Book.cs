using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSample.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Publisher { get; set; }

        public string[] Authors { get; set; }
        public override string ToString() => Title;
    }
}
