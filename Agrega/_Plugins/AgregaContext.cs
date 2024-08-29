using Agrega.Sources.Entities;
using Agrega.Users;
using Microsoft.EntityFrameworkCore;
using Sparc.Blossom;

public partial class AgregaContext(BlossomContextOptions options) : BlossomContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().ToContainer("Users").HasPartitionKey(x => x.UserId);

        var source = builder.Entity<Source>().HasPartitionKey(x => x.SourceId);
        var post = builder.Entity<Post>().HasPartitionKey(x => x.SourceId);
    }


}