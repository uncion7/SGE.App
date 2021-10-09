using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGE.App.Persistencia;
using SGE.App.Dominio;

namespace SGE.App.Frontend.Pages
{
    public class MunicipioEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioMunicipio repositorioMunicipio;

        public SelectList listaDepartamentos{get; set;}
        
        [BindProperty]
        public int DeptoID {get; set;}

        [BindProperty]
        public Municipio Municipio {get; set;}

        public MunicipioEditModel(IRepositorioMunicipio repositorioMunicipio, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioMunicipio = repositorioMunicipio;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? municipioId)
        {
            var listaDepartamentosDB = _appContext.Departamentos;
            listaDepartamentos = new SelectList(listaDepartamentosDB, nameof(Departamento.Id), nameof(Departamento.Nombre)); 

            if(municipioId.HasValue)
            {
                var municipioQuery = _appContext.Municipios.Include(m => m.Departamento).FirstOrDefault(m => m.Id==municipioId);
                DeptoID = municipioQuery.Departamento.Id;
                Municipio = repositorioMunicipio.GetMunicipio(municipioId.Value);
            }
            else
            {
                Municipio = new Municipio();
            }
            
            if(Municipio==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }

        public IActionResult OnPost()
        {
            
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
            var listaDepartamentosDB = _appContext.Departamentos;
            listaDepartamentos = new SelectList(listaDepartamentosDB, nameof(Departamento.Id), nameof(Departamento.Nombre));
            Departamento depto = _appContext.Departamentos.FirstOrDefault(d => d.Id == DeptoID);
            Municipio.Departamento = depto; 
            
            if(Municipio.Id > 0)
            {
                Municipio = repositorioMunicipio.UpdateMunicipio(Municipio);
            }
            else
            {
                Municipio = repositorioMunicipio.AddMunicipio(Municipio);
            }
            return RedirectToPage("./MunicipioList");
        }
    }
}
