using Lykke.Service.LocalizedMessages.Core.Settings.ServiceSettings;
using Lykke.Service.LocalizedMessages.Core.Settings.SlackNotifications;

namespace Lykke.Service.LocalizedMessages.Core.Settings
{
    public class AppSettings
    {
        public LocalizedMessagesSettings LocalizedMessagesService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
