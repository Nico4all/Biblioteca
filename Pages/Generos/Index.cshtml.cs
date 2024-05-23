using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Pages.Generos
{
    [Authorize]
    public class IndexModel : PageModel
        {
            private readonly BibliotecaContext _context;

            public IndexModel(BibliotecaContext context)
            {
                _context = context;
            }

            public IList<Genero> Generos { get; set; }

            public async Task OnGetAsync()
            {
                Generos = await _context.Generos.ToListAsync();
            }
        }
    }

