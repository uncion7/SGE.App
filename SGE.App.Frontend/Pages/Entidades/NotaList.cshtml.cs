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
    public class NotaListModel : PageModel
    {
        private readonly IRepositorioNota repositorioNota;
        public IEnumerable<Nota> Notas {get;set;}
        public NotaListModel(IRepositorioNota repositorioNota)
        {
            this.repositorioNota = repositorioNota;
        }
        public void OnGet(int? notaId)
        {
            if(notaId > 0)
            {
                repositorioNota.DeleteNota(notaId.Value);
            }
            Notas = repositorioNota.GetAllNotas();
        }
    }
}
