using AutoMapper;
using EmployeeApiData.DTOs.Positions;
using EmployeeApiData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiData.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Positions, PositionsGetDTO>().ReverseMap();
            CreateMap<PositionsPostDTO, Positions>();
        }
    }
}
