using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.Models.BingSearch
{
    public class ValueSearchResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("isFamilyFriendly")]
        public bool IsFamilyFriendly { get; set; }

        [JsonProperty("displayUrl")]
        public string DisplayUrl { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("dateLastCrawled")]
        public System.DateTimeOffset DateLastCrawled { get; set; }
    }
}