using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using StackExchange.Redis;

namespace LWM.Redis {

    public class MyService {
        readonly IDatabase _redisDatabase;

        public MyService( RedisConnectionManager redisConnectionManager )
            => _redisDatabase = redisConnectionManager.Connection.GetDatabase( );

        public void TestRedis(string prefix) {
            _redisDatabase.StringSet( $"{prefix}:MyService_Test", "MyService_TestValue" );
        }
    }

    class Program {
        static void Main( string[ ] args ) {

            var config = LoadConfiguration();

            var serviceProvider = LoadServices( config );

            var myService = serviceProvider.GetService<MyService>();

            myService.TestRedis( "dev" );
            myService.TestRedis( "qa" );
            myService.TestRedis( "lab" );

            //var connection = serviceProvider.GetRequiredService<RedisConnectionManager>().Connection.GetDatabase();
            //connection.StringSet( "Test_Key", "Test_Value" );
            

        }

        static IServiceProvider LoadServices( IConfiguration configuration )
            => new ServiceCollection( )
                    .AddRedis( configuration.GetConnectionString( "Redis" ) )
                    .AddTransient<MyService>()
                    .BuildServiceProvider( );

        static IConfiguration LoadConfiguration( )
            => new ConfigurationBuilder( )
                    .AddJsonFile( "app.config.json" )
                    .Build( );
    }
}
