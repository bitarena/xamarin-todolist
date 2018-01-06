using Autofac;
using System;
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

		public TodoItemsPage()
		{
			InitializeComponent();

            var todoItemService = IoC.IoCRegister.Container.Resolve<ITodoItemService>();

            BindingContext = viewModel = new TodoItemsViewModel(todoItemService);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTodoItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.TodoItems.Count == 0)
                viewModel.FetchTodoItemsCommand.Execute(null);
        }
    }
}