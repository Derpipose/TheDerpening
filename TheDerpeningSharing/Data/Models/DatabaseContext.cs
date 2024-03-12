using Microsoft.EntityFrameworkCore;

namespace TheDerpening.Data
{
    public partial class DatabaseContext : ListDbContext
    {

        public DatabaseContext(DbContextOptions<ListDbContext> options) : base(options)
        {
        }


    }
}
