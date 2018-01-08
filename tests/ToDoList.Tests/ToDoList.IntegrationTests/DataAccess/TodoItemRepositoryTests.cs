using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.IntegrationTests.DataAccess
{
    [TestClass]
    public class TodoItemRepositoryTests
    {
        ITodoItemRepository sut;
        ITodoItemRepositoryOptions options;

        [TestInitialize]
        public void TestInitialize()
        {
            // Note: I am not using a DI container to simplify things
            options = new TodoItemRepositoryOptions();
            sut = new TodoItemRepository(options);
        }

        [TestMethod]
        public async Task WillConnectWithRepository()
        {
            // Arrange

            // Act
            var actual = await sut.GetAll();

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task WillCreateNewItem()
        {
            // Arrange
            var item = new TodoItem
            {
                Name = "test",
                IsComplete = false,
            };

            // Act
            var actual = await sut.Create(item);

            // Assert
            Assert.IsNotNull(actual.Key);
        }

        // TODO: Add more tests

        [TestMethod]
        public async Task WillDeleteExistingItem()
        {
            // Arrange
            var item = new TodoItem
            {
                Name = "test delete",
                IsComplete = false
            };

            var addedItem = await sut.Create(item);

            // Act
            await sut.Delete(addedItem.Key);

            var items = await sut.GetAll();

            // Assert
            Assert.IsFalse(items.Any(x => x.Key == item.Key));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task WillErrorWhenDeletesItemNotFound()
        {
            // Arrange
            var key = Guid.NewGuid().ToString();

            // Act
            await sut.Delete(key);
        }

        [TestMethod]
        public async Task WillUpdateStatusWhenItemExists()
        {
            // Arrange
            var item = new TodoItem
            {
                Name = "update test",
                IsComplete = false,
            };

            var savedItem = await sut.Create(item);
            savedItem.IsComplete = true;

            // Act

            await sut.Update(savedItem.Key, savedItem);
            var items = await sut.GetAll();

            // Assert
            Assert.IsTrue(items.Where(x => x.Key == savedItem.Key && x.IsComplete).Count() == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task WillErrorWhenUpdateItemNotFound()
        {
            // Arrange
            var key = Guid.NewGuid().ToString();

            var item = new TodoItem
            {
                Key = key,
                Name = "update test",
                IsComplete = true,
            };

            // Act
            await sut.Update(item.Key, item);
        }

        // TODO: Add more tests
    }
}
