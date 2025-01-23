using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Services
{
    internal class PageCache
    {
        private readonly Dictionary<string, Page> _cache = new Dictionary<string, Page>();

        public Page SavePage(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            if (!_cache.ContainsKey(pageName))
            {
                _cache[pageName] = (Page)Activator.CreateInstance(Type.GetType(pageName));
            }

            return _cache[pageName];
        }
    }
}
