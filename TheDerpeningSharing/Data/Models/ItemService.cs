
using Microsoft.EntityFrameworkCore;

namespace TheDerpening.Data.Models {
    public class ItemService  {

        private readonly ILogger<ItemService> _logger;
        private ListDbContext _listDbContext;
        public ItemService(ILogger<ItemService> logger, ListDbContext listDbContext) {
            _logger = logger;
            _listDbContext = listDbContext; 
        }
        
        
        public async Task<IEnumerable<TodoListItem>> GetAll() {
            var mylist = await _listDbContext.Todos.ToListAsync();
            List<TodoListItem> list = new List<TodoListItem>();
            list = mylist;

            return list;
        }
        
        public async Task Add(TodoListItem obj) {

            _listDbContext.Todos.Add(obj);
            await _listDbContext.SaveChangesAsync();
           // save to context


        }

        public async Task Delete(int id) {
            var itemtoberemoved = await _listDbContext.Todos.Where(T => T.Id == id).FirstOrDefaultAsync();
            _listDbContext.Todos.Remove(itemtoberemoved);
            await _listDbContext.SaveChangesAsync();
        }

        public async Task<TodoListItem> Get(int id) {
            var itemtobefound = await _listDbContext.Todos.Where(T => T.Id == id).FirstOrDefaultAsync();
            return itemtobefound;
        }


        public async Task Update(TodoListItem obj) {
            var itemtobeupdated = await _listDbContext.Todos.Where(T => T.Id == obj.Id).FirstOrDefaultAsync();
            itemtobeupdated = obj;
            await _listDbContext.SaveChangesAsync();

        }
    }
}
