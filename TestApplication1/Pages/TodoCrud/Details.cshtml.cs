using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestApplication1.Data;

namespace TestApplication1.Pages.TodoCrud
{
    public class DetailsModel : PageModel
    {
        private readonly TestApplication1.Data.ApplicationDbContext _context;

        public DetailsModel(TestApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);

            if (Todo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
