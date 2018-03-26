using ChatBot.Clients.Core.Models;
using ChatBot.Clients.Core.Services.Bot;
using ChatBot.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.ViewModels
{
    public class ChatRoomViewModel : ViewModelBase
    {
        IBotService service;

        #region Properties
        private ObservableCollection<Activity> activity;

        public ObservableCollection<Activity> Activities
        {
            get
            {
                return activity;
            }
            set
            {
                activity = value;
                OnPropertyChanged();
            }
        }

        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand LoadCommand => new Command(async () => await Load());
        public ICommand SendCommand => new Command(async () => await Send());

        public ChatRoomViewModel(IBotService service)
        {
            this.service = service;
            Activities = new ObservableCollection<Activity>();
        }

        public async Task Load()
        {
            IsBusy = true;
            var activity = await service.Connect();
            Activities.Add(activity);
            IsBusy = false;
        }

        private async Task Send()
        {
            var messageToSend = new Activity()
            {
                From = new UserMessage() { Id = Guid.NewGuid().ToString(), Name = AppSettings.User.UserName },
                Text = this.Text,
                ConversationId = new ConversationId() { Id = AppSettings.ConversationId },
                Timestamp = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Type = "message"
            };
            Activities.Add(messageToSend);
            Text = string.Empty;
            MessagingCenter.Send<object, object>(this, "AutoScroll", Activities.Last());
            IsBusy = true;
            var activity = await service.SendMessage(messageToSend);
            Activities.Add(activity);
            IsBusy = false;
            MessagingCenter.Send<object, object>(this, "AutoScroll", Activities.Last());
        }
    }
}
