#pragma checksum "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a585257e3f1f25dccf56d654fa9fc989bb69d5a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SGE.App.Frontend.Pages.Entidades.Pages_Entidades_MisGrupos), @"mvc.1.0.razor-page", @"/Pages/Entidades/MisGrupos.cshtml")]
namespace SGE.App.Frontend.Pages.Entidades
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\_ViewImports.cshtml"
using SGE.App.Frontend;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a585257e3f1f25dccf56d654fa9fc989bb69d5a5", @"/Pages/Entidades/MisGrupos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79af2762715e0b1e75b5fc1d73febb10b334e69b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Entidades_MisGrupos : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-10"">
        <h1>Mis Grupos</h1>
    </div>
</div>

<table class=""table table-striped"">
    <thead class=""table-dark"">
        <tr>
            <th>Ciclo</th>
            <th>Grupo</th>
            <th>Formador</th>
            <th>Tutor</th>
            <th>Estudiante</th>
            <th>Acciones</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 24 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
         foreach(var m in Model.MisGrupos)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
               Write(m.Grupo.Ciclo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
               Write(m.Grupo.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
               Write(m.Grupo.Formador.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
                                        Write(m.Grupo.Formador.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
               Write(m.Grupo.Tutor.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
                                     Write(m.Grupo.Tutor.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
               Write(m.Estudiante.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 31 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
                                    Write(m.Estudiante.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MisGrupos.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGE.App.Frontend.Pages.MisGruposModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SGE.App.Frontend.Pages.MisGruposModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SGE.App.Frontend.Pages.MisGruposModel>)PageContext?.ViewData;
        public SGE.App.Frontend.Pages.MisGruposModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
