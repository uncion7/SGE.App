#pragma checksum "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MunicipioDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b85992eccb86aae8a7f2cf8ac466f8b4c3f8d76b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SGE.App.Frontend.Pages.Entidades.Pages_Entidades_MunicipioDetail), @"mvc.1.0.razor-page", @"/Pages/Entidades/MunicipioDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b85992eccb86aae8a7f2cf8ac466f8b4c3f8d76b", @"/Pages/Entidades/MunicipioDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79af2762715e0b1e75b5fc1d73febb10b334e69b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Entidades_MunicipioDetail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Municipio</h1>\r\n<div class=col-3>\r\n    <table>\r\n        <tbody>\r\n            <tr>\r\n                <td class=\"table-secondary\">Id</td>\r\n                <td>");
#nullable restore
#line 11 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MunicipioDetail.cshtml"
               Write(Model.Municipio.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"table-secondary\">Nombre</td>\r\n                <td>");
#nullable restore
#line 15 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MunicipioDetail.cshtml"
               Write(Model.Municipio.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"table-secondary\">Departamento</td>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\MunicipioDetail.cshtml"
               Write(Model.Municipio.Departamento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGE.App.Frontend.Pages.MunicipioDetailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SGE.App.Frontend.Pages.MunicipioDetailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SGE.App.Frontend.Pages.MunicipioDetailModel>)PageContext?.ViewData;
        public SGE.App.Frontend.Pages.MunicipioDetailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591