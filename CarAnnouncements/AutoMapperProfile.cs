using AutoMapper;
using CarAnnouncements.DTO;
using CarAnnouncements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAnnouncements
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(dest => dest.MarkId, opt => opt.MapFrom(x => x.Model.MarkId))
                .ForMember(dest => dest.ImagesId, opt => opt.MapFrom(x => x.Images.Select(x => x.Id)));
                ;




        }
    }
}
