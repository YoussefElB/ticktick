using MediatR;
using TickTick.App.Services;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.Extensions
{
    public static class IoCExtentions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonsService, PersonsService>();
            services.AddTransient<IRepository<Person>, Repository<Person>>();
            services.AddTransient<IRepository<Playlist>, Repository<Playlist>>();

            services.AddMediatR(System.Reflection.Assembly.GetAssembly(typeof(IoCExtentions)));


        }
    }
}
