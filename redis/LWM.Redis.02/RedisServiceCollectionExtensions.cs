
using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LWM.Redis {


    public static class RedisServiceCollectionExtensions {

        public static IServiceCollection AddRedis( this IServiceCollection serviceCollection, string configurationOptions )
           => serviceCollection.AddRedis( builder => builder.SetConfigurationOptions( configurationOptions ) );
        //{
        //    serviceCollection.TryAddSingleton( new RedisConnectionManager( configurationOptions ) );
        //    return serviceCollection;
        //}


        public static IServiceCollection AddRedis( this IServiceCollection serviceCollection, Action<IRedisBuilder> configure ) {

            serviceCollection.AddOptions( );
            serviceCollection.AddOptions<RedisOptions>( );

            serviceCollection.TryAddSingleton<RedisConnectionManager>( );
            serviceCollection.TryAddSingleton<RedisCache>( );

            configure( new DefaultRedisBuilder( serviceCollection ) );

            return serviceCollection;
        }

    }
}
