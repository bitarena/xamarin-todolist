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
        public async Task WillErrorWhenItemNotFound()
        {
            // Arrange
            var key = Guid.NewGuid().ToString();

            // Act
            await sut.Delete(key);
        }
    }
}
