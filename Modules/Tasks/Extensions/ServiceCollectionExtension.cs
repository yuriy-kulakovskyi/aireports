using aireports.Modules.Tasks.Application.Services;
using aireports.Modules.Tasks.Infrastructure;

namespace aireports.Modules.Tasks.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTodoModule(this IServiceCollection services)
        {
            services.AddScoped<TodoRepository, TodoClientRepository>();
            services.AddScoped<TodoService>();
            services.AddControllers();
            return services;
        }
    }
}