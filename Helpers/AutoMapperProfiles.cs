using System.Linq;
using AutoMapper;
using TreesAPI.Dtos;
using TreesAPI.Models;

namespace TreesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<NodeForReturnDto, Node>();
             CreateMap<NodeForCreationDto, Node>();

        }
    }
}