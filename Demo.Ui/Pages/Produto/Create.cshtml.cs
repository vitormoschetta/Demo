using Demo.Ui.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Demo.Ui.Pages.Produto
{
    // Um tipo de ViewModel junto com Controller
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }   
        [Required]
        public string Nome { get; set; }

        // Essa propriedade faz a leitura/recebe os itens do formulário, os adicionando ao modelo Produto:
        [BindProperty()]
        public Demo.Ui.Models.Produto Produto { get; set; }


        public IActionResult OnGet()
        {            
            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Produto.Add(Produto);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Produto/Index");
        }
    }
}