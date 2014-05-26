using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsMobile.SharedPcl
{
    public class Common
    {
        public static async Task<string> GetJson(string request)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("http://172.20.30.41:8089/api/") })
            {
                return await client.GetStringAsync(request).ConfigureAwait(false);
            }
        }
    }
}
