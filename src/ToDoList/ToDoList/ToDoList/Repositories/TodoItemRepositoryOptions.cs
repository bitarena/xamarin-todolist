namespace ToDoList.Repositories
{
    public class TodoItemRepositoryOptions : ITodoItemRepositoryOptions
    {
        private const string BaseUrl = "http://192.168.1.108:1000/api/todo";

        public string GetAllUrl => BaseUrl;

        public string CreateUrl => BaseUrl;

        public string DeleteUrl => $"{BaseUrl}/{{0}}";
    }
}
