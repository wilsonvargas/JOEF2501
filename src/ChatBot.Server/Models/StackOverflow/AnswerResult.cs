using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.Models.StackOverflow
{
    public class AnswerResult
    {
        [JsonProperty("items")]
        public List<Answer> Answers { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("quota_max")]
        public long QuotaMax { get; set; }

        [JsonProperty("quota_remaining")]
        public long QuotaRemaining { get; set; }
    }
}