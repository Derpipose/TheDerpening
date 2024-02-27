using Microsoft.EntityFrameworkCore;
using TheDerpening.Data.Models;

namespace TheDerpening.Data {
    public class ListDbContext: DbContext {
        public DbSet<TodoListItem> Todos { get; set; }

        public ListDbContext(DbContextOptions<ListDbContext> options) : base(options) {
        }

    }
}
