#pragma checksum "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\MultiplePosts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0de9f24d8f9ca8118793dd2a8db3af95985ab5a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BAIST3150RazorPagesNETCore31.Pages_MultiplePosts), @"mvc.1.0.razor-page", @"/Pages/MultiplePosts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0de9f24d8f9ca8118793dd2a8db3af95985ab5a5", @"/Pages/MultiplePosts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37bf82cbc6292b6e067fd1c08d0156f7b5b99b17", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MultiplePosts : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("MultiplePostForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de9f24d8f9ca8118793dd2a8db3af95985ab5a54111", async() => {
                WriteLiteral("\r\n    <title>Multiple Post</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de9f24d8f9ca8118793dd2a8db3af95985ab5a55113", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de9f24d8f9ca8118793dd2a8db3af95985ab5a55375", async() => {
                    WriteLiteral("\r\n        <table>\r\n            <tr>\r\n                <td>First Input Field:</td>\r\n                <td><input type=\"text\" name=\"FirstInputField\"");
                    BeginWriteAttribute("value", " value=\"", 390, "\"", 420, 1);
#nullable restore
#line 15 "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\MultiplePosts.cshtml"
WriteAttributeValue("", 398, Model.FirstInputField, 398, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" /></td>
            </tr>
            <tr>
                <td><input type=""submit"" name=""Submit"" value=""First"" /></td>
            </tr>
            <tr>
                <td>Second Input Field:</td>
                <td><input type=""text"" name=""SecondInputField""");
                    BeginWriteAttribute("value", " value=\"", 691, "\"", 722, 1);
#nullable restore
#line 22 "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\MultiplePosts.cshtml"
WriteAttributeValue("", 699, Model.SecondInputField, 699, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" /></td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    <input type=\"submit\" name=\"Submit\" value=\"Second\" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n\r\n    ");
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
#line 32 "C:\Users\admin\Documents\GitHub\BAIST\BAIST3150RazorPagesNETCore31\Pages\MultiplePosts.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BAIST3150RazorPagesNETCore31.Pages.MultiplePostsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIST3150RazorPagesNETCore31.Pages.MultiplePostsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIST3150RazorPagesNETCore31.Pages.MultiplePostsModel>)PageContext?.ViewData;
        public BAIST3150RazorPagesNETCore31.Pages.MultiplePostsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
