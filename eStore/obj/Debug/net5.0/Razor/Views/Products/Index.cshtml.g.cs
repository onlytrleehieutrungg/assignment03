#pragma checksum "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37a6353a9d023efad47f9e29ccdc4fc65218b24a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
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
#line 1 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37a6353a9d023efad47f9e29ccdc4fc65218b24a", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56a326c9856d6b769aa8d0630ceb1b56b0595277", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DataAccess.Models.Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Products</h1>\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 14 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 17 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 20 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 23 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 26 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 29 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UnitsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>Option</th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 35 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 39 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 42 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 45 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 48 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 51 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 54 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UnitsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n");
#nullable restore
#line 56 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
             if (@Context.Session.GetString("Email") == "admin@estore.com")
            { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\n\n                    ");
#nullable restore
#line 60 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.ProductId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                    ");
#nullable restore
#line 61 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.ProductId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                    ");
#nullable restore
#line 62 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.ProductId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n");
#nullable restore
#line 64 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 66 "C:\Users\phamm\OneDrive\Desktop\assignment03\assignment03\eStore\Views\Products\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</tbody>\n<p>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37a6353a9d023efad47f9e29ccdc4fc65218b24a10027", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</p>\n</table>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DataAccess.Models.Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
