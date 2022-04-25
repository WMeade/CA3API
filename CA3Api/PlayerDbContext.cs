using Microsoft.EntityFrameworkCore;

namespace CA3Api
{
    public class PlayerDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = eadcaserver.database.windows.net; Initial Catalog = AppDB; Persist Security Info = True; User ID = GamingApp; Password = SrvPass@123!");
        }
        public DbSet<Player> Player { get; set; }
        public DbSet<Leaderboard> Leaderboard { get; set; }
    }
}
