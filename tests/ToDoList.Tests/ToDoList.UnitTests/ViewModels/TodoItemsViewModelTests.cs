﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ToDoList.Services;
using ToDoList.ViewModels;

namespace ToDoList.UnitTests.ViewModels
{
    [TestClass]
    public class TodoItemsViewModelTests
    {
        ITodoItemService todoItemService;

        [TestInitialize]
        public void TestInitialize()
        {
            todoItemService = Substitute.For<ITodoItemService>();
        }

        [TestMethod]
        public void FetchTodoItemsCommandIsNotNull()
        {
            // Arrange
            var sut = new TodoItemsViewModel(todoItemService);

            // Assert
            Assert.IsNotNull(sut.FetchTodoItemsCommand);
        }

    }
}
