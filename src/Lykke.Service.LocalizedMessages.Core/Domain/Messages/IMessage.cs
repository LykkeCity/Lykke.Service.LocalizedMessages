namespace Lykke.Service.LocalizedMessages.Core.Domain.Messages
{
    /// <summary>
    /// Base message model
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Unique Identity of message. Typical its concatinate Component and Code
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Code (key) of this message
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Component(service) owner of this message.Not Requirement.
        /// We can use same Code in different Component(service)
        /// One component can be owner of one message Code
        /// </summary>
        string Component { get; }
    }
}
