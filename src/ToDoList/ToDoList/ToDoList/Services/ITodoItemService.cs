using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    // TODO: Improve doc
    public interface ITodoItemService
    {
        // TODO: add documentation
        Task<IEnumerable<TodoItem>> GetAll();

        // TODO: add documentation
        Task<TodoItem> Create(TodoItem item);

        /// <summary>
        /// Deletes the item
        /// </summary>
        /// <param name="item">The item to be removed</param>
        /// exception cref="Exception">Exception</exception>
        Task Delete(TodoItem item);

        /// <summary>
        /// Updates an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Update(TodoItem item);
    }
}
