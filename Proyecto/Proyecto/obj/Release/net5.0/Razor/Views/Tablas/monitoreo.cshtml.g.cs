#pragma checksum "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f109ca93f0c7199c6d12a530df950d8821609df1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tablas_monitoreo), @"mvc.1.0.view", @"/Views/Tablas/monitoreo.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\_ViewImports.cshtml"
using Proyecto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\_ViewImports.cshtml"
using Proyecto.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f109ca93f0c7199c6d12a530df950d8821609df1", @"/Views/Tablas/monitoreo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35ccd0e355aa1d66d4794e50f98f1a22ffd693d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Tablas_monitoreo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Proyecto.Models.Dispositivo>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml"
  
    int cont = 1;
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 10 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml"
     foreach (var device in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("id", " id=\"", 290, "\"", 305, 1);
#nullable restore
#line 12 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml"
WriteAttributeValue("", 295, device.Id, 295, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("class=\"col-sm-12 col-md-4\">\r\n            <div");
            BeginWriteAttribute("id", " id=\"", 351, "\"", 371, 2);
#nullable restore
#line 13 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml"
WriteAttributeValue("", 356, device.Id, 356, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 366, "-graf", 366, 5, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"graf\">\r\n            </div>\r\n            <div class=\"device\">\r\n                ");
#nullable restore
#line 16 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml"
           Write(device.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""temperatura"">
                Temperatura actual:
            </div>
            <div class=""rango"">
                rango
            </div>
            <div class=""fecha"">
                fecha
            </div>

        </div>
");
#nullable restore
#line 29 "C:\Users\Esteban\OneDrive\Escritorio\2021_2\Programacion Web\proyecto\Client-Server\Proyecto\Proyecto\Views\Tablas\monitoreo.cshtml"
        cont++;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Proyecto.Models.Dispositivo>> Html { get; private set; }
    }
}
#pragma warning restore 1591