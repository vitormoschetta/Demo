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
    public class EditModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }  

        [BindProperty()]
        public Models.Produto Produto { get; set; }


        public async Task<IActionResult> OnGet(Guid? Id)
        {
            if (Id == Guid.Empty) return NotFound();

            Produto = await _context.Produto.FirstOrDefaultAsync(x => x.Id == Id);            
            if (Produto == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid) return Page();
            
            Produto = await _context.Produto.FirstOrDefaultAsync(x => x.Id == id);
            if (await TryUpdateModelAsync<Models.Produto>(Produto, "produto", x => x.Nome))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }

    }
}