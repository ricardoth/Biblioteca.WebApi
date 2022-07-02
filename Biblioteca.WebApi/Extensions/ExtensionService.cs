using Biblioteca.Domain.CustomEntities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Services;
using Biblioteca.Infraestructure.Data;
using Biblioteca.Infraestructure.Interfaces;
using Biblioteca.Infraestructure.Repository;
using Biblioteca.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Biblioteca.WebApi.Extensions
{
    public static class ExtensionService
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));

            services.AddDbContext<BibliotecaBdContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BibliotecaBd")));

            services.AddTransient<IAutorService, AutorService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext?.Request;
                var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
        }
    }
}
