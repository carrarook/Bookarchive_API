using IoC;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddIoc(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(nameof(services));
            
            NativeInjectorBootStrapper.RegisterServices(services);
            
        }
    }
}