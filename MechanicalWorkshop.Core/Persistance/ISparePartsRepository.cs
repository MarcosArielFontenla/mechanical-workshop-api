using MechanicalWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshop.Core.Persistance
{
    public interface ISparePartsRepository
    {
        Task<IEnumerable<SpareParts>> GetAllSparePartsAsync();
        Task<SpareParts> GetSparePartsByIdAsync(int partId);
        Task AddSpareParts(SpareParts spareParts);
        Task UpdateSpareParts(SpareParts spareParts);
        Task DeleteSpareParts(int id);
    }
}
