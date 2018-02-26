using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ChatBot.Server.Models.BingSearch;

namespace ChatBot.Server.Helpers
{
    public static class Util
    {
        private static readonly Regex StackOverflowQuestionRegex = new Regex(@"stackoverflow\.com/questions/?([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static string GetIdQuestion(string url) {
            
            Match stackOverflowMatch = StackOverflowQuestionRegex.Match(url);

            string id = string.Empty;

            if (stackOverflowMatch.Success)
                id = stackOverflowMatch.Groups[1].Value;

            return id;
        }

        public static ValueSearchResult GetBestResult(List<ValueSearchResult> results)
        {
            Match match;
            ValueSearchResult result = null;
            foreach (var page in results)
            {
                match = StackOverflowQuestionRegex.Match(page.Url);
                if (match.Success)
                {
                    result = page;
                    break;
                }
            }
            return result;
        }
    }
}