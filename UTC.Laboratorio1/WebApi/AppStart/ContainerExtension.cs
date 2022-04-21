using BD;
using Microsoft.Extensions.DependencyInjection;
using WBL;

namespace WebApi
{
    public static class ContainerExtension
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IContactoService, ContactoService>();
            return services;
        }
    }
}
