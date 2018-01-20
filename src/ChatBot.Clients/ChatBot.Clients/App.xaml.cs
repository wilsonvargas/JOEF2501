using ChatBot.Clients.Views;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ChatBot.Clients
{
	public partial class App : Application
	{
        #region Properties
        public static DocumentClient _clients;
        public static Uri _collectionLink;
        public static DocumentClient Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new DocumentClient(new Uri(AppSettings.EndpointUri), AppSettings.PrimaryKey);
                }
                return _clients;
            }
        }
        public static Uri CollectionLink
        {
            get
            {
                if (_collectionLink == null)
                {
                    _collectionLink = UriFactory.CreateDocumentCollectionUri(AppSettings.DatabaseName, AppSettings.CollectionName);
                }
                return _collectionLink;
            }
        }
        #endregion

        public App ()
		{
			InitializeComponent();

			MainPage = new MainView();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
