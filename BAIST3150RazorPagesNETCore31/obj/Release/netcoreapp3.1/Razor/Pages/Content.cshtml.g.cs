#pragma checksum "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\Content.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e248af76f1b2b9112f90b5f8d855fd7ac8d6c108"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BAIST3150RazorPagesNETCore31.Pages_Content), @"mvc.1.0.razor-page", @"/Pages/Content.cshtml")]
namespace BAIST3150RazorPagesNETCore31
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
#line 7 "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\_ViewImports.cshtml"
using BAIST3150RazorPagesNETCore31;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e248af76f1b2b9112f90b5f8d855fd7ac8d6c108", @"/Pages/Content.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37bf82cbc6292b6e067fd1c08d0156f7b5b99b17", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Content : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\Content.cshtml"
  
    Layout = "_Layout"; // remove if using _ViewStart
    ViewData["Title"] = "*** Title from content page ***";

#line default
#line hidden
#nullable disable
            DefineSection("scriptContent", async() => {
                WriteLiteral(" \r\n    <script type=\"text/javascript\">\r\n        // *** script from content page ***\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"<table>
    <tr>
        <td>*** Main Area from content page ***</td>
    </tr>
    <tr>
        <td><div><table>
    <tr>
        <td>*** Division Area from content page ***</td>
    </tr>
    <tr>
        <td>***<input type=""text"" name=""InputField"" /> ***</td>
    </tr>
</table></div></td>
    </tr>
</table>
");
            DefineSection("footerContent", async() => {
                WriteLiteral(" \r\n    <table>\r\n        <tr>\r\n            <td> *** Footer Area from conent page *** </td>\r\n        </tr>\r\n    </table>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BAIST3150RazorPagesNETCore31.Pages.ContentModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIST3150RazorPagesNETCore31.Pages.ContentModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIST3150RazorPagesNETCore31.Pages.ContentModel>)PageContext?.ViewData;
        public BAIST3150RazorPagesNETCore31.Pages.ContentModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
