using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAll();

        Task<TodoItem> Create(TodoItem item);
    }
}
