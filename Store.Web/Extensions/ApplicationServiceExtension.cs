using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Services.Mapping;
using Store.Services.Products;

namespace Store.Web.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(ProductProfile));

            return services;
        }
    }
}
