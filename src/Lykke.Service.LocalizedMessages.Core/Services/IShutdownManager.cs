﻿using System.Threading.Tasks;

namespace Lykke.Service.LocalizedMessages.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}