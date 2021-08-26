using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RelCustomPage.ActionResults
{
    public class CacheControlActionResult : IHttpActionResult
    {
        private readonly IHttpActionResult _action;
        private readonly TimeSpan _maxAge;

        public CacheControlActionResult(IHttpActionResult action, TimeSpan maxAge)
        {
            _action = action;
            _maxAge = maxAge;
        }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var result = await _action.ExecuteAsync(cancellationToken);
            result.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = _maxAge
            };
            return result;
        }
    }
}
