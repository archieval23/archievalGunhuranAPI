using FlexisourceIT_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntity = FlexisourceIT_Domain.Entities;
namespace FlexisourceIT_Domain.Contracts
{
    public interface IFloodMonitoringRepository
    {
        Task<IEnumerable<FloodMonitoringEntities>> GetAllFloodMonitoring();
    }
}
