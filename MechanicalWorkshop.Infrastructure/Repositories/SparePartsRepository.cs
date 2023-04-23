using MechanicalWorkshop.Core.Models;
using MechanicalWorkshop.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshop.Infrastructure.Repositories
{
    public class SparePartsRepository : ISparePartsRepository
    {
        public Task<IEnumerable<SpareParts>> GetAllSparePartsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SpareParts> GetSparePartsByIdAsync(int partId)
        {
            throw new NotImplementedException();
        }

        public Task AddSpareParts(SpareParts spareParts)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSpareParts(SpareParts spareParts)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSpareParts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
