using week9_day1.Models;
using Microsoft.EntityFrameworkCore;


namespace week9_day1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserInfo> Users { get; set; }
    }
}
