using MechanicalWorkshop.Core.Models;
using MechanicalWorkshop.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshop.Infrastructure.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        public Task<IEnumerable<Services>> GetAllServicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Services> GetServicesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddServicesAsync(Services services)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServicesAsync(Services services)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServicesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
