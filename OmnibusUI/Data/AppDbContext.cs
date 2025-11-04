using Microsoft.EntityFrameworkCore;
using OmnibusUI.Models; 

namespace OmnibusUI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Book> Bookhouse { get; set; }
    }
}
