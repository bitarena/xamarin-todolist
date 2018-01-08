using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Converters;
using Xamarin.Forms;

namespace ToDoList.UnitTests.Converters
{
    [TestClass]
    public class StatusToCharConverterTests
    {
        IValueConverter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new StatusToCharConverter();
        }

        [TestMethod]
        public void WillConvertStatusToCharWhenStatusIsCompleted()
        {
            // Arrange
            var isComplete = true;
            var expected = "v";

            // Act
            var actual = sut.Convert(isComplete, null, null, null);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void WillConvertStatusToCharWhenStatusIsNotCompleted()
        {
            // Arrange
            var isComplete = false;
            var expected = string.Empty;

            // Act
            var actual = sut.Convert(isComplete, null, null, null);

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
