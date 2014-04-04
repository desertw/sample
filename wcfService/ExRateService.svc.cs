using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

using Common;
using BLL;

namespace wcfService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ExRateService
    {
        [OperationContract]
        public CurrencyRates GetCurrencyRates(string fromCode, string toCode)
        {
            return CurManager.GetCurRates(fromCode, toCode);
        }

        [OperationContract]
        public CurrencyCodes GetCurrencyCodes()
        {
            return CurManager.GetAllCurrencyCode();
        }
    }
}
