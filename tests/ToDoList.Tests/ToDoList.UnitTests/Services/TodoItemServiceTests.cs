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
            var key = Guid.NewGuid().ToString();
            var item = new TodoItem
            {
                Name = "test",
                IsComplete = false,
            };

            var expected = item;
            expected.Key = key;

            todoItemRepository.Create(item).Returns(expected);

            // Act
            var actual = await sut.Create(item);

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public async Task WillDeleteOneItem()
        {
            // Arrange
            var key = Guid.NewGuid().ToString();
            var item = new TodoItem
            {
                Name = "test",
                IsComplete = true,
            };

            var addedItem = item;
            addedItem.Key = key;

            todoItemRepository.Create(item).Returns(addedItem);

            todoItemRepository.GetAll().Returns(new List<TodoItem>());

            // Act
            await sut.Delete(item);
            var items = await sut.GetAll();

            // Assert
            Assert.IsFalse(items.Any(x => x.Key == item.Key));
        }
    }
}
