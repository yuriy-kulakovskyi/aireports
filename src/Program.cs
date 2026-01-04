using aireports.Modules.AI.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<AskAiHandler>();
builder.Services.AddScoped<IAiClient, MockAiClient>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();