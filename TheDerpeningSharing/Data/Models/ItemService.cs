
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TheDerpening.Data.Models
{
    public class ItemService
    {
        private readonly ILogger<ItemService> _logger;
        private ListDbContext _listDbContext;
        public ItemService(ILogger<ItemService> logger, ListDbContext listDbContext)
        {
            _logger = logger;
            _listDbContext = listDbContext;
        }


        public async Task<IEnumerable<TodoListItem>> GetAll()
        {
            using var activity = DerpingMonitor.source.StartActivity("Getting all derp things");
            activity?.SetTag("DerpingAttempt", 1);
            DerpingMonitor.countAdd.Add(1);
            var mylist = await _listDbContext.Todos.ToListAsync();
            List<TodoListItem> list = new List<TodoListItem>();
            list = mylist;
            activity?.Stop();
            return list;

        }

        public async Task Add(TodoListItem obj)
        {
            using var activity = DerpingMonitor.source.StartActivity("Getting a derp thing");
            activity?.SetTag("DerpAdding", 2);
            _listDbContext.Todos.Add(obj);
            await _listDbContext.SaveChangesAsync();
            activity?.Stop();

        }

        public async Task Delete(int id)
        {
            var itemtoberemoved = await _listDbContext.Todos.Where(T => T.Id == id).FirstOrDefaultAsync();
            if (itemtoberemoved != null) { _listDbContext.Todos.Remove(itemtoberemoved); }
            await _listDbContext.SaveChangesAsync();
        }

        public async Task<TodoListItem> Get(int id)
        {
            var itemtobefound = await _listDbContext.Todos.Where(T => T.Id == id).FirstOrDefaultAsync();
            if (itemtobefound == null) { itemtobefound = new TodoListItem(); }
            return itemtobefound;
        }


        public async Task Update(TodoListItem obj)
        {
            var itemtobeupdated = await _listDbContext.Todos.Where(T => T.Id == obj.Id).FirstOrDefaultAsync();
            if (itemtobeupdated != null)
            {
                itemtobeupdated.IsTaskCompleted = obj.IsTaskCompleted;
                itemtobeupdated.Title = obj.Title;
            }
            await _listDbContext.SaveChangesAsync();

        }
    }
}
