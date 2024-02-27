using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TheDerpening.Data.Models
{
    public class TodoListItem
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public bool IsCompleted { get; set; }
    }

    /*public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }*/


}
