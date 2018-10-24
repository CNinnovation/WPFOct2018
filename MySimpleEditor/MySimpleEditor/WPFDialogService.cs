using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MySimpleEditor
{
    public class WPFDialogService : IDialogService
    {
        public Task ShowDialogAsync(string message)
        {
            MessageBox.Show(message);
            return Task.CompletedTask;
        }
    }
}
