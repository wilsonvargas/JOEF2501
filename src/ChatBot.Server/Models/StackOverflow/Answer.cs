using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.Models.StackOverflow
{
    public class Answer
    {
        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("is_accepted")]
        public bool IsAccepted { get; set; }

        [JsonProperty("community_owned_date")]
        public long CommunityOwnedDate { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("last_activity_date")]
        public long LastActivityDate { get; set; }

        [JsonProperty("last_edit_date")]
        public long LastEditDate { get; set; }

        [JsonProperty("creation_date")]
        public long CreationDate { get; set; }

        [JsonProperty("answer_id")]
        public long AnswerId { get; set; }

        [JsonProperty("question_id")]
        public long QuestionId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}