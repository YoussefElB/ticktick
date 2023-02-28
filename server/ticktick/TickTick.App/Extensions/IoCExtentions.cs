using MediatR;
using System.Reflection;
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
            services.AddTransient<IPlaylistService, PlaylistService>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IRepository<Person>, Repository<Person>>();
            services.AddTransient<IRepository<Playlist>, Repository<Playlist>>();
            
            services.AddMediatR(opt => {
                opt.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(IoCExtentions)));
            });


        }
    }
}
