using Autofac;
using ToDoList.Repositories;
using ToDoList.Services;

namespace ToDoList.IoC
{
    public static class IoCRegister
    {
        private static bool isRegistered = false;

        public static IContainer Container { get; set; }

        public static void Register()
        {
            if (!isRegistered)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<TodoItemRepositoryOptions>().As<ITodoItemRepositoryOptions>();
                builder.RegisterType<TodoItemRepository>().As<ITodoItemRepository>();
                builder.RegisterType<TodoItemService>().As<ITodoItemService>();

                Container = builder.Build();

                isRegistered = true;
            }
        }
    }
}
