#pragma checksum "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d01f266ec3230cb54fe95ea770cd4aa9207ea5e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BasketPartial), @"mvc.1.0.view", @"/Views/Shared/_BasketPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d01f266ec3230cb54fe95ea770cd4aa9207ea5e9", @"/Views/Shared/_BasketPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"235cdcf0228f58511ff272e7905bc8cfe584a9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BasketPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart_item_title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart_item_remove delete-pro-l"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteFromBasketLayout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-first"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
   
    double subTotal = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d01f266ec3230cb54fe95ea770cd4aa9207ea5e98350", async() => {
                WriteLiteral(@"
        <div class=""cart-header"">
            <p class=""cart-title"">
                Shopping Cart
            </p>
            <a id=""close-cart"" href=""#"" class=""cart-close close-cart"">
                <svg width=""20"" height=""21"" viewbox=""0 0 20 21"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                    <path d=""M19 1.36328L1 19.3633"" stroke=""black"" stroke-width=""2"" stroke-miterlimit=""10""></path>
                    <path d=""M19 19.3633L1 1.36328"" stroke=""black"" stroke-width=""2"" stroke-miterlimit=""10""></path>
                </svg>
            </a>
        </div>
");
#nullable restore
#line 17 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"cart-body\">\r\n                <p class=\"cart-item-count\">\r\n                    ");
#nullable restore
#line 21 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
               Write(Model.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(" item\r\n                </p>\r\n");
#nullable restore
#line 23 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                 foreach (BasketVM basket in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <ul class=\"cart_list\" style=\"overflow-y:initial\">\r\n                        <li class=\"cart_list_item\">\r\n                            <div class=\"cart_item_img\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d01f266ec3230cb54fe95ea770cd4aa9207ea5e910404", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1176, "~/dist/images/products/", 1176, 23, true);
#nullable restore
#line 28 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
AddHtmlAttributeValue("", 1199, basket.Image, 1199, 13, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"cart_item_info\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d01f266ec3230cb54fe95ea770cd4aa9207ea5e912203", async() => {
                    WriteLiteral("\r\n                                    <h6>\r\n                                        ");
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                   Write(basket.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                                  Write(basket.Colour);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                    </h6>\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                                                                                               WriteLiteral(basket.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                <div class=\"cart_item_information\">\r\n                                    <ul class=\"cart_item_options\">\r\n                                        <li>QTY: ");
#nullable restore
#line 38 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                            Write(basket.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                        <li>Color: ");
#nullable restore
#line 39 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                              Write(basket.Colour);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                    </ul>\r\n                                    <p class=\"cart_item_price\">\r\n                                        $");
#nullable restore
#line 42 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                     Write((basket.Price*basket.Count).ToString("F2"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d01f266ec3230cb54fe95ea770cd4aa9207ea5e916986", async() => {
                    WriteLiteral(@"
                                    <svg width=""11"" height=""11"" viewbox=""0 0 11 11"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                                        <path d=""M10 1.18164L1 10.1816"" stroke=""black"" stroke-width=""2"" stroke-miterlimit=""10""></path>
                                        <path d=""M10 10.1816L1 1.18164"" stroke=""black"" stroke-width=""2"" stroke-miterlimit=""10""></path>
                                    </svg>
                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                                                                                                                             WriteLiteral(basket.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                                                                                                                                                                   WriteLiteral(basket.ColorId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["colorId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-colorId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["colorId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        </li>\r\n                    </ul>\r\n");
#nullable restore
#line 54 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                    subTotal += (basket.Price * basket.Count);
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""cart-pre-footer"">
                    <div class=""footer-row cart-footer-text"">
                        Taxes and shipping are calculated at Checkout
                    </div>
                    <div class=""footer-row"">
                        <h6>
                            Subtotal: $");
#nullable restore
#line 62 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
                                  Write(subTotal.ToString("F2"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </h6>
                    </div>
                </div>
            </div>
            <div class=""cart-footer"">
                <div class=""cart-footer-top"">

                </div>
                <div class=""cart-footer-bottom"">
                    <div class=""cart-footer-row"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d01f266ec3230cb54fe95ea770cd4aa9207ea5e922419", async() => {
                    WriteLiteral("\r\n                            View Cart\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                    <div class=""cart-footer-row"">
                        <a class=""btn btn-block btn-second close-cart"" href=""#"">
                            Continue Shopping
                        </a>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 84 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h1 style=\"position:absolute;top:50%;left:30%;font-size:15px;\">Your cart is currently empty.</h1>\r\n");
#nullable restore
#line 88 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Views\Shared\_BasketPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
