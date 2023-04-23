using MechanicalWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshop.Core.Persistance
{
    public interface IServicesRepository
    {
        Task<IEnumerable<Services>> GetAllServicesAsync();
        Task<Services> GetServicesByIdAsync(int id);
        Task AddServicesAsync(Services services);
        Task UpdateServicesAsync(Services services);
        Task DeleteServicesAsync(int id);
    }
}
