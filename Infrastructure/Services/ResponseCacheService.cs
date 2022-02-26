using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase database;
        public ResponseCacheService(IConnectionMultiplexer redis)
        {
            database = redis.GetDatabase();
        }

        public async Task CacheResponseAsync(string cahceKey, object response, TimeSpan timeToLive)
        {
            if(response == null)
            {
                return;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var serializedResponse = JsonSerializer.Serialize(response, options);
            await database.StringSetAsync(cahceKey, serializedResponse, timeToLive);
        }

        public async  Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponsed = await database.StringGetAsync(cacheKey);
            if(cachedResponsed.IsNullOrEmpty)
            {
                return null;
            }
            return cachedResponsed;
        }
    }
}