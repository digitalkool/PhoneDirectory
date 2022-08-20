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

            

            switch (id)
                {
                    case 1:
                        this.department = "Administration";
                        break;
                    case 2:
                        this.department = "VP";
                        break;
                    case 3:
                        this.department = "VP";
                        break;
                    case 4:
                        this.department = "VP";
                        break;
                    case 5:
                        this.department = "VP";
                        break;
                    case 6:
                        this.department = "VP";
                        break;
                    default:
                        this.department = "VP";
                        break;
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
