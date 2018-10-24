using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySimpleEditor
{
    public class MainWindowViewModel
    {
        private readonly IDialogService _dialogService;
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            Action2 = new DelegateCommand(OnAction2Async);
        }

        public ICommand Action2 { get; }

        private async void OnAction2Async()
        {
            await _dialogService.ShowDialogAsync("Action 2");
        }
    }
}
