using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract, Serializable]
    public class CurrencyRate
    {
        [DataMember]
        public string PostDate { get; set; }
        [DataMember]
        public decimal AveRate { get; set; }
        [DataMember]
        public decimal EndRate { get; set; }
    }

    [DataContract, Serializable]
    public class CurrencyRates
    {
        [DataMember]
        public List<CurrencyRate> Items { get; set; }
    }

    [DataContract, Serializable]
    public class CurrencyCode
    {
        [DataMember]
        public string Caption { get; set; }
        [DataMember]
        public string Code { get; set; }
    }

    [DataContract, Serializable]
    public class CurrencyCodes
    {
        [DataMember]
        public List<CurrencyCode> AllCodes { get; set; }
    }
}
