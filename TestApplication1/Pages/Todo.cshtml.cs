using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApplication1.Data;

namespace TestApplication1.Pages
{
    public class TodoModel : PageModel
    {
        public TodoModel(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private ApplicationDbContext DbContext { get; }

        public List<Todo> Todos { get; set; }

        public void OnGet()
        {
            Todos = DbContext.Todos.ToList();
        }

        public IActionResult OnPostCreateTask(string name)
        {
            DbContext.Todos.Add(new Todo {Name = name});
            DbContext.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostCompleteTask(Guid id)
        {
            var item = DbContext.Todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
                DbContext.Todos.Remove(item);
            DbContext.SaveChanges();

            return RedirectToPage();
        }
    }
}