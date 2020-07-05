using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LWM.Redis {

    public class MyService {
        readonly RedisCache _cache;

        public MyService( RedisCache redisCache )
            => _cache = redisCache;

        public void TestRedis( )
            => _cache.SetString( "MyService_Test", "MyService_TestValue" );

    }

    class Program {
        static void Main( string[ ] args ) {

            var config = LoadConfiguration();

            var serviceProvider = LoadServices( config );

            var myService = serviceProvider.GetService<MyService>();

            myService.TestRedis( );
            //myService.TestRedis( "qa" );
            //myService.TestRedis( "lab" );

            //var connection = serviceProvider.GetRequiredService<RedisConnectionManager>().Connection.GetDatabase();
            //connection.StringSet( "Test_Key", "Test_Value" );


        }

        static IServiceProvider LoadServices( IConfiguration configuration )
            => new ServiceCollection( )
                    .AddRedis( builder =>
                        builder
                            .SetConfigurationOptions( configuration.GetConnectionString( "Redis" ) )
                            .SetKeyPrefix( "dev" )
                            //.SetDBIndex( 1 )
                    )
                    .AddTransient<MyService>( )
                    .BuildServiceProvider( );

        static IConfiguration LoadConfiguration( )
            => new ConfigurationBuilder( )
                    .AddJsonFile( "app.config.json" )
                    .Build( );
    }
}
