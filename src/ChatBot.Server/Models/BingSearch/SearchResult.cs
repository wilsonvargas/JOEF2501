using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.Models.BingSearch
{
    struct SearchResult
    {
        public String jsonResult;
        public Dictionary<String, String> relevantHeaders;
    }
}