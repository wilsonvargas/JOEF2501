using ChatBot.Clients.Core.Extensions;
using ChatBot.Clients.Core.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Clients.Core
{
    public static class AppSettings
    {
        public static readonly string EndpointUri = "INSERT YOUR ENDPOINT";
        public static readonly string PrimaryKey = "INSERT YOUR PRIMARY KEY";
        public static readonly string DatabaseName = "UsersDB";
        public static readonly string CollectionName = "User";

         
        private const bool DefaultIsLogin = false;

        private static ISettings Settings => CrossSettings.Current;

        public static User User
        {
            get => Settings.GetValueOrDefault(nameof(User), default(User));

            set => Settings.AddOrUpdateValue(nameof(User), value);
        }

        public static bool IsLogin
        {
            get => Settings.GetValueOrDefault(nameof(IsLogin), DefaultIsLogin);

            set => Settings.AddOrUpdateValue(nameof(IsLogin), value);
        }
    }
}
