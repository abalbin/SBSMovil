using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SbsMobile.SharedPcl
{
    public class TipoCambioClient
    {
        public async Task<List<TipoCambio>> GetTipoCambio(TipoCambio requestObject)
        {
            var requestStr = string.Format("tipocambio/{0}", requestObject.Fecha.ToString("ddMMyyyy"));
            var response = await Common.GetJson(requestStr);
            return JsonConvert.DeserializeObject<List<TipoCambio>>(response);
        }
    }
}
