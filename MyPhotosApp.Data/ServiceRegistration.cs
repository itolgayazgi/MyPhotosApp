using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPhotosApp.Core.IRepos;
using MyPhotosApp.Data.Contexts;
using MyPhotosApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Data
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MyPhotosDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddSingleton<IUserReadRepository, UserReadRepository>();
            services.AddSingleton<IUserWriteRepository, UserWriteRepository>();
            services.AddSingleton<IPhotoReadRepository, PhotoReadRepository>();
            services.AddSingleton<IPhotoWriteRepository, PhotoWriteRepository>();
            services.AddSingleton<ICategoryReadRepository, CategoryReadRepository>();
            services.AddSingleton<ICategoryWriteRepository, CategoryWriteRepository>();
        }
    }
}
