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

        public string CurrentFilterName { get; set;}

        public string CurrentFilterPhone { get; set;}
        public int CurrentDepartmentID { get; set; } = 0;

        public Personnel(PhoneDirectory.Data.DirectoryContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get;set; } = default!;

        public IList<Department> Departments { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, string searchType, string searchString)
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
                switch (searchType)
                {
                    case "name":
                    employeesIQ = employeesIQ.Where(s => s.LastName.Contains(searchString)
                                                || s.FirstName.Contains(searchString));
                    CurrentFilterName = searchString;
                    break;
                    case "phone":
                    employeesIQ = employeesIQ.Where(s => s.Phone1.Contains(searchString)
                                                || s.Phone2.Contains(searchString)
                                                || s.Ext.Contains(searchString));
                    CurrentFilterPhone = searchString;
                    break;
                    default:
                        break;
                } 

            }

                employeesIQ = employeesIQ.OrderBy( s => s.Title)
                                        .ThenBy( s2 => s2.LastName);     
            
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
 
    }
}
