using PetSystem.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();

var app = builder.Build();
app.UseApiConfiguration(app.Environment);

app.MapControllers();

app.Run();