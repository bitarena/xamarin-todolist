﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.Views;
using Xamarin.Forms;

namespace ToDoList.ViewModels
{
    public class TodoItemsViewModel : BaseViewModel
    {
        private readonly ITodoItemService todoItemService;
        public ObservableCollection<TodoItem> TodoItems { get; set; }
        public ICommand FetchTodoItemsCommand { get; set; }

        public TodoItemsViewModel(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
            TodoItems = new ObservableCollection<TodoItem>();
            FetchTodoItemsCommand = new Command(async () => await ExecuteFetchTodoItemsCommand());

            MessagingCenter.Subscribe<NewTodoItemPage, TodoItem>(this, "AddTodoItem", async (obj, item) => await AddTodoItem(item));
        }

        async Task AddTodoItem(TodoItem item)
        {
            try
            {
                var addedItem = await todoItemService.Create(item);
                TodoItems.Add(addedItem);
            }
            catch (Exception ex)
            {
                // TODO: show alert
                Debug.WriteLine(ex);
            }
        }

        async Task ExecuteFetchTodoItemsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            
            try
            {
                TodoItems.Clear();
                var todoItems = await todoItemService.GetAll();
                foreach (var item in todoItems)
                {
                    TodoItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                // TODO: show alert
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
