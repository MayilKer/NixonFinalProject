#pragma checksum "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc333faa31ea87a747c39ea01353d67c7b96731b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__TagPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_TagPartial.cshtml")]
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
#line 2 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\_ViewImports.cshtml"
using NixonE.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\_ViewImports.cshtml"
using NixonE.ViewModels.Acoount;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\_ViewImports.cshtml"
using NixonE.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc333faa31ea87a747c39ea01353d67c7b96731b", @"/Areas/Admin/Views/Shared/_TagPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9aa56e567f8a87990ed199a97461a630f47c279", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__TagPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tag>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
  
    int count = (ViewBag.PageIndex - 1) * 5;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-striped"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Product Count</th>
            <th scope=""col"">Status</th>
            <th scope=""col"">Created At</th>
            <th scope=""col"">Updated At</th>
            <th scope=""col"">Deleted At</th>
            <th scope=""col"">Setting</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
         foreach (Tag tag in Model)
        {
            count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <th scope=\"row\">");
#nullable restore
#line 24 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                       Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <td>");
#nullable restore
#line 25 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
           Write(tag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
           Write(tag.Products.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td");
            BeginWriteAttribute("style", " style=\"", 743, "\"", 789, 2);
            WriteAttributeValue("", 751, "color:", 751, 6, true);
#nullable restore
#line 27 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
WriteAttributeValue("", 757, tag.IsDeleted ? "red":"green", 757, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                           Write(tag.IsDeleted ? "DeActive":"Active");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
           Write(tag.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
           Write(tag.UpdatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
           Write(tag.DeletedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc333faa31ea87a747c39ea01353d67c7b96731b7653", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-status", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                     WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                      WriteLiteral(ViewBag.PageIndex);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                                                        WriteLiteral(tag.Id);

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
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc333faa31ea87a747c39ea01353d67c7b96731b11604", async() => {
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                                                                                                                                                                                           Write(tag.IsDeleted ? "Restore":"Delete");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
AddHtmlAttributeValue("", 1157, tag.IsDeleted ? "restoreTag":"deleteTag", 1157, 43, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1209, "btn", 1209, 3, true);
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
AddHtmlAttributeValue(" ", 1212, tag.IsDeleted ? "btn-primary":"btn-danger", 1213, 45, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-status", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                                                    WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                                                                                     WriteLiteral(ViewBag.PageIndex);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                                                                                                                      WriteLiteral(tag.IsDeleted ? "Restore":"Delete");

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
                                                                                                                                                                                                                                                          WriteLiteral(tag.Id);

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
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 36 "C:\Program Files (x86)\Рабочий стол\NixonProject\NixonE\NixonE\Areas\Admin\Views\Shared\_TagPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tag>> Html { get; private set; }
    }
}
#pragma warning restore 1591