using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SbsMobile.Shared
{
    public class TipoCambioClient
    {
        List<TipoCambio> _listaTipoCambio;

        public async Task<string> GetTipoCambioStr(TipoCambio requestObject)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var requestStr = string.Format("tipocambio/{0}", requestObject.Fecha.ToString("ddMMyyyy"));
                var request = Common.CreateRequest(requestStr);
                var response = Common.ReadResponseText(request);
                //return JsonConvert.DeserializeObject<List<TipoCambio>>(response);
                return response;
            });

            return await task;
        }

        public async Task<List<TipoCambio>> GetTipoCambio(TipoCambio requestObject)
        {
            _listaTipoCambio = await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var requestStr = string.Format("tipocambio/{0}", requestObject.Fecha.ToString("ddMMyyyy"));
                        var request = Common.CreateRequest(requestStr);
                        var response = Common.ReadResponseText(request);
                        return JsonConvert.DeserializeObject<List<TipoCambio>>(response);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        return new List<TipoCambio>();
                    }
                });

            return _listaTipoCambio;
        }
    }
}
