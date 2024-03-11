using FlexisourceIT_ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexisourceIT_ApplicationService.Interface
{
    public interface IFloodMonitoring
    {
        Task<IEnumerable<FloodMonitoringDTO>> GetAllFloodMonitoring();
    }
}
