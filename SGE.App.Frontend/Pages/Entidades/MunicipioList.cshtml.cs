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
    public class MunicipioListModel : PageModel
    {
        
        //Declara la variable de la interfase
        private readonly IRepositorioMunicipio repositorioMunicipio;
        public IEnumerable<Municipio> Municipios{get; set;}
        public MunicipioListModel(IRepositorioMunicipio repositorioMunicipio)
        {
            this.repositorioMunicipio = repositorioMunicipio;
        }
        
        public void OnGet(int? municipioId)
        {
            if(municipioId>0)
            {
                repositorioMunicipio.DeleteMunicipio(municipioId.Value);
            }
            Municipios = repositorioMunicipio.GetAllMunicipios();
        }
    }
    
}
