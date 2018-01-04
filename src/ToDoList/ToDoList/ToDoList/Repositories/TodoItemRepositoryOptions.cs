namespace ToDoList.Repositories
{
    public class TodoItemRepositoryOptions : ITodoItemRepositoryOptions
    {
        private const string BaseUrl = "http://localhost:1000/api/todo";

        public string GetAllUrl => $"{BaseUrl}";
    }
}
