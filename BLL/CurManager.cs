using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;

using Common;
using DAL;

namespace BLL
{
    public class CurManager
    {
        //Read cache flag from web.config
        static bool allowCache = WebConfigurationManager.AppSettings["allowCache"] == "1";

        /// <summary>
        /// We will try to load/store currency rates in memcached if allowing cache
        /// </summary>
        /// <param name="fromCode"></param>
        /// <param name="toCode"></param>
        /// <returns></returns>
        public static CurrencyRates GetCurRates(string fromCode, string toCode)
        {
            var key = string.Format("{0}_{1}", fromCode, toCode);

            //The "KeyExists" not working, use "Get" for now
            if (allowCache && CouchbaseManager.Instance.Get(key) != null)
            {
                return CouchbaseManager.Instance.Get(key) as CurrencyRates;
            }
            else
            {
                var data = CurData.GetCurRates(fromCode, toCode);
                var data2 = new CurrencyRates();
                data2.Items = data.Select(r => new CurrencyRate()
                {
                    PostDate = r.PostDate.ToLongDateString(),
                    AveRate = r.AverageRate,
                    EndRate = r.EndOfDayRate
                }).ToList();
                
                if (allowCache)
                {
                    //CouchbaseManager.Instance.Store(Enyim.Caching.Memcached.StoreMode.Set, key, result2.FirstOrDefault());
                    var result = CouchbaseManager.Instance.ExecuteStore(Enyim.Caching.Memcached.StoreMode.Set, key, data2);
                    if (!result.Success)
                    {
                        Console.WriteLine("Store failed with message {0} and status code {1}", result.Message, result.StatusCode);

                        if (result.Exception != null)
                        {
                            throw result.Exception;
                        }
                    }
                }
                return data2;
            }
        }

        /// <summary>
        /// Load all currency code in CurrencyCode object
        /// </summary>
        /// <returns></returns>
        public static CurrencyCodes GetAllCurrencyCode()
        {
            var key = "AllCode";

            //The "KeyExists" not working, use "Get" for now
            if (allowCache && CouchbaseManager.Instance.Get(key) != null)
            {
                return CouchbaseManager.Instance.Get(key) as CurrencyCodes;
            }
            else
            {
                var data = CurData.GetAllCur();
                var data2 = new CurrencyCodes();
                data2.AllCodes = data.Select(c => new CurrencyCode()
                {
                    Caption = string.Format("{0}({1})", c.Country, c.Code),
                    Code = c.Code
                }).ToList();
                
                if (allowCache)
                {
                    var result = CouchbaseManager.Instance.ExecuteStore(Enyim.Caching.Memcached.StoreMode.Set, key, data2);
                    if (!result.Success)
                    {
                        Console.WriteLine("Store failed with message {0} and status code {1}", result.Message, result.StatusCode);

                        if (result.Exception != null)
                        {
                            throw result.Exception;
                        }
                    }
                }
                return data2;
            }
        }
    }
}
