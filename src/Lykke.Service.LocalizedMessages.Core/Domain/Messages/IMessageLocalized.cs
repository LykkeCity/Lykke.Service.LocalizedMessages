namespace Lykke.Service.LocalizedMessages.Core.Domain.Messages
{
    /// <summary>
    /// Model of localized messsage
    /// </summary>
    public interface IMessageLocalized : IMessage
    {
        /// <summary>
        /// Message locale
        /// </summary>
        string Local { get; }

        /// <summary>
        /// Localised text of message
        /// </summary>
        string Text { get; }
    }
}
