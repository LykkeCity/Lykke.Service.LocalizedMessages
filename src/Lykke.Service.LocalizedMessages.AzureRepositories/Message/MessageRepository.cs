using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.LocalizedMessages.Core.Domain;
using Lykke.Service.LocalizedMessages.Core.Domain.Messages;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.LocalizedMessages.AzureRepositories.Message
{
    public class MessageRepository : IMessageRepository
    {
        private readonly INoSQLTableStorage<MessageLocalizedEntity> _tableStorage;

        public MessageRepository(INoSQLTableStorage<MessageLocalizedEntity> tableStorage)
        {
            _tableStorage = tableStorage;
        }

        public static string MakeMessageId(string code, string component)
        {
            return $"{component}::{code}";
        }

        public async Task<IMessageLocalized> GetLocalizedByMessageCode(string messageCode, string component, string local)
        {
            var id = MakeMessageId(messageCode, component);
            var entity = await _tableStorage.GetDataAsync(id, local);
            return entity;
        }

        public async Task<IReadOnlyList<IMessageLocalized>> GetAllTranslationByMessageAsync(string messageCode, string component)
        {
            var id = MakeMessageId(messageCode, component);
            var entities = await _tableStorage.GetDataAsync(id);
            return entities.Cast<IMessageLocalized>().ToList();
        }

        public async Task<IReadOnlyList<IMessageLocalized>> GetAllTranslationByComponentAsync(string componentName)
        {
            TableQuery<MessageLocalizedEntity> query = new TableQuery<MessageLocalizedEntity>()
                .Where(TableQuery.GenerateFilterCondition("Component", QueryComparisons.Equal, "componentName"));
            var entities = await _tableStorage.WhereAsync(query);
            return entities.Cast<IMessageLocalized>().ToList();
        }

        public async Task<IReadOnlyList<IMessageLocalized>> GetAllTranslationAsync()
        {
            var entities = await _tableStorage.GetDataAsync();
            return entities.Cast<IMessageLocalized>().ToList();
        }
    }
}
