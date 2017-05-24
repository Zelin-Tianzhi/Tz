using System;
using System.Collections.Generic;

namespace Tz.Cache.Redis
{
    public class RedisCache : ICache
    {
        public object Get(string key)
        {
            return "RedisCache";
        }

        public T Get<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetList<T>(string keyColl) where T : class
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object data)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object data, int expirtime)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key, int islike = 0)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, object data, int expirtime)
        {
            throw new NotImplementedException();
        }

        public void UserOffline(string key)
        {
            throw new NotImplementedException();
        }
    }
}