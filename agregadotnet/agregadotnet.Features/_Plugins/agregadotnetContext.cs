using Microsoft.EntityFrameworkCore;

namespace agregadotnet.Features._Plugins
{
    public class agregadotnetContext : BlossomContext
    {
        public DbSet<User> Users => Set<User>();

        public agregadotnetContext(DbContextOptions options, Publisher publisher, IHttpContextAccessor http) : base(options, publisher, http)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToContainer("Users").HasPartitionKey(x => x.UserId);
        }
    }
}
