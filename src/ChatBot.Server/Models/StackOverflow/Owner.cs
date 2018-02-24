using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.Models.StackOverflow
{
    public class Owner
    {
        [JsonProperty("reputation")]
        public long? Reputation { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("accept_rate")]
        public long? AcceptRate { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}