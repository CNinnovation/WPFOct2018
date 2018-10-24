using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySimpleEditor
{
    public static class MyActionCommands
    {
        private static RoutedUICommand _myAction1 = new RoutedUICommand("Action1", "Action1", typeof(MyActionCommands));
        public static ICommand MyAction1 => _myAction1;
    }
}
