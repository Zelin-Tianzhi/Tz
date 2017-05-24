using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace Tz.Cache
{
    public class Cache
    {
        private static ICache _cache = null;
        private static readonly object _cacheLocker = new object();
        static Cache()
        {
            Load();
        }

        public static object Get(string key)
        {
            return string.IsNullOrWhiteSpace(key) ? null : _cache.Get(key);
        }

        private static void Load()
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("Config/autofac.json");
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            IContainer context = null;
            context = builder.Build(ContainerBuildOptions.None);
            _cache = context.Resolve<ICache>();

        }
    }
}