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
    public class IndexModel : PageModel
    {
        private readonly TestApplication1.Data.ApplicationDbContext _context;

        public IndexModel(TestApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; }

        public async Task OnGetAsync()
        {
            Todo = await _context.Todos.ToListAsync();
        }
    }
}
