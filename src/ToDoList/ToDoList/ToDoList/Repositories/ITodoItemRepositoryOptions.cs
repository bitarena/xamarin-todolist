namespace ToDoList.Repositories
{
    public interface ITodoItemRepositoryOptions
    {
        string GetAllUrl { get; }

        string CreateUrl { get; }

        string DeleteUrl { get; }
    }
}
