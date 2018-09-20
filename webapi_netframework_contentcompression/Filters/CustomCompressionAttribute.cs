using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using webapiexample.Helpers;

namespace webapiexample.Filters
{
    public class CustomCompressionAttribute : ActionFilterAttribute
    {
        //aquie se hace la compresion de la respuesta
        public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        {
            bool isCompressionSupported = CompressionHelper.IsCompressionSupported();

            //para hacer la compresion, el cliente debe solicitar que acepta compresion
            string acceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];

            if (isCompressionSupported)
            {
                var content = actionContext.Response.Content;

                var byteArray = content == null ? null : content.ReadAsByteArrayAsync().Result;

                MemoryStream memoryStream = new MemoryStream(byteArray);

                //el cliente pide compresion via GZIP
                if (acceptEncoding.Contains("gzip"))
                {
                    actionContext.Response.Content = new ByteArrayContent(CompressionHelper.Compress(memoryStream.ToArray(), true));

                    actionContext.Response.Content.Headers.Remove("Content-Type");

                    actionContext.Response.Content.Headers.Add("Content-encoding", "gzip");

                    actionContext.Response.Content.Headers.Add("Content-Type", "application/json");
                }
                //el cliente pide compresion via DEFLATE
                else
                {
                    actionContext.Response.Content = new ByteArrayContent(CompressionHelper.Compress(memoryStream.ToArray(), false));

                    actionContext.Response.Content.Headers.Remove("Content-Type");

                    actionContext.Response.Content.Headers.Add("Content-encoding", "deflate");

                    actionContext.Response.Content.Headers.Add("Content-Type", "application/json");
                }
            }

            base.OnActionExecuted(actionContext);
        }
    }
}