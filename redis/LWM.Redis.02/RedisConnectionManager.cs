using System;

using Microsoft.Extensions.Options;

using StackExchange.Redis;

namespace LWM.Redis {

    public class RedisConnectionManager {

        readonly Lazy<IConnectionMultiplexer>   _connectionMultiplexer;

        public IConnectionMultiplexer Connection => _connectionMultiplexer.Value;

        public RedisConnectionManager( IOptions<RedisOptions> options )
            => _connectionMultiplexer = new Lazy<IConnectionMultiplexer>( ( ) => ConnectionMultiplexer.Connect( options.Value.ConfigurationOptions ) );

    }
}
