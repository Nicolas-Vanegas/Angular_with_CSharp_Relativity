using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RelCustomPage.Controllers
{
    public class BaseController : ApiController
    {
        // GET: Base
        public IHttpActionResult NotModified()
        {
            return StatusCode(System.Net.HttpStatusCode.NotModified);
        }

        public IHttpActionResult Accepted()
        {
            return StatusCode(System.Net.HttpStatusCode.Accepted);
        }
        public IHttpActionResult File(Stream file, string fileName, string mediaType)
        {
            return new ActionResults.FileStreamActionResult(file, fileName, mediaType);
        }
    }
}