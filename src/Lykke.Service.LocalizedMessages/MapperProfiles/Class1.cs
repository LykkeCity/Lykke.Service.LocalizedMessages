using AutoMapper;
using Lykke.Service.LocalizedMessages.Core.Domain.Messages;
using Lykke.Service.LocalizedMessages.Models;

namespace Lykke.Service.LocalizedMessages.MapperProfiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<IMessageLocalized, MessageResponce>()
                .ForMember(e => e.Code, opt => opt.MapFrom(e => e.Code))
                .ForMember(e => e.Component, opt => opt.MapFrom(e => e.Component))
                .ForMember(e => e.Locale, opt => opt.MapFrom(e => e.Local))
                .ForMember(e => e.Test, opt => opt.MapFrom(e => e.Text));
        }

        public override string ProfileName => "Default profile";
    }
}
