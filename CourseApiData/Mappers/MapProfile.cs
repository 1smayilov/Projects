using AutoMapper;
using CourseApiData.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseApiData.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Group, GroupGetDto>().ReverseMap();
            CreateMap<GroupPostDto, Group>();
        }
    }
}
