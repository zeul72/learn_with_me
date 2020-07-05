#nullable enable

namespace LWM.Redis {
    public class RedisOptions {
        /// <summary>
        /// This is the Redis Configuration Options - i.e. ConnectionString, ssl, etc.
        /// </summary>
        public string? ConfigurationOptions { get; set; }

        public int DBIndex { get; set; } = -1;

        public string? KeyPrefix { get; set; }
    }
}
