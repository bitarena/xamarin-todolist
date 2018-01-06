using Autofac;
using ToDoList.Services;
using ToDoList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoItemsPage : ContentPage
	{
        TodoItemsViewModel viewModel;

		public TodoItemsPage ()
		{
			InitializeComponent();

            var todoItemService = IoC.IoCRegister.Container.Resolve<ITodoItemService>();

            BindingContext = viewModel = new TodoItemsViewModel(todoItemService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.TodoItems.Count == 0)
                viewModel.FetchTodoItemsCommand.Execute(null);
        }
    }
}