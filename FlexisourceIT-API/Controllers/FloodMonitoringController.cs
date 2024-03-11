using AutoMapper;
using FlexisourceIT_API.Model;
using FlexisourceIT_ApplicationService.DTO;
using Microsoft.AspNetCore.Mvc;
using FlexisourceIT_ApplicationService.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexisourceIT_API.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace FlexisourceIT_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloodMonitoringController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFloodMonitoring _floodMonitoring;

        public FloodMonitoringController(IMapper mapper, IFloodMonitoring floodMonitoring)
        {
            _mapper = mapper;
            _floodMonitoring = floodMonitoring;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetFloodMonitoring()
        {
            var floodMonitoringDTOs = await _floodMonitoring.GetAllFloodMonitoring();
            var mappedResult = _mapper.Map<IEnumerable<FloodMonitoringDTO>, IEnumerable<FloodMonitoring>>(floodMonitoringDTOs);
            return Ok(mappedResult);
        }
    }
}
