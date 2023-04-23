using MechanicalWorkshop.Core.Models;
using MechanicalWorkshop.Core.Persistance;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MechanicalWorkshop.Infrastructure.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly string _connectionString;

        public BudgetRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Budget>> GetAllBudgetsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(QueryHelper.GetAllBudgetsQuery(), connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var result = new List<Budget>();

                        while (await reader.ReadAsync())
                        {
                            var budget = new Budget
                            {
                                BudgetId = reader.GetInt32(reader.GetOrdinal("BudgetId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Client = reader.GetString(reader.GetOrdinal("Client")),
                                Services = new List<Services>(),
                                SpareParts = new List<SpareParts>()
                            };
                            result.Add(budget);
                        }
                        return result;
                    }
                }
            }
        }

        public async Task<Budget> GetBudgetByIdAsync(int budgetId)
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                await connection.OpenAsync();
                
                using (var command = new SqlCommand(QueryHelper.GetBudgetByIdQuery(), connection))
                {
                    command.Parameters.AddWithValue("@BudgetId", budgetId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var budget = new Budget
                            {
                                BudgetId = reader.GetInt32(reader.GetOrdinal("BudgetId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Client = reader.GetString(reader.GetOrdinal("Client")),
                                Services = new List<Services>(),
                                SpareParts = new List<SpareParts>()
                            };
                            return budget;
                        }
                        return null;
                    }
                }
            }
        }

        public async Task AddBudgetAsync(Budget budget)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(QueryHelper.AddBudgetQuery(), connection))
                {
                    command.Parameters.AddWithValue("@Date", budget.Date);
                    command.Parameters.AddWithValue("@client", budget.Client);
                    budget.BudgetId = Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task UpdateBudgetAsync(Budget budget)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(QueryHelper.UpdateBudgetQuery(), connection))
                {
                    command.Parameters.AddWithValue("@BudgetId", budget.BudgetId);
                    command.Parameters.AddWithValue("@Date", budget.Date);
                    command.Parameters.AddWithValue("@Client", budget.Client);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteBudgetAsync(int budgetId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(QueryHelper.DeleteBudgetQuery(), connection))
                {
                    command.Parameters.AddWithValue("@BudgetId", budgetId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
