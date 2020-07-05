using System;

using StackExchange.Redis;

namespace LWM.Redis {

    public class RedisConnectionManager {

        readonly Lazy<IConnectionMultiplexer>   _connectionMultiplexer;

        public IConnectionMultiplexer Connection => _connectionMultiplexer.Value;

        public RedisConnectionManager( string connectionOptions )
            => _connectionMultiplexer = new Lazy<IConnectionMultiplexer>( ( ) => ConnectionMultiplexer.Connect( connectionOptions ) );

    }
}
