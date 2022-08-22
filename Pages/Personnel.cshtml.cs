using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data;
using PhoneDirectory.Models;

namespace PhoneDirectory.Pages
{
    public class Personnel : PageModel
    {
        private readonly PhoneDirectory.Data.DirectoryContext _context;
        public string department;

        public string CurrentFilter { get; set;}
        public int CurrentDepartmentID { get; set; } = 0;

        public Personnel(PhoneDirectory.Data.DirectoryContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get;set; } = default!;

        public IList<Department> Departments { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, string searchString)
        {
            if (id == null)
            {
                return NotFound();
            }

            if ( CurrentDepartmentID == 0)
            {
                CurrentDepartmentID = (int)id;
            }

            IQueryable<Employee> employeesIQ = _context.Employees.Include(d => d.Department)
                                                                .Where(m => m.DepartmentID == id);

             if (!String.IsNullOrEmpty(searchString))
            {
                employeesIQ = employeesIQ.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }

                employeesIQ = employeesIQ.OrderBy( s => s.Title)
                                        .ThenBy( s2 => s2.LastName);     
            

            /*if (!String.IsNullOrEmpty(searchString))
            {
                employee = await _context.Employees
                            .Include( d => d.Department)
                            .Where( m => (m.DepartmentID == id) && (m.LastName.Contains(searchString) || m.FirstName.Contains(searchString)))
                            .OrderBy( s => s.Title)
                            .ThenBy( s2 => s2.LastName)
                            .ToListAsync();
            }*/

            if (employeesIQ == null)
            {
                return NotFound();
            }
            else 
            {
                Employees = await employeesIQ.AsNoTracking().ToListAsync();
            }

            IQueryable<Department> departmentIQ = _context.Departments.Where( d => d.DepartmentID == CurrentDepartmentID);
            if (departmentIQ != null)
            {
                Departments = await departmentIQ.AsNoTracking().ToListAsync();
                department = Departments[0].DepartmentName;
            }

           
            return Page();
        }

        /*public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }*/
    }
}
