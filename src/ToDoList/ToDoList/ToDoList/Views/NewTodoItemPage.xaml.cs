using System;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTodoItemPage : ContentPage
	{
        public TodoItem Item { get; set; }

        public NewTodoItemPage ()
		{
			InitializeComponent ();

            Item = new TodoItem();

            BindingContext = this;
        }

        async void CreateNewTodoItem_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTodoItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}