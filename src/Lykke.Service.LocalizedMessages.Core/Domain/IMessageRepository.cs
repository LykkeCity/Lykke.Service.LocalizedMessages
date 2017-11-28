using Lykke.Service.LocalizedMessages.Core.Domain.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.LocalizedMessages.Core.Domain
{
    /// <summary>
    /// Service for work with messages
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Get localized message by code and component
        /// </summary>
        /// <param name="messageCode">Code of message</param>
        /// <param name="component">Component owner of code</param>
        /// <param name="local">Locale of text</param>
        /// <returns></returns>
        Task<IMessageLocalized> GetLocalizedByMessageCode(string messageCode, string component, string local);

        /// <summary>
        /// Get all localized messages by messagge code and ccomponent
        /// </summary>
        /// <param name="messageCode">code of message</param>
        /// <param name="component">component owner of message</param>
        Task<IReadOnlyList<IMessageLocalized>> GetAllTranslationByMessageAsync(string messageCode, string component);

        /// <summary>
        /// Get all localized messages by component
        /// </summary>
        /// <param name="componentName">component owner of message</param>
        /// <returns></returns>
        Task<IReadOnlyList<IMessageLocalized>> GetAllTranslationByComponentAsync(string componentName);

        /// <summary>
        /// Get all localized messages
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<IMessageLocalized>> GetAllTranslationAsync();
    }
}
