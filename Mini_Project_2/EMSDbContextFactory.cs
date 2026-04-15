using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UVEMS.DAL.Data
{
    public class EMSDbContextFactory : IDesignTimeDbContextFactory<EMSDbContext>
    {
        public EMSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EMSDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=UVEMSDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new EMSDbContext(optionsBuilder.Options);
        }
    }
}
