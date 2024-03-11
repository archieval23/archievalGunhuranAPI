using AutoMapper;
using FlexisourceIT_ApplicationService.DTO;
using FlexisourceIT_API.Model;
using FlexisourceIT_Domain.Entities;

namespace FlexisourceIT_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<FloodMonitoringDTO, FloodMonitoring>().ReverseMap();
            CreateMap<FloodMonitoringEntities, FloodMonitoringDTO>().ReverseMap();
        }   
    }
}
