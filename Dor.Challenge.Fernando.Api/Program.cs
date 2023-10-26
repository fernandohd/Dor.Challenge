using Dor.Challenge.Fernando.Api;
using Dor.Challenge.Fernando.App;
using Dor.Challenge.Fernando.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Host.RegisterAssembly();

builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddWebApiModule(builder.Configuration);
builder.Services.AddAppModule();

var app = builder.Build();

app.UseWebApi();

app.MapControllers();

app.Run();
