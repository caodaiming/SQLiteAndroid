using System.Net;

namespace SQLiteAndroid
{
    public class HttpResponse
    {
        public string Content { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}