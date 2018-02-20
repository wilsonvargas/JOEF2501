using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatBot.Server.Services.AnalyticsService
{
    public class TextAnalyticsService
    {
        #region Properties
        public static TextAnalyticsAPI client;
        public static TextAnalyticsAPI Client
        {
            get
            {
                if (client == null)
                {
                    client = new TextAnalyticsAPI();
                    client.AzureRegion = AzureRegions.Eastus2;
                    client.SubscriptionKey = AppSettings.TextAnalyserKey;
                }
                return client;
            }
        }
        #endregion

        public static async Task<string> DetermineLanguageAsync(string sentence)
        {
            var input = new Input(new Guid().ToString(), sentence);

            LanguageBatchResult resultLanguage = await Client.DetectLanguageAsync(
                new BatchInput(new List<Input>() { input}));

            return resultLanguage.Documents[0].DetectedLanguages[0].Name;
        }
}
}