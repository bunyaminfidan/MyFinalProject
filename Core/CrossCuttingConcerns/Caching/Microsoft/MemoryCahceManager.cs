using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCahceManager : ICacheManager

    {
        //Adapter Pattern adaptasyon deseni uygulandı
        // var olan bir şeyi kendi sistemime uyarlıyorum.

        IMemoryCache _memoryCahce; //bu bir interface bunu çözmek lazım.
                                   //CoreModule - 
                                   //serviceCollection.AddMemoryCache();
                                   //serviceCollection.AddSingleton<ICacheManager, MemoryCahceManager>();
        public MemoryCahceManager()
        {
            _memoryCahce = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
            //istenilen bütün servisleri bu şekilde çekebiliriz. Wpf veya w form uygulamasında
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCahce.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCahce.Get<T>(key);
        }

        public object Get(string key)
        {
            //tip dönüşümü yapmak gerekiyor.
            return _memoryCahce.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCahce.TryGetValue(key, out _);
            //istersen bize değeri set ederek döndürebilir. ama biz burada istemiyoruz
            //out _ : ben sadece bellekte var mı ona bakmak istiyorum demek.
        }

        public void Remove(string key)
        {
            _memoryCahce.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            //Reflection
            //  Çalışma anında bellekten silmeye yarar.
            //Reflection ile çalışma anında elde olan nesneye müdahale ediyoruz burada.
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCahce) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCahce.Remove(key);
            }
        }
    }
}
