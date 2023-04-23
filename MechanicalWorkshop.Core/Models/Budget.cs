using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshop.Core.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; } = string.Empty;
        public List<Services> Services { get; set; }
        public List<SpareParts> SpareParts { get; set; }
    }
}
