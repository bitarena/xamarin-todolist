using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Services;
using Xamarin.Forms;

namespace ToDoList.ViewModels
{
    public class CreateNewTodoItemViewModel : BaseViewModel
    {
        private readonly ITodoItemService todoItemService;
        public ICommand CreateNewTodoItemCommand { get; set; }

        public CreateNewTodoItemViewModel(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
            CreateNewTodoItemCommand = new Command(async () => await ExecuteCreateNewTodoItemCommand());
        }

        async Task ExecuteCreateNewTodoItemCommand()
        {

        }
    }
}
