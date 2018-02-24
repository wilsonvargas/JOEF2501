using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

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
    }
}