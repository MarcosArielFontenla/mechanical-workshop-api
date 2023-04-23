using MechanicalWorkshop.Core.Models;
using MechanicalWorkshop.Core.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MechanicalWorkshop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetAllBudgets()
        {
            return Ok(await _budgetRepository.GetAllBudgetsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBudgetById(int id)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(id);

            if (budget is null)
                return NotFound();

            return Ok(budget);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBudget(int id, Budget budget)
        {
            if (id != budget.BudgetId)
                return BadRequest();

            var existingBudget = await _budgetRepository.GetBudgetByIdAsync(id);

            if (existingBudget is null)
                return NotFound();

            existingBudget.Date = budget.Date;
            existingBudget.Client = budget.Client;
            existingBudget.Services = budget.Services;
            existingBudget.SpareParts = budget.SpareParts;
            await _budgetRepository.UpdateBudgetAsync(existingBudget);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBudgetAsync(int id)
        {
            var getBudgetFromId = await _budgetRepository.GetBudgetByIdAsync(id);

            if (getBudgetFromId is null)
                return NotFound();

            await _budgetRepository.DeleteBudgetAsync(id);
            return NoContent();
        }
    }
}
