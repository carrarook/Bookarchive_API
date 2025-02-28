using Microsoft.Extensions.DependencyInjection;

using Application.Configurations;
using Application.Dictionary;
using Application.Handlers;
using Application.Utils;

using Core.IRepositories;

using Infrastructure.Repositories;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            #region Repositories
            #endregion

            #region Handlers
            services.AddTransient<BooksHandler>();
            #endregion

            #region Services
            #endregion

            #region Dictionary
            services.AddSingleton<DefaultDictionary>();
            #endregion

            #region Helper
            services.AddScoped<IMapper, Mapper>();
            services.AddSingleton<StartupTimeService>();
            #endregion

        }
    }
}