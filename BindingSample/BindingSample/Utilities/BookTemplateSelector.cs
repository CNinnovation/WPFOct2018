using BindingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BindingSample.Utilities
{
    public class BookTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WroxTemplate { get; set; }
        public DataTemplate DefaultBookTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate selectedTemplate = null;

            if (item is Book b)
            {
                switch (b.Publisher)
                {
                    case "Wrox Press":
                        selectedTemplate = WroxTemplate;
                        break;
                    default:
                        selectedTemplate = DefaultBookTemplate;
                        break;
                }
            }

            return selectedTemplate;
        }
    }
}
