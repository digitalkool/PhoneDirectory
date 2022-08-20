using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data;
using PhoneDirectory.Models;

namespace PhoneDirectory.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly PhoneDirectory.Data.DirectoryContext _context;

        public string CurrentFilterPhone {get; set;}
        public string CurrentFilterName { get; set;}

        public IndexModel(PhoneDirectory.Data.DirectoryContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string searchType, string searchString)
        {
        
            IQueryable<Employee> employeesIQ = _context.Employees.Include(d => d.Department);
                                                                
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

            Employee = await employeesIQ.AsNoTracking().ToListAsync();
                
            return Page();
        }
    }
}
