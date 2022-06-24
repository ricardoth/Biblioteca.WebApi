using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Services;
using Biblioteca.Infraestructure.Data;
using Biblioteca.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.WebApi.Extensions
{
    public static class ExtensionService
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BibliotecaBdContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BibliotecaBd")));

            services.AddTransient<IAutorService, AutorService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
