#pragma checksum "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23bbc49b83c5f577a24debac8ec706c8c6099830"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23bbc49b83c5f577a24debac8ec706c8c6099830", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"235cdcf0228f58511ff272e7905bc8cfe584a9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RegisterVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Account\Register.cshtml"
  
    ViewData["Title"] = "Register";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main role=""main"" id=""loginPage"">
    <div class=""layout-main-content"">
        <div class=""customer-login"">
            <div class=""layout-content-wrapper pt-5"">
                <div class=""container"">
                    <div class=""row justify-content-center"">
                        <div class=""col-lg-8"">
                            <div class=""form-success alert alert-success text-center hide"">
                                We've sent you an email with a link to update your password.
                            </div>
                            <div class=""row justify-content-md-around"">
                                <div class=""col-lg-6"">
                                    <h2>
                                        Create Account
                                    </h2>
                                    <div class=""p2"">
                                        <p>
                                            Register for quick checkout, order status, purchase history, wishlis");
            WriteLiteral("ts, and more.\r\n                                        </p>\r\n                                    </div>\r\n                                    ");
#nullable restore
#line 26 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Account\Register.cshtml"
                               Write(await Html.PartialAsync("_RegisterPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
