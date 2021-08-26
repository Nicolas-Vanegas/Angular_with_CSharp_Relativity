using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RelCustomPage.ActionResults
{
    public class FileStreamActionResult : IHttpActionResult
    {
        private readonly Stream _stream;
        private readonly string _fileName;
        private readonly string _mediaType;

        public FileStreamActionResult(Stream stream, string fileName, string mediaType)
        {
            _stream = stream;
            _fileName = fileName;
            _mediaType = mediaType;
        }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var length = _stream.Length;
            var byteArray = new byte[0];
            using (_stream)
            {
                byteArray = await ToByteArrayAsync(_stream);
            }
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(byteArray)
            };
            response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = _fileName
                };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(_mediaType);
            return response;
        }
        private static async Task<byte[]> ToByteArrayAsync(Stream input)
        {
            input.Seek(0, SeekOrigin.Begin);
            using (var ms = new MemoryStream())
            {
                await input.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}