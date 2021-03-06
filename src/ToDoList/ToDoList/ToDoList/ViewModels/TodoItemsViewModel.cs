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
        private bool isRefreshing;
        public ObservableCollection<TodoItem> TodoItems { get; set; }
        public ICommand FetchTodoItemsCommand { get; set; }
        public ICommand DeleteTodoItemCommand { get; set; }
        public ICommand ToggleIsCompleteCommand { get; set; }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public TodoItemsViewModel(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
            TodoItems = new ObservableCollection<TodoItem>();
            FetchTodoItemsCommand = new Command(async () => await ExecuteFetchTodoItemsCommand());
            DeleteTodoItemCommand = new Command(async (item) => await ExecuteDeleteTodoItemCommand((TodoItem)item));
            ToggleIsCompleteCommand = new Command(async (item) => await ExecuteToggleIsCompleteCommand((TodoItem)item));

            // TODO: Remove hardcoded
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

        async Task ExecuteToggleIsCompleteCommand(TodoItem item)
        {
            try
            {
                var updatedItem = await todoItemService.ToggleIsComplete(item);
                var itemIndex = TodoItems.IndexOf(item);
                TodoItems[itemIndex] = updatedItem;
            }
            catch (Exception e)
            {
                // TODO: Add alert
                Debug.WriteLine(e.Message);
            }
        }

        async Task ExecuteDeleteTodoItemCommand(TodoItem item)
        {
            try
            {
                await todoItemService.Delete(item);
                TodoItems.Remove(item);

                // TODO: Remove hardcoded
                MessagingCenter.Send(this, "DeletedTodoItem", item);
            }
            catch (Exception e)
            {
                // TODO: Add alert
                Debug.WriteLine(e.Message);
            }
        }

        async Task ExecuteFetchTodoItemsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            IsRefreshing = false;

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
                IsRefreshing = false;
            }
        }
    }
}
