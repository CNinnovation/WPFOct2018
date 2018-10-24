using System.Threading.Tasks;

namespace MySimpleEditor
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string message);
    }
}