using AutoMapper;
using WebApi.Dto;
using WebApi.Entities;

namespace WebApi.Profiles{
    public class PresentsProfile: Profile{
        public PresentsProfile()
        {
            //Source=>target
            CreateMap<Present,PresentReadDto>();
            CreateMap<PresentCreateDto,Present>();
            //CreateMap<PresentUpdateDto,PresentItem>();
            //CreateMap<Present,PresentUpdateDto>();
        }
    }
}