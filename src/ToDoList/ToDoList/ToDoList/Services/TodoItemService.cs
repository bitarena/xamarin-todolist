using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Services
{
    public class TodoItemService : ITodoItemService
    {
        readonly ITodoItemRepository todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository ?? throw new ArgumentNullException("todoItemRepository");
        }

        public async Task<TodoItem> Create(TodoItem item)
        {
            try
            {
                var result = await todoItemRepository.Create(item);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            try
            {
                var result = await todoItemRepository.GetAll();
                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
