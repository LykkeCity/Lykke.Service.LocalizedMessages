using Lykke.Service.LocalizedMessages.Core.Domain.Messages;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.LocalizedMessages.AzureRepositories.Message
{
    public class MessageLocalizedEntity : TableEntity, IMessageLocalized
    {
        public static string GeneratePartitionKey(string messageId)
        {
            return messageId;
        }

        public static string GenerateRowKey(string local)
        {
            return local;
        }

        public string Id => PartitionKey;
        public string Code { get; set; }
        public string Component { get; set; }
        public string Local => PartitionKey;
        public string Text { get; set; }

        public static MessageLocalizedEntity Create(IMessageLocalized message)
        {
            var entity = new MessageLocalizedEntity();
            entity.PartitionKey = GeneratePartitionKey(message.Id);
            entity.RowKey = GenerateRowKey(message.Local);
            entity.Code = message.Code;
            entity.Component = message.Component;
            entity.Text = message.Text;

            return entity;
        }
    }
}
