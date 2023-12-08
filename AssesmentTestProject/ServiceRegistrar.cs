using AssesmentTestProject.DataAccess;
using AssesmentTestProject.DataAccess.Repositories;
using AssesmentTestProject.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AssesmentTestProject
{
    static class ServiceRegistrar
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHierarchyRepository, HierarchyRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IHierarchyService, HierarchyService>();
        }
    }
}
