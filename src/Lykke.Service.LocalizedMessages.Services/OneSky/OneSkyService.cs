using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.LocalizedMessages.Core.Domain.OneSky;
using Lykke.Service.LocalizedMessages.Core.Services;
using Lykke.Service.LocalizedMessages.Core.Settings.ServiceSettings;

namespace Lykke.Service.LocalizedMessages.Services.OneSky
{
    public class OneSkyService : IOneSkyService
    {
        private readonly OneSkySettings _settings;

        public OneSkyService(OneSkySettings settings)
        {
            _settings = settings;
        }

        public Task<ILykkeProject> GetProjects()
        {
            var client = Lykke.OneSky.Json.OneSkyClient.CreateClient(
                _settings.PublicKey, _settings.SecretKey);

            var projectList = client.Platform.ProjectGroup.List()
        }

        public Task<Dictionary<string, string>> ExportMessages(int projectId, string fileName, string locale)
        {
            throw new System.NotImplementedException();
        }
    }
}
