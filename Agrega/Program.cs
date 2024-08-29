using Agrega.Components;
using Agrega.Users;
using Sparc.Blossom;
using Sparc.Blossom.Data;


BlossomApplication.Run<App,User>(args,
    builder =>
    {
        builder.Services.AddCosmos<AgregaContext>(builder.Configuration["ConnectionStrings:CosmosDb"]!, "Agrega", ServiceLifetime.Scoped);
    });