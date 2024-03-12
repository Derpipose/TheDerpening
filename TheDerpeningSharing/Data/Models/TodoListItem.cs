using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TheDerpening.Data.Models
{
    public partial class TodoListItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(90)]
        public string? Title { get; set; }
        public bool IsTaskCompleted { get; set; }

    }

    /*public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }*/


}
