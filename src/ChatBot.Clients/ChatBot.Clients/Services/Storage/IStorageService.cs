using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Clients.Services.Storage
{
    public interface IStorageService
    {
        Task CreateDatabase(string databaseName);

        Task CreateDocumentCollection(string databaseName, string collectionName);

        Task<T> GetUserAsync<T>(string email);

        Task SaveUserAsync<T>(T user, string id, bool isNewItem = false);

        Task DeleteUserAsync(string id);
    }
}
