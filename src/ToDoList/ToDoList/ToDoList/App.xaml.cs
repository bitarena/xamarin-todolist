using ToDoList.IoC;
using ToDoList.Views;
using Xamarin.Forms;

namespace ToDoList
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            InitializeDependencies();

            MainPage = new NavigationPage(new TodoItemsPage());
        }

        private void InitializeDependencies()
        {
            IoCRegister.Register();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
