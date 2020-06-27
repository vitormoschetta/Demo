using Demo.Ui.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Ui.Pages.Produto
{
    public class DeleteModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }  

        [BindProperty()]
        public Models.Produto Produto { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid? Id)
        {
            if (Id == Guid.Empty) return NotFound();

            Produto = await _context.Produto.FirstOrDefaultAsync(x => x.Id == Id);
            if (Produto == null) return NotFound();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(Guid? Id)
        {
            if (Id == Guid.Empty) return Page();

            Produto = await _context.Produto.FirstOrDefaultAsync(x => x.Id == Id);
            if (Produto == null) return NotFound();

            _context.Produto.Remove(Produto);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Produto/Index");
        }

    }
}