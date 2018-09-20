using System.IO;
using System.Web;

namespace webapiexample.Helpers
{
    public static class CompressionHelper
    {
        public static bool IsCompressionSupported()
        {
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];

            return ((!string.IsNullOrEmpty(AcceptEncoding) && (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"))));
        }

        public static byte[] Compress(byte[] data, bool useGZipCompression = true)
        {
            System.IO.Compression.CompressionLevel compressionLevel = System.IO.Compression.CompressionLevel.Fastest;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (useGZipCompression)
                {
                    using (System.IO.Compression.GZipStream gZipStream = new System.IO.Compression.GZipStream(memoryStream, compressionLevel, true))
                    {
                        gZipStream.Write(data, 0, data.Length);
                    }
                }
                else
                {
                    using (System.IO.Compression.DeflateStream gZipStream = new System.IO.Compression.DeflateStream(memoryStream, compressionLevel, true))
                    {
                        gZipStream.Write(data, 0, data.Length);
                    }
                }

                return memoryStream.ToArray();
            }

        }
    }
}