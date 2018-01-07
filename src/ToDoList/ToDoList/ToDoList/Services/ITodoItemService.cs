using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITodoItemService
    {
        // TODO: add documentation
        Task<IEnumerable<TodoItem>> GetAll();

        Task<bool> Create(TodoItem item);

        /// <summary>
        /// Deletes the item
        /// </summary>
        /// <param name="item">The item to be removed</param>
        /// exception cref="Exception">Exception</exception>
        Task Delete(TodoItem item);
    }
}
