using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.LocalizedMessages.Core.Domain.OneSky;

namespace Lykke.Service.LocalizedMessages.Core.Services
{
    /// <summary>
    /// Service - wrapper on OneSky api
    /// </summary>
    public interface IOneSkyService
    {
        Task<ILykkeProject> GetProjects();
        Task<Dictionary<string, string>> ExportMessages(int projectId, string fileName, string locale);
    }
}
