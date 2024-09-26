using Agrega;
using Agrega._Plugins;
using Sparc.Blossom.Authentication.Passwordless;

BlossomApplication.Run<Html, User>(args,
    builder =>
    {
        builder.Services.AddCosmos<AgregaContext>(builder.Configuration["ConnectionStrings:CosmosDb"]!, "agrega", ServiceLifetime.Scoped);
        builder.Services.AddScoped<YouTubeService>();
        builder.AddBlossomPasswordlessAuthentication<User>();
    });