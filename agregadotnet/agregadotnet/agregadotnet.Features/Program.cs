var builder = WebApplication.CreateBuilder(args);

builder.AddBlossom(builder.Configuration["WebClientUrl"]);

//builder.Services.AddAzureStorage(builder.Configuration.GetConnectionString("Storage")!);


//builder.Services.AddCosmos<agregadotnetContext>(builder.Configuration.GetConnectionString("Database")!, "agregadotnetdb", ServiceLifetime.Transient);

//var auth = builder.Services.AddAzureADB2CAuthentication<User>(builder.Configuration);
//builder.AddPasswordlessAuthentication<User>(auth);

//builder.Services.AddTwilio(builder.Configuration);


builder.Services.AddServerSideBlazor();
builder.Services.AddOutputCache();

var app = builder.Build();

app.UseBlazorFrameworkFiles();
app.UseBlossom();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToFile("index.html");

if (builder.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

//app.UsePasswordlessAuthentication<User>();

app.Run();
