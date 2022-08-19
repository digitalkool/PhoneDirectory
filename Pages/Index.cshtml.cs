using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneDirectory.Models;

namespace PhoneDirectory.Pages;

public class IndexModel : PageModel
{
    private readonly PhoneDirectory.Data.DirectoryContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(PhoneDirectory.Data.DirectoryContext context,ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IList<Department> Department { get;set; } = default!;

    /*public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }*/

    public void OnGet()
    {
        if (_context.Departments != null)
        {
            Department = _context.Departments.ToList();
        }

    }


    /*public async Task OnGetAsync()
    {
        if (_context.Departments != null)
        {
            Department = await _context.Departments.ToListAsync();
        }
    }*/
}
