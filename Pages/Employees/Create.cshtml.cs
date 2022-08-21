using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneDirectory.Data;
using PhoneDirectory.Models;

namespace PhoneDirectory.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly PhoneDirectory.Data.DirectoryContext _context;
        public SelectList DepartmentNameSL { get; set;}

        public CreateModel(PhoneDirectory.Data.DirectoryContext context)
        {       
            _context = context;
        }

        public IActionResult OnGet()
        {
            object selectedDepartment = null;
            var departmentsIQ = from d in _context.Departments
                                    orderby d.DepartmentName
                                    select d;
            DepartmentNameSL = new SelectList(departmentsIQ,
                        "DepartmentID", "DepartmentName", selectedDepartment);
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            var emptyEmployee = new Employee();

                if (await TryUpdateModelAsync<Employee>(
                    emptyEmployee,
                    "Employee",   // Prefix for form value.
                    s => s.LastName,
                    s => s.FirstName,
                    s => s.DepartmentID,
                    s => s.Title,
                    s => s.Email,
                    s => s.Phone1,
                    s => s.Ext,
                    s => s.Phone2,
                    s => s.Notes
                    ))
                {
                    _context.Employees.Add(emptyEmployee);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }


                return Page();

        }
    }
}
