using AutoMapper;
using FlexisourceIT_ApplicationService.DTO;
using FlexisourceIT_ApplicationService.Interface;
using FlexisourceIT_Domain.Contracts;
using FlexisourceIT_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexisourceIT_ApplicationService.Service
{
    public class FloodMonitoringService : IFloodMonitoring
    {
        private readonly IMapper _mapper;
        private readonly IFloodMonitoringRepository _floodMonitoringRepository;

        public FloodMonitoringService(IMapper mapper, IFloodMonitoringRepository floodMonitoring)
        {
            _mapper = mapper;
            _floodMonitoringRepository = floodMonitoring;
        }

        public async Task<IEnumerable<FloodMonitoringDTO>> GetAllFloodMonitoring()
        {
            try
            {
                var entities = await _floodMonitoringRepository.GetAllFloodMonitoring();
                var dtos = _mapper.Map<IEnumerable<FloodMonitoringDTO>>(entities);
                return dtos;
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

    }
}
