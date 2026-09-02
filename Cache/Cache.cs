namespace Assignment01.Cache
{
    // Q20: Complete Exercise - Create a generic Cache<TKey, TValue> with Add, Get, Remove, Contains, and expiration support.
    public class Cache<TKey, TValue> where TKey : notnull
    {
        private class CacheEntry
        {
            public TValue Value { get; set; }
            public DateTime? ExpirationTime { get; set; }

            public CacheEntry(TValue value, DateTime? expirationTime)
            {
                Value = value;
                ExpirationTime = expirationTime;
            }

            public bool IsExpired => ExpirationTime.HasValue && DateTime.UtcNow >= ExpirationTime.Value;
        }

        private readonly Dictionary<TKey, CacheEntry> _storage = new();

        public void Add(TKey key, TValue value)
        {
            _storage[key] = new CacheEntry(value, null);
        }

        public void Add(TKey key, TValue value, TimeSpan duration)
        {
            DateTime expirationTime = DateTime.UtcNow.Add(duration);
            _storage[key] = new CacheEntry(value, expirationTime);
        }

        public void Add(TKey key, TValue value, DateTime expirationTime)
        {
            _storage[key] = new CacheEntry(value, expirationTime.ToUniversalTime());
        }

        public TValue Get(TKey key)
        {
            if (!_storage.TryGetValue(key, out var entry))
            {
                throw new KeyNotFoundException($"Key '{key}' was not found in the cache.");
            }

            if (entry.IsExpired)
            {
                _storage.Remove(key);
                throw new KeyNotFoundException($"Key '{key}' has expired.");
            }

            return entry.Value;
        }

        public bool TryGet(TKey key, out TValue? value)
        {
            if (_storage.TryGetValue(key, out var entry))
            {
                if (!entry.IsExpired)
                {
                    value = entry.Value;
                    return true;
                }

                _storage.Remove(key);
            }

            value = default;
            return false;
        }

        public bool Remove(TKey key)
        {
            return _storage.Remove(key);
        }

        public bool Contains(TKey key)
        {
            if (_storage.TryGetValue(key, out var entry))
            {
                if (!entry.IsExpired)
                {
                    return true;
                }

                _storage.Remove(key);
            }
            return false;
        }

        public int PurgeExpired()
        {
            var expiredKeys = _storage.Where(kvp => kvp.Value.IsExpired).Select(kvp => kvp.Key).ToList();
            foreach (var key in expiredKeys)
            {
                _storage.Remove(key);
            }
            return expiredKeys.Count;
        }

        public int Count
        {
            get
            {
                PurgeExpired();
                return _storage.Count;
            }
        }

        public void Clear() => _storage.Clear();
    }
}
