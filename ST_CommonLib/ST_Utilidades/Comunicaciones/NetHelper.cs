using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ST.Utilidades.Comunicaciones
{

    public static class NetHelper
    {
        public static async Task<bool> UrlExists(Uri tryURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tryURL);
            request.Method = "HEAD";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        /// <summary>
        /// Sends the specified byte array of data to the specified url.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="uploadUrl"></param>
        /// <param name="uriParameters">Optional url parameters</param>
        /// <param name="userName">Basic authentication username</param>
        /// <param name="password">Basic authentication password</param>
        /// <returns></returns>
        public static async Task<string> PostFile(byte[] file, string fileName, string uploadUrl, string uriParameters = null, string userName = null, string password = null)
        {
            string result = null;
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    if (!string.IsNullOrEmpty(userName))
                        handler.Credentials = new NetworkCredential(userName, password);

                    // Post it along with the specified parameters
                    using (var httpClient = new HttpClient(handler))
                    {
                        var cacheControl = new CacheControlHeaderValue();
                        cacheControl.NoCache = true;
                        httpClient.DefaultRequestHeaders.CacheControl = cacheControl;

                        // Otra forma de especificar credenciales
                        //if (!string.IsNullOrEmpty(userName))
                        //{
                        //    var byteArray = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", userName, password));
                        //    var header = new AuthenticationHeaderValue(
                        //               "Basic", Convert.ToBase64String(byteArray));
                        //    httpClient.DefaultRequestHeaders.Authorization = header;
                        //}

                        HttpContent fileContent = new ByteArrayContent(file);// new StreamContent(await file.OpenStreamForReadAsync());

                        fileContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileName + "\"");

                        var content = new MultipartFormDataContent();

                        content.Add(fileContent);

                        string uri = uploadUrl;
                        if (!string.IsNullOrEmpty(uriParameters))
                        {
                            uri += "?" + uriParameters;
                        }

                        var response = await httpClient.PostAsync(new Uri(uri), content);
                        result = await response.Content.ReadAsStringAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("NetHelper was unable to upload the file.", ex);
            }

            return result;
        }
    }
}
