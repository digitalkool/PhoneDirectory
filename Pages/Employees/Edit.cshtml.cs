using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data;
using PhoneDirectory.Models;

namespace PhoneDirectory.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly PhoneDirectory.Data.DirectoryContext _context;

        public SelectList DepartmentNameSL { get; set;}

        public IEnumerable<SelectListItem> TitlesList {get; set;}

        public EditModel(PhoneDirectory.Data.DirectoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee =  await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            object selectedDepartment = employee.Department;

            var departmentsIQ = from d in _context.Departments
                                    orderby d.DepartmentName
                                    select d;
            DepartmentNameSL = new SelectList(departmentsIQ,
                        "DepartmentID", "DepartmentName", selectedDepartment);

            IEnumerable<Title> values = Enum.GetValues(typeof(Title)).Cast<Title>();                        

            TitlesList = from v in values
                        select new SelectListItem()
                        {
                            Text = v.ToString(),
                            Value = v.ToString()
                        };

            
            Employee = employee;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EmployeeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
          return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
