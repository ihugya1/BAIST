#pragma checksum "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f432d7e9c20a93eaca6e9a379dc4fb78d847aee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ABC_Hardware.Pages.Pages_ProcessASale), @"mvc.1.0.razor-page", @"/Pages/ProcessASale.cshtml")]
namespace ABC_Hardware.Pages
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f432d7e9c20a93eaca6e9a379dc4fb78d847aee", @"/Pages/ProcessASale.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_VIewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"230cd06647bc2f7de27aa578830cf67212b28c7e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ProcessASale : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("ProcessSaleForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f432d7e9c20a93eaca6e9a379dc4fb78d847aee4516", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 257, "\"", 267, 0);
                EndWriteAttribute();
                WriteLiteral(@">
    <meta name=""author"" content=""Mark Otto, Jacob Thornton, and Bootstrap contributors"">
    <meta name=""generator"" content=""Jekyll v3.8.6"">
    <title>Checkout example · Bootstrap</title>

    <link rel=""canonical"" href=""https://getbootstrap.com/docs/4.4/examples/checkout/"">

    <!-- Bootstrap core CSS -->
    <link href=""/docs/4.4/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">

    <!-- Favicons -->
    <link rel=""apple-touch-icon"" href=""/docs/4.4/assets/img/favicons/apple-touch-icon.png"" sizes=""180x180"">
    <link rel=""icon"" href=""/docs/4.4/assets/img/favicons/favicon-32x32.png"" sizes=""32x32"" type=""image/png"">
    <link rel=""icon"" href=""/docs/4.4/assets/img/favicons/favicon-16x16.png"" sizes=""16x16"" type=""image/png"">
    <link rel=""manifest"" href=""/docs/4.4/assets/img/favicons/manifest.json"">
    <link rel=""mask-icon"" href=""/docs/4.4/assets/img/favicons/safari-pinned-tab.svg"" color=""#");
                WriteLiteral(@"563d7c"">
    <link rel=""icon"" href=""/docs/4.4/assets/img/favicons/favicon.ico"">
    <meta name=""msapplication-config"" content=""/docs/4.4/assets/img/favicons/browserconfig.xml"">
    <meta name=""theme-color"" content=""#563d7c"">


    <!--<link href=""form-validation.css"" rel=""stylesheet"">-->
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f432d7e9c20a93eaca6e9a379dc4fb78d847aee7223", async() => {
                WriteLiteral("\r\n    <div class=\"container\">\r\n        <div class=\"py-5 text-center\">\r\n\r\n            <h2>Checkout form</h2>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f432d7e9c20a93eaca6e9a379dc4fb78d847aee7612", async() => {
                    WriteLiteral(@"
               


                <div class=""row"">
                    <div class=""col-md-4 order-md-2 mb-4"">
                        <h4 class=""d-flex justify-content-between align-items-center mb-3"">
                            <span class=""text-muted"">Your cart</span>
                           
                        </h4>
                        <ul class=""list-group mb-3"">
");
#nullable restore
#line 49 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                             if (Model.items != null)
                            {
                                foreach (var i in Model.items)
                                {
                                    if (i.IsDeleted == false)
                                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        <li class=\"list-group-item d-flex justify-content-between lh-condensed\">\r\n\r\n                                            <div>\r\n                                                <h6 class=\"my-0\">");
#nullable restore
#line 58 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                                            Write(i.ItemCode);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</h6>\r\n                                                <small class=\"text-muted\">");
#nullable restore
#line 59 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                                                     Write(i.ItemDescription);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</small>\r\n                                            </div>\r\n                                            <span class=\"text-muted\"> ");
#nullable restore
#line 61 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                                                 Write(string.Format("{0:C}", i.UnitPrice));

#line default
#line hidden
#nullable disable
                    WriteLiteral("</span><br />\r\n\r\n                                        </li>\r\n");
#nullable restore
#line 64 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                    }
                                }
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                             if (Model.items == null)
                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                                <li class=""list-group-item d-flex justify-content-between lh-condensed"">
                                    <div>
                                        <h6 class=""my-0"">Your cart is empty</h6>
                                        <small class=""text-muted""></small>
                                    </div>
                                    
                                </li>
");
#nullable restore
#line 76 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                            }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                <li class=\"list-group-item d-flex justify-content-between\">\r\n                                    <span>Total (CAD)</span>\r\n");
#nullable restore
#line 79 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                     if (Model.items != null)
                                    {
                                        foreach (var i in Model.items)
                                        {
                                            Model.Total += i.UnitPrice;
                                        }



#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        <strong>");
#nullable restore
#line 87 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                           Write(string.Format("{0:C}", Model.Total));

#line default
#line hidden
#nullable disable
                    WriteLiteral("</strong>");
#nullable restore
#line 87 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
                                                                                             }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                                </li>
                            </ul>


                    </div>
                    <div class=""col-md-8 order-md-1"">
                        <h4 class=""mb-3"">Sales Info</h4>

                        <div class=""row"">
                            
                            <div class=""col-md-6 mb-3"">
                                <label for=""SalePersonID"">Sale Person ID</label>
                                <input type=""text"" class=""form-control"" id=""salePersonID""");
                    BeginWriteAttribute("placeholder", " placeholder=\"", 4801, "\"", 4815, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("value", " value=\"", 4816, "\"", 4848, 1);
#nullable restore
#line 100 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
WriteAttributeValue("", 4824, Model.SalePersonIDField, 4824, 24, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">

                            </div>
                            <div class=""col-md-6 mb-3"">
                                <label for=""customerID"">Customer ID</label>
                                <input type=""text"" class=""form-control"" id=""customerID""");
                    BeginWriteAttribute("placeholder", " placeholder=\"", 5111, "\"", 5125, 0);
                    EndWriteAttribute();
                    BeginWriteAttribute("value", " value=\"", 5126, "\"", 5156, 1);
#nullable restore
#line 105 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
WriteAttributeValue("", 5134, Model.CustomerIDField, 5134, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n\r\n                            </div>\r\n                        </div>\r\n\r\n                        <input type=\"submit\" name=\"Submit\" value=\"Submit\">\r\n\r\n                    </div>\r\n                </div>\r\n            ");
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
                WriteLiteral("\r\n            ");
#nullable restore
#line 115 "C:\Users\admin\Documents\GitHub\BAIST\ABC Hardware\Pages\ProcessASale.cshtml"
       Write(Model.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>
        
    </div>
    <script src=""https://code.jquery.com/jquery-3.4.1.slim.min.js"" integrity=""sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"" crossorigin=""anonymous""></script>
    <script>window.jQuery || document.write('<script src=""/docs/4.4/assets/js/vendor/jquery.slim.min.js""><\/script>')</script>
    <script src=""/docs/4.4/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-6khuMg9gaYr5AxOqhkVIODVIvm9ynTT5J4V1cfthmT+emCG6yVmEZsRHdxlotUnm"" crossorigin=""anonymous""></script>
    <script src=""form-validation.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ABC_Hardware.Pages.Shared.ProcessASaleModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ABC_Hardware.Pages.Shared.ProcessASaleModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ABC_Hardware.Pages.Shared.ProcessASaleModel>)PageContext?.ViewData;
        public ABC_Hardware.Pages.Shared.ProcessASaleModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
