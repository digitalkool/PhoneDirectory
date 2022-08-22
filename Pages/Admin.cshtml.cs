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
    public class Admin : PageModel
    {
        private readonly PhoneDirectory.Data.DirectoryContext _context;
        public string department;

        public string CurrentFilterName { get; set;}

        public string CurrentFilterPhone { get; set;}
        public int CurrentDepartmentID { get; set; } = 0;

        public Admin(PhoneDirectory.Data.DirectoryContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
           
        }
 
    }
}
