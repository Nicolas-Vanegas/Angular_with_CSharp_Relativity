using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RelCustomPage.ActionResults
{
    public class ETagActionResult : IHttpActionResult
    {
        private readonly string _key;
        private readonly IHttpActionResult _action;

        public static string GetTagName(string key)
        {
            return $"\"{key}\"";
        }
        public ETagActionResult(IHttpActionResult action, string key)
        {
            _key = key;
            _action = action;
        }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var result = await _action.ExecuteAsync(cancellationToken);
            result.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue(GetTagName(_key));
            return result;
        }
    }
}
