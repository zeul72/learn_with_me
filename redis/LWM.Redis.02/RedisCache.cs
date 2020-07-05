#nullable enable

using Microsoft.Extensions.Options;

using StackExchange.Redis;

namespace LWM.Redis {
    public class RedisCache {
        readonly IDatabase  _database;
        readonly string?     _keyPrefix;

        public RedisCache( RedisConnectionManager redisConnectionManager, IOptions<RedisOptions> options )
            => (_database, _keyPrefix) = (redisConnectionManager.Connection.GetDatabase( options.Value.DBIndex ), options.Value.KeyPrefix);


        public void SetString( string key, string value )
            => _database.StringSet( FormatKey( key ), value );

        public string GetString( string key )
            => _database.StringGet( FormatKey( key ) );

        string FormatKey( string key ) => string.IsNullOrWhiteSpace( _keyPrefix ) ? key : $"{_keyPrefix}:{key}";
    }
}
