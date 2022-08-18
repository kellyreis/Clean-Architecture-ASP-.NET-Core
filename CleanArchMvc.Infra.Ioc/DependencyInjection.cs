using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasctructure(
            this IServiceCollection services,
            IConfiguration conFiguration)
        {
            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(conFiguration.GetConnectionString("DefaultConnection"
            ),b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;

        }
    }
}
