using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGE.App.Persistencia;
using SGE.App.Dominio;

namespace SGE.App.Frontend.Pages
{
    public class NotaDetailModel : PageModel
    {
        private readonly IRepositorioNota repositorioNota;
        public Nota Nota {get; set;}

        public NotaDetailModel(IRepositorioNota repositorioNota)
        {
            this.repositorioNota = repositorioNota;
        }

        public IActionResult OnGet(int notaId)
        {
            Nota = repositorioNota.GetNota(notaId);
            if(Nota==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
