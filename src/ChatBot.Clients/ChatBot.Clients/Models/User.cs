using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Clients.Core.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Token { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }

        public bool LoggedInWithFacebookAccount { get; set; }
    }
}
