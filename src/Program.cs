using aireports.Modules.Tasks.Extensions;
using aireports.Modules.AI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services
    .AddAiModule()
    .AddTodoModule()
    .AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();