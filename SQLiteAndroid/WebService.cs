using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace SQLiteAndroid
{
    public class WebService
    {

        public HttpResponse Get(string url)
        {
            var request = WebRequest.Create(url);

            request.ContentType = "application/json";
            request.Method = "get";

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                return BuildResponse(response);
            }
        }

        private HttpResponse BuildResponse(HttpWebResponse httpResponse)
        {
            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                var response = new HttpResponse
                {
                    Content = content,
                    HttpStatusCode = httpResponse.StatusCode
                };
                return response;
            }
        }

        public async Task<HttpResponse> GetAsync(string url)
        {
            var request = WebRequest.Create(url);

            request.ContentType = "application/json";
            request.Method = "Get";

            using (var response = await request.GetResponseAsync() as HttpWebResponse)
            {
                return BuildResponse(response);
            }
        }
    }
}