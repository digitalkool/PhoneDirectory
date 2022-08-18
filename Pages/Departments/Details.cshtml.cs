using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data;
using PhoneDirectory.Models;

namespace PhoneDirectory.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly PhoneDirectory.Data.DirectoryContext _context;

        public DetailsModel(PhoneDirectory.Data.DirectoryContext context)
        {
            _context = context;
        }

      public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }
            return Page();
        }
    }
}
