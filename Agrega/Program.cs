using Agrega;
using Sparc.Blossom.Authentication.Passwordless;

BlossomApplication.Run<Html, User>(args,
    builder =>
    {
        builder.Services.AddCosmos<AgregaContext>(builder.Configuration["ConnectionStrings:CosmosDb"]!, "agrega", ServiceLifetime.Scoped);
        builder.AddBlossomPasswordlessAuthentication<User>();
    });