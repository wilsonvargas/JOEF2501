using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.LUIS
{
    public static class ChatResponse
    {
        public static readonly string Greeting = "Hi, I'm JOEF-2501 I'm so happy to help you with your programming questions. Tell me what's your question?";

        public static readonly string Farewell = "Thanks for chatting. Goodbye.";

        public static readonly string Default = "Sorry I didn't understand. Can you say that again please?";

        public static readonly string Question = "Oh right, let me think about this!";

        public static readonly string Error = "This error is horrible!";
    }
}