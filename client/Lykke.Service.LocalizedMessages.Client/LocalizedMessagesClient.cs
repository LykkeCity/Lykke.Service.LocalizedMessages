using System;
using Common.Log;

namespace Lykke.Service.LocalizedMessages.Client
{
    public class LocalizedMessagesClient : ILocalizedMessagesClient, IDisposable
    {
        private readonly ILog _log;

        public LocalizedMessagesClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
