using TickTick.App.Services;

namespace TickTick.App.Extensions
{
    public static class IoCExtentions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonsService, PersonsService>();
        }
    }
}
