using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Server.LUIS
{
    public static class ChatResponse
    {
        public static readonly string Greeting = "Hola, soy JOEF-2501 estoy encantado de ayudarte con tu dudas en programación. Cual es tu duda?";

        public static readonly string Farewell = "Me alegro de poder ayudarte";

        public static readonly string Default = "Lo siento, no entendí. Me puedes repetir la pregunta por favor?";

        public static readonly string Question = "Oh right, let me think about this!";

        public static readonly string Error = "This error is horrible!";
    }
}