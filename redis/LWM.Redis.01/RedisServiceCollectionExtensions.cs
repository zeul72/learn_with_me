
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LWM.Redis {


    public static class RedisServiceCollectionExtensions {

        public static IServiceCollection AddRedis(this IServiceCollection serviceCollection, string configurationOptions ) {
            serviceCollection.TryAddSingleton( new RedisConnectionManager( configurationOptions ) );
            return serviceCollection;
        }
    }
}
