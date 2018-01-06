using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTodoItemPage : ContentPage
	{
		public NewTodoItemPage ()
		{
			InitializeComponent ();
		}
    }
}