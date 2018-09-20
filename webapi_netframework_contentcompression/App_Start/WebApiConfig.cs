using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using System.Web.Mvc;
using webapiexample.Filters;

namespace webapiexample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //apply compression filter for all controllers
            config.Filters.Add(new CustomCompressionAttribute());            
        }
    }
}
