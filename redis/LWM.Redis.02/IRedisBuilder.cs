using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

namespace LWM.Redis {

    public interface IRedisBuilder {
        IRedisBuilder SetConfigurationOptions( string configurationOptions );
        IRedisBuilder SetDBIndex( int dbIndex );
        IRedisBuilder SetKeyPrefix( string keyPrefix );
    }

    public class DefaultRedisBuilder : IRedisBuilder {

        public IServiceCollection ServiceCollection { get; }

        public DefaultRedisBuilder( IServiceCollection serviceCollection )
            => ServiceCollection = serviceCollection;

        public IRedisBuilder SetConfigurationOptions( string configurationOptions ) {
            ServiceCollection.Configure<RedisOptions>( o => o.ConfigurationOptions = configurationOptions );
            return this;
        }

        public IRedisBuilder SetDBIndex( int dbIndex ) { 
            ServiceCollection.Configure<RedisOptions>( o => o.DBIndex = dbIndex );
            return this;
        }

        public IRedisBuilder SetKeyPrefix( string keyPrefix ) {
            ServiceCollection.Configure<RedisOptions>( o => o.KeyPrefix = keyPrefix );
            return this;
        }
    }
}
