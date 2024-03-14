using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheDerpening.Data;
using TheDerpening.Data.Models;

namespace TheDerpeningTesting
{
    public class IntegrationTests
    {
        ItemService service;

        [SetUp]
        public void Setup()
        {

            string connection = "host=test-my_postgres_db:5432;Database=mydatabase;Username=myusername;Password=mypassword;";
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var ItemLogger = loggerFactory.CreateLogger<ItemService>();

            DbContextOptions<ListDbContext> options = new DbContextOptionsBuilder<ListDbContext>()
            .UseNpgsql(connection)
            .Options;

            ListDbContext dbContext = new ListDbContext(options);
            service = new(ItemLogger, dbContext);

        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }

        [Test]
        public async Task Test2Async()
        {
            TodoListItem firstitem = new TodoListItem { Title = "DERP" };
            List<TodoListItem> list = new List<TodoListItem>();
            await service.Add(firstitem);
            list = (await service.GetAll()).ToList();
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].Id, Is.EqualTo(1));

        }
    }
}
