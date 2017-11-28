﻿using System.Collections.Generic;

namespace Lykke.Service.LocalizedMessages.Core.Domain.OneSky
{
    public interface IProject
    {
        int Id { get; set; }
        string Name { get; set; }
        IReadOnlyList<string> LocaleList { get; set; }
        IReadOnlyList<string> Files { get; set; }
    }
}
