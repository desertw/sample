using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CurData
    {
        /// <summary>
        /// Read rate from database
        /// </summary>
        /// <param name="fromCode"></param>
        /// <param name="toCode"></param>
        /// <returns></returns>
        public static IEnumerable<ExRate> GetCurRates(string fromCode, string toCode)
        {
            using (CurrencyDataContext db = new CurrencyDataContext())
            {
                var result = from r in db.ExRates
                             where r.FromCurCode == fromCode && r.ToCurCode == toCode
                             select r;
                return result.ToArray();
            }
        }

        /// <summary>
        /// Read all currency codes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Currency> GetAllCur()
        {
            using (CurrencyDataContext db = new CurrencyDataContext())
            {
                var result = from c in db.Currencies
                             select c;
                return result.ToArray();
            }
        }
    }
}
