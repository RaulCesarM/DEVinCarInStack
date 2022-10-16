using Microsoft.Extensions.Caching.Memory;

namespace DEVinCar.Domain.Services
{
    public class  CacheService<TEntity>
    {
        private readonly IMemoryCache _cache;
        private string _baseKey;
        private TimeSpan _expiration;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void Config(string baseKey, TimeSpan expiration)
        {
            _baseKey = baseKey;
            _expiration = expiration;
        }
        public TEntity Set(string parameter, TEntity entity)
        {
            return _cache.Set<TEntity>(MontarChave(parameter), entity, _expiration);
        }
        public bool TryGetValue(string parameter, out TEntity entity)
        {
            return _cache.TryGetValue<TEntity>(MontarChave(parameter), out entity);
        }

        public void Remove(string parameter)
        {
            _cache.Remove(MontarChave(parameter));
        }

        private string MontarChave(string parameter)
        {
            return $"{_baseKey}:{parameter}";
        }
        
    }
}