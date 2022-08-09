using Microsoft.EntityFrameworkCore;

namespace Planet.API.Data
{
    public class DefaultContext : DbContext
    {
        public DbSet<Models.Planet> Planets { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options):base(options)
        {

        }
    }
}
