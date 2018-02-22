using ChatBot.Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ChatBot.Server.Services.SearchService
{
    public static class SearchQueryService
    {

        #region Properties

        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                    _client.DefaultRequestHeaders.Add(AppSettings.OcpApimSubscriptionKeyHeader, AppSettings.TranslatorKey);
                }
                return _client;
            }
        }
        #endregion

        public static string SearchQueryId(string query) {
            SearchResult result = BingWebSearch(query);
            
            return result.jsonResult;
        }


        /// <summary>
        /// Performs a Bing Web search and return the results as a SearchResult.
        /// </summary>
        private static SearchResult BingWebSearch(string searchQuery)
        {
            // Construct the URI of the search request
            var uriQuery = AppSettings.SearchUriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform the Web request and get the response
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = AppSettings.SearchApiKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // Create result object for return
            var searchResult = new SearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };

            // Extract Bing HTTP headers
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    searchResult.relevantHeaders[header] = response.Headers[header];
            }

            return searchResult;
        }

    }
}