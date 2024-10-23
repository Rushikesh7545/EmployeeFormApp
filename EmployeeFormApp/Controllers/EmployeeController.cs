using EmployeeFormApp.Data;
using EmployeeFormApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFormApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();
            ViewBag.Employees = employees;
            return View(new Employee());
        }
        [HttpPost]
        public async Task<IActionResult> Save(Employee emp)
        {
            _context.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employee.FindAsync(id); 
            if (employee == null)
            {
                return NotFound(); 
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            _context.Update(emp); 
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
