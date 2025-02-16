using ComputerShutdownTimer.Converters;
using System;
using System.Runtime.Caching;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Services
{
    internal class PageCache
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        public Page GetOrCreatePage(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            if (!_cache.Contains(pageName))
            {
                _cache.Set(pageName, new TypeToPage().Convert(Type.GetType(pageName)), new CacheItemPolicy());
            }

            return _cache.Get(pageName) as Page;
        }
    }
}
