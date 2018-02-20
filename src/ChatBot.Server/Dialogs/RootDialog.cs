using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatBot.Server.Services.AnalyticsService;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace ChatBot.Server.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var language = await TextAnalyticsService.DetermineLanguageAsync(activity.Text);
            await context.PostAsync($"Your language is {language}");
            context.Wait(MessageReceivedAsync);
        }
    }
}