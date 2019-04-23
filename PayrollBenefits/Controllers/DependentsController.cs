using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollBenefits.DataLayer;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Controllers
{
    public class DependentsController : Controller
    {
        private readonly PayrollContext _context;

        public DependentsController(PayrollContext context)
        {
            _context = context;
        }

        // GET: Dependents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dependents.ToListAsync());
        }

        // GET: Dependents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // GET: Dependents/Create
        public async Task<IActionResult> Create(int? employeeId)
        {
            if (employeeId == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["Parent"] = $"{employee.FirstName}  {employee.LastName}";

            var dependent = new Dependent() { EmployeeId = employee.Id };
            return View(dependent);
        }

        // POST: Dependents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,FirstName,LastName,Relationship")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Employees", new { id = dependent.EmployeeId });
            }
            return View(dependent);
        }

        // GET: Dependents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents.FindAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }
            return View(dependent);
        }

        // POST: Dependents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,FirstName,LastName,Relationship")] Dependent dependent)
        {
            if (id != dependent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependentExists(dependent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dependent);
        }

        // GET: Dependents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // POST: Dependents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id);
            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependentExists(int id)
        {
            return _context.Dependents.Any(e => e.Id == id);
        }
    }
}
