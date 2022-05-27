using Data.Services.CurrentUserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public MigrationContextFactory()
        {
        }
        public AppDbContext CreateDbContext(string[] args)
        {
            var optbuilder = new DbContextOptionsBuilder<AppDbContext>();
            optbuilder.UseSqlServer("Server=.;Database=AtonTest;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AppDbContext(optbuilder.Options, new CurrentUserService());
        }

    }
}
