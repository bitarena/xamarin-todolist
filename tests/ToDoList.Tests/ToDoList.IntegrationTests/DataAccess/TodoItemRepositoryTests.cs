using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repositories;
using System.Linq;

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
                Name = Guid.NewGuid().ToString(),
                IsComplete = false,
            };

            // Act
            var actual = await sut.Create(item);
            var allItems = await sut.GetAll();

            // Assert
            Assert.IsTrue(actual);
            Assert.IsTrue(allItems.Where(x => x.Name == item.Name).Count() == 1);
        }
    }
}
