#pragma checksum "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd136098f305acaab025a43490d123f2fbd65007"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ABC_Hardware.Pages.Shared.Pages_Shared_DeleteAnItem), @"mvc.1.0.razor-page", @"/Pages/Shared/DeleteAnItem.cshtml")]
namespace ABC_Hardware.Pages.Shared
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
#line 1 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\_ViewImports.cshtml"
using ABC_Hardware;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd136098f305acaab025a43490d123f2fbd65007", @"/Pages/Shared/DeleteAnItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"230cd06647bc2f7de27aa578830cf67212b28c7e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_DeleteAnItem : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("DeleteAnItemForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd136098f305acaab025a43490d123f2fbd650074087", async() => {
                WriteLiteral("\r\n    <title>Delete An Item</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd136098f305acaab025a43490d123f2fbd650075090", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd136098f305acaab025a43490d123f2fbd650075352", async() => {
                    WriteLiteral("\r\n        <table>\r\n            <tr>\r\n                <td>First Input Field:</td>\r\n                <td><input type=\"text\" name=\"SearchParameter\"");
                    BeginWriteAttribute("value", " value=\"", 379, "\"", 409, 1);
#nullable restore
#line 15 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
WriteAttributeValue("", 387, Model.SearchParameter, 387, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" /></td>
            </tr>
            <tr>
                <td><input type=""submit"" name=""Submit"" value=""Search"" /></td>
            </tr>
        </table>
        <table class=""table"">
            <tbody>
                <tr>
                    <th>ItemCode</th>
                    <th>ItemDescription</th>
                    <th>Quantity On Hand</th>
                    <th>Unit Price</th>
                </tr>
");
#nullable restore
#line 29 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
                 foreach (var items in Model.SampleObjectCollection)
                {
                    if (items.IsDeleted == false)
                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 34 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
                           Write(items.ItemCode);

#line default
#line hidden
#nullable disable
                    WriteLiteral("<br /></td>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
                           Write(items.ItemDescription);

#line default
#line hidden
#nullable disable
                    WriteLiteral("<br /></td>\r\n                            <td>");
#nullable restore
#line 36 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
                           Write(items.QuantityOnHand);

#line default
#line hidden
#nullable disable
                    WriteLiteral("<br /></td>\r\n                            <td>");
#nullable restore
#line 37 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
                           Write(items.UnitPrice);

#line default
#line hidden
#nullable disable
                    WriteLiteral("<br /></td>\r\n\r\n                            <td><input type=\"submit\" name=\"Submit\"");
                    BeginWriteAttribute("value", " value=\"", 1358, "\"", 1388, 2);
                    WriteAttributeValue("", 1366, "Delete", 1366, 6, true);
#nullable restore
#line 39 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
WriteAttributeValue(" ", 1372, items.ItemCode, 1373, 15, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" /><br /></td>\r\n                        </tr>\r\n");
#nullable restore
#line 41 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("            </tbody>\r\n        </table>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
#nullable restore
#line 46 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\Shared\DeleteAnItem.cshtml"
Write(Model.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ABC_Hardware.Pages.Shared.DeleteAnItemModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ABC_Hardware.Pages.Shared.DeleteAnItemModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ABC_Hardware.Pages.Shared.DeleteAnItemModel>)PageContext?.ViewData;
        public ABC_Hardware.Pages.Shared.DeleteAnItemModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591