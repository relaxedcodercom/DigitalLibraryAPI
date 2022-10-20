using Microsoft.EntityFrameworkCore;

namespace DigitalLibraryAPI.DataAccess
{
    public class MySqlDataContext : DbContext
    {
        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
        }
    }
}