using Core.Entities;
using Core.Services.CurrentUserService;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentUserService _userProvider;
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService userProvider) : base(options)
        {
            _userProvider = userProvider;
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).Create(_userProvider.GetUserLogin());
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((AuditableEntity)entityEntry.Entity).Update(_userProvider.GetUserLogin());
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
