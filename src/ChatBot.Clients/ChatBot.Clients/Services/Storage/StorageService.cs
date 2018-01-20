using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Clients.Services.Storage
{
    public class StorageService : IStorageService
    {

        public async Task CreateDatabase(string databaseName)
        {
            try
            {
                await App.Clients.CreateDatabaseIfNotExistsAsync(new Database
                {
                    Id = databaseName
                });
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Create Database Error: ", ex.Message);
            }
        }

        public async Task CreateDocumentCollection(string databaseName, string collectionName)
        {
            try
            {
                await App.Clients.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection
                    {
                        Id = collectionName
                    },
                    new RequestOptions
                    {
                        OfferThroughput = 400
                    });
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Create Document Error: ", ex.Message);
            }
        }

        public Task DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetUserAsync<T>(string email)
        {
            var items = new List<T>();
            try
            {
                var query = App.Clients.CreateDocumentQuery<Models.User>(App.CollectionLink)
                            .Where(f => f.Email == email)
                            .AsDocumentQuery();
                while (query.HasMoreResults)
                {
                    items.AddRange(await query.ExecuteNextAsync<T>());
                }
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Get Items Error: ", ex.Message);
            }

            return items.FirstOrDefault();
        }

        public async Task SaveUserAsync<T>(T user, string id, bool isNewItem = false)
        {
            try
            {
                if (isNewItem)
                {
                    await App.Clients.CreateDocumentAsync(App.CollectionLink, user);
                }
                else
                {
                    await App.Clients.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(AppSettings.DatabaseName, AppSettings.CollectionName, id), user);
                }
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Save Error: ", ex.Message);
            }
        }
    }
}
