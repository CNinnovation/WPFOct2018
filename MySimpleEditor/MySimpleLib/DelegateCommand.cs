using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySimpleEditor
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _action;
        private Func<bool> _canExecute;

        public DelegateCommand(Action action, Func<bool> canExecute)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute;
        }

        public DelegateCommand(Action action)
            : this(action, null) { }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
        public void Execute(object parameter) => _action();
    }
}
