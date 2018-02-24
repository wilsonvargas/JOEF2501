using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.Models.BingSearch
{
    public partial class SearchApiResult
    {
        [JsonProperty("webPages")]
        public WebPage WebPages { get; set; }
    }
    
    public class WebPage
    {
        [JsonProperty("webSearchUrl")]
        public string WebSearchUrl { get; set; }

        [JsonProperty("totalEstimatedMatches")]
        public long TotalEstimatedMatches { get; set; }

        [JsonProperty("value")]
        public List<ValueSearchResult> Value { get; set; }

        [JsonProperty("someResultsRemoved")]
        public bool SomeResultsRemoved { get; set; }
    }
    
}