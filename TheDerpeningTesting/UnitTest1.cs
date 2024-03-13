using TheDerpening.Data;
using TheDerpening.Data.Models;

namespace TheDerpeningTesting
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }

        [Test]
        public void NewItemTesting()
        {
            TodoListItem Testitem = new();
            Testitem.Title = "Test";
            Assert.That(Testitem.Title, Is.EqualTo("Test"));
            Assert.That(Testitem.IsTaskCompleted, Is.False);
        }

        [Test]
        public void NewItemPlus()
        {
            TodoListItem Testitem = new();
            Testitem.Title = "Test";
            Testitem.IsTaskCompleted = true;

            Assert.That(Testitem.Title, Is.EqualTo("Test"));
            Assert.That(Testitem.IsTaskCompleted, Is.True);
        }
    }
}
