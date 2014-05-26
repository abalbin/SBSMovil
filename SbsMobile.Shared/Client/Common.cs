using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SbsMobile.Shared
{
    public class Common
    {
        public static HttpWebRequest CreateRequest(string location)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://172.20.30.41:8089/api/" + location);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }

        //public static string ReadResponseText(string request)
        //{
        //    var client = new HttpClient { BaseAddress = new Uri("http://vm-07:1608/") };
        //    var response = client.GetAsync(request).Result;
        //    return response.Content.ReadAsStringAsync().Result;
        //}

        public static string ReadResponseText(HttpWebRequest req)
        {
            using (WebResponse resp = req.GetResponse())
            {
                using (Stream s = (resp).GetResponseStream())
                {
                    using (var r = new StreamReader(s, Encoding.UTF8))
                    {
                        return r.ReadToEnd();
                    }
                }
            }
        }
    }
}
