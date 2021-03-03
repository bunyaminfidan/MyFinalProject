using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //bagımlılıkları startup yerine buraya yazacağız.
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            //Arka planda hazır bir ICacheManager instance oluşturutor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCahceManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
