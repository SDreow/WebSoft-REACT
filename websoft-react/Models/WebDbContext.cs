// Example of DbContext class
using Microsoft.EntityFrameworkCore;
using websoft_react.ModelView;


namespace websoft_react.Models
{
    public class WebDBContext : DbContext
    {
    public WebDBContext(DbContextOptions<WebDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DokladyPodpisyView>(entity => entity.HasKey(new string[] { "id_druh", "rok" }));
    }

        // DbSet pro každou entitu v databázi
        public DbSet<DokladyPodpisyView> Doklady { get; set; }
        
    }
}
