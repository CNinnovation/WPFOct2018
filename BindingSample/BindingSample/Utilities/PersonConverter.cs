﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BindingSample.Utilities
{
    public class PersonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string p = parameter.ToString();
            if (p == "FirstLast")
            {
                return $"{values[0]} {values[1]}";
            }
            else
            {
                return $"{values[1]}, {values[0]}";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
