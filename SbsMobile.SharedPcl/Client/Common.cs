using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsMobile.SharedPcl
{
    public class Common
    {
        public static Task<string> GetJson(string request)
        {
			using (var client = new HttpClient { BaseAddress = new Uri("http://96.3.1.143:1654/api/") })
            {
                return client.GetStringAsync(request);
            }
        }
    }
}
