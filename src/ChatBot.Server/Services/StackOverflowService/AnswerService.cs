using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChatBot.Server.Services.StackOverflowService
{
    public class AnswerService
    {
        #region Properties

        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient(
                        new HttpClientHandler
                        {
                            AutomaticDecompression = DecompressionMethods.GZip
                                     | DecompressionMethods.Deflate
                        });
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return _client;
            }
        }
        #endregion

        public static async Task<string> GetJsonFromStackOverflow(string id) {

            string uri = $"{AppSettings.StackOverflowHost}{id}{AppSettings.StackOverflowPath}";

            HttpResponseMessage response = await Client.GetAsync(uri);
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}