#pragma checksum "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_ProductCountPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5cc4c3023807c69c048a7bd81a018c2c394d68d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductCountPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductCountPartial.cshtml")]
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
#line 1 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.ViewModels.Header;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.ViewModels.Products;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\_ViewImports.cshtml"
using NixonE.ViewModels.Acoount;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5cc4c3023807c69c048a7bd81a018c2c394d68d", @"/Views/Shared/_ProductCountPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"235cdcf0228f58511ff272e7905bc8cfe584a9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductCountPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<span class=\"cart-count\">");
#nullable restore
#line 2 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_ProductCountPartial.cshtml"
                    Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
<svg width=""22"" height=""17"" viewbox=""0 0 22 17"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
    <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""M3.26711 2H0V0H4.73289L7.73289 9.5H17.7192L19.7192 1.5H22V3.5H21.2808L19.2808 11.5H6.26711L3.26711 2Z"" fill=""black""></path>
    <circle cx=""8"" cy=""14.5"" r=""2"" fill=""black""></circle>
    <circle cx=""18"" cy=""14.5"" r=""2"" fill=""black""></circle>
</svg>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BasketVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
