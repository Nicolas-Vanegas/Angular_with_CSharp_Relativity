using System;
using System.Web.Http;

namespace RelCustomPage.ActionResults
{
    public static class HttpActionResultExtensions
    {
        public static IHttpActionResult Etag(this IHttpActionResult result, string key)
        {
            return new ETagActionResult(result, key);
        }
        public static IHttpActionResult CacheControl(this IHttpActionResult result, TimeSpan maxAge)
        {
            return new CacheControlActionResult(result, maxAge);
        }
    }
}
