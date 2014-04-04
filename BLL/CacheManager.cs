using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Couchbase;
using Couchbase.Extensions;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;

namespace BLL
{
    public static class CouchbaseManager
    {
        private readonly static CouchbaseClient _instance;

        static CouchbaseManager()
        {
            _instance = new CouchbaseClient();
        }

        public static CouchbaseClient Instance { get { return _instance; } }

        public static void FlushCache()
        {
            _instance.FlushAll();
        }
    }
}
