using Demo.Ui.Data;
using Demo.Ui.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Ui.Pages.Produto
{
    // Um tipo de ViewModel junto com Controller
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Models.Produto> Produtos { get; set; }

        public async Task OnGetAsync()
        {
            Produtos = await _context.Produto.ToListAsync();
        }
    }
}