using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshop.Infrastructure
{
    public static class QueryHelper
    {
        public static string GetAllBudgetsQuery()
        {
            return "SELECT * FROM Budgets";
        }

        public static string GetBudgetByIdQuery()
        {
            return "SELECT * FROM Budgets WHERE BudgetId = @BudgetId";
        }

        public static string AddBudgetQuery()
        {
            return "INSERT INTO Budgets(Date, Client) VALUES(@Date, @Client)";
        }

        public static string UpdateBudgetQuery()
        {
            return "UPDATE Budgets SET Date = @Date, Client = @Client WHERE BudgetId = @BudgetId";
        }

        public static string DeleteBudgetQuery()
        {
            return "DELETE FROM Budgets WHERE BudgetId = @BudgetId";
        }
    }
}
