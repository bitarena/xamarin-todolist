using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repositories;
using ToDoList.Services;

namespace ToDoList.UnitTests.Services
{
    [TestClass]
    public class TodoItemServiceTests
    {
        ITodoItemService sut;
        ITodoItemRepository todoItemRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            todoItemRepository = Substitute.For<ITodoItemRepository>();
            sut = new TodoItemService(todoItemRepository);
        }

        [TestMethod]
        public async Task WillGetAllItems()
        {
            // Arrange
            var mockItems = new List<TodoItem>
            {
                new TodoItem
                {
                    Name = "mock name",
                    IsComplete = false,
                },
            };
            todoItemRepository.GetAll().Returns(mockItems);

            // Act
            var actual = await sut.GetAll();

            // Assert
            Assert.AreEqual(actual.First(), mockItems.First());
        }

        [TestMethod]
        public async Task WillCreateNewItem()
        {
            // Arrange
            var item = new TodoItem
            {
                Name = Guid.NewGuid().ToString(),
                IsComplete = false,
            };
            todoItemRepository.Create(item).Returns(true);

            // Act
            var actual = await sut.Create(item);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
