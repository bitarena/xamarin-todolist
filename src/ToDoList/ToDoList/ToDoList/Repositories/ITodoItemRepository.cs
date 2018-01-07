using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface ITodoItemRepository
    {
        /// <summary>
        /// Retrieves all the items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Exception</exception>
        Task<IEnumerable<TodoItem>> GetAll();

        /// <summary>
        /// Stores a new item in the list
        /// </summary>
        /// <param name="item">The item to add to the list</param>
<<<<<<< HEAD
        /// <returns></returns>
        Task<bool> Create(TodoItem item);

        /// <summary>
        /// Deletes the item with a specified id
        /// </summary>
        /// <param name="id">The identifier of the item to be removed</param>
        /// <exception cref="Exception">Exception</exception>
        Task Delete(string id);
=======
>>>>>>> master
    }
}
