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
    }
}
