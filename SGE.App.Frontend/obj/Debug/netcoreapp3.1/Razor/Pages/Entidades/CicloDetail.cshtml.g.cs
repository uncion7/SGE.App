<<<<<<< HEAD
#pragma checksum "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3496214ae4fc1b0757d2cb3a5835cdd4c493395"
=======
#pragma checksum "D:\Mis Documentos\Ucaldas\DSR\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d8457b571c44da8c425b254aea6b79cad4133dd"
>>>>>>> 287978502012ea057807ae83f5039db5fb6de68f
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SGE.App.Frontend.Pages.Entidades.Pages_Entidades_CicloDetail), @"mvc.1.0.razor-page", @"/Pages/Entidades/CicloDetail.cshtml")]
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
<<<<<<< HEAD
#line 1 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\_ViewImports.cshtml"
=======
#line 1 "D:\Mis Documentos\Ucaldas\DSR\SGE.App\SGE.App.Frontend\Pages\_ViewImports.cshtml"
>>>>>>> 287978502012ea057807ae83f5039db5fb6de68f
using SGE.App.Frontend;

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3496214ae4fc1b0757d2cb3a5835cdd4c493395", @"/Pages/Entidades/CicloDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79af2762715e0b1e75b5fc1d73febb10b334e69b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Entidades_CicloDetail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Listar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./CicloList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-10\">\r\n        <h1>Ciclo:");
#nullable restore
#line 7 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
             Write(Model.Ciclo.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n    <div class=\"col-2 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3496214ae4fc1b0757d2cb3a5835cdd4c4933955156", async() => {
                WriteLiteral("\r\n            <i class=\"fas fa-list-ul\"></i>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=row>\r\n    <div class=col-4>\r\n        <table class=\"table table-striped table-bordered\">\r\n            <tbody>\r\n                <tr>\r\n                    <td>Id</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
                   Write(Model.Ciclo.Id);
=======
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d8457b571c44da8c425b254aea6b79cad4133dd", @"/Pages/Entidades/CicloDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79af2762715e0b1e75b5fc1d73febb10b334e69b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Entidades_CicloDetail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Ciclo</h1>\r\n<p>Id: ");
#nullable restore
#line 7 "D:\Mis Documentos\Ucaldas\DSR\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
  Write(Model.Ciclo.Id);
>>>>>>> 287978502012ea057807ae83f5039db5fb6de68f

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Nombre</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
                   Write(Model.Ciclo.Nombre);
=======
            WriteLiteral("</p>\r\n<p>Nombre: ");
#nullable restore
#line 8 "D:\Mis Documentos\Ucaldas\DSR\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
      Write(Model.Ciclo.Nombre);
>>>>>>> 287978502012ea057807ae83f5039db5fb6de68f

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Codigo</td>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\mcordoba\Documents\UCALDAS\CICLO3\proyectos\Educa\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
                   Write(Model.Ciclo.Codigo);
=======
            WriteLiteral("</p>\r\n<p>Codigo: ");
#nullable restore
#line 9 "D:\Mis Documentos\Ucaldas\DSR\SGE.App\SGE.App.Frontend\Pages\Entidades\CicloDetail.cshtml"
      Write(Model.Ciclo.Codigo);
>>>>>>> 287978502012ea057807ae83f5039db5fb6de68f

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
=======
            WriteLiteral("</p>\r\n<a ap-page = \"./CicloList\" class = \"btn btn-primary\" data-toggle = \"toolip\" data-placement = \"top\" title = \"Listar\">\r\n    <i class = \"fas fa-list-ul\"></i>\r\n</a>");
>>>>>>> 287978502012ea057807ae83f5039db5fb6de68f
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGE.App.Frontend.Pages.CicloDetailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SGE.App.Frontend.Pages.CicloDetailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SGE.App.Frontend.Pages.CicloDetailModel>)PageContext?.ViewData;
        public SGE.App.Frontend.Pages.CicloDetailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
