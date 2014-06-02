using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsMobile.SharedPcl
{
    public class Common
    {
        public static async Task<string> GetJson(string request)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("http://vm-07:1654/api/") })
            {
                return await client.GetStringAsync(request).ConfigureAwait(false);
            }
        }
    }
}
