using aireports.Modules.AI.Domain.Interfaces;

namespace aireports.Modules.AI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAiModule(this IServiceCollection services)
        {
            services.AddScoped<AskAiHandler>();
            services.AddScoped<IAiClient, MockAiClient>();
            return services;
        }
    }
}