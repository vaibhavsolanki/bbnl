#pragma checksum "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20d3e53aaf526e0946b4d55533201f0c4e8d0542"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_showdata), @"mvc.1.0.view", @"/Views/Admin/showdata.cshtml")]
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
#line 1 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\_ViewImports.cshtml"
using bbnl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\_ViewImports.cshtml"
using bbnl.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20d3e53aaf526e0946b4d55533201f0c4e8d0542", @"/Views/Admin/showdata.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c42caa58700bcfc8fb99f0a89d71d06e240a509d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_showdata : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<bbnl.Models.registrationmodel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
  
    ViewData["Title"] = "Reg Data";
    Layout = "../Shared/_adminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""header bg-primary pb-6"">
    <div class=""container-fluid"">
        <div class=""header-body"">
            <div class=""row align-items-center py-4"">
                <div class=""col-lg-6 col-7"">
                    <h6 class=""h2 text-white d-inline-block mb-0"">Registration Data</h6>
                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                            <li class=""breadcrumb-item""><a href=""/""><i class=""fas fa-home""></i></a></li>

                            <li class=""breadcrumb-item active"" aria-current=""page"">Registration Data</li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""container-fluid mt--6"">
    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <!-- Card header -->
                <div class=""card-hea");
            WriteLiteral(@"der border-0"">
                    <h3 class=""mb-0"">Registration Data</h3>
                </div>
                <!-- Light table -->
                <div class=""table-responsive"">
                    <table class=""table align-items-center table-flush"">
                        <thead class=""thead-light"">
                            <tr>
                                <th>Sr. No</th>
                                <th>Company Name</th>
                                <th>State</th>
                                <th>District</th>
                                <th>Type</th>
                                <th>Licence No</th>
                                <th colspan=""5"">File</th>
                            </tr>
                            <tr>
                                <th colspan=""6""></th>
                                <th>DOT</th>
                                <th>GSTIN</th>
                                <th>POA</th>
                                <th>POI</th>
    ");
            WriteLiteral("                            <th>Company</th>\r\n\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody class=\"list\">\r\n");
#nullable restore
#line 59 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                              int i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                             foreach (var data in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                \r\n                                <td>");
#nullable restore
#line 64 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                                Write(i++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                \r\n                                <td>\r\n                                    ");
#nullable restore
#line 67 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                               Write(data.companyname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 70 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                               Write(data.states_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 73 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                               Write(data.districts_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 76 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                               Write(data.companytype);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 79 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                               Write(data.licenceno);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 82 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                                     if (!string.IsNullOrEmpty(@data.dotfilepath))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20d3e53aaf526e0946b4d55533201f0c4e8d05428914", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3502, "~/", 3502, 2, true);
#nullable restore
#line 84 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
AddHtmlAttributeValue("", 3504, data.dotfilepath, 3504, 17, false);

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
            WriteLiteral("\r\n");
#nullable restore
#line 85 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 90 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                                     if (!string.IsNullOrEmpty(@data.gstinfilepath))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20d3e53aaf526e0946b4d55533201f0c4e8d054211128", async() => {
                WriteLiteral(" View ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3843, "~/", 3843, 2, true);
#nullable restore
#line 92 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
AddHtmlAttributeValue("", 3845, data.gstinfilepath, 3845, 19, false);

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
            WriteLiteral("\r\n");
#nullable restore
#line 93 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 98 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                                     if (!string.IsNullOrEmpty(@data.poafilepath))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a");
            BeginWriteAttribute("href", " href=\"", 4179, "\"", 4203, 1);
#nullable restore
#line 100 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
WriteAttributeValue("", 4186, data.poafilepath, 4186, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"> View </a>\r\n");
#nullable restore
#line 101 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 106 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                                     if (!string.IsNullOrEmpty(@data.poifilepath))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20d3e53aaf526e0946b4d55533201f0c4e8d054214358", async() => {
                WriteLiteral(" View ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4525, "~/", 4525, 2, true);
#nullable restore
#line 108 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
AddHtmlAttributeValue("", 4527, data.poifilepath, 4527, 17, false);

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
            WriteLiteral("\r\n");
#nullable restore
#line 109 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 114 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                                     if (!string.IsNullOrEmpty(@data.compdocfilepath))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20d3e53aaf526e0946b4d55533201f0c4e8d054216580", async() => {
                WriteLiteral(" View ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4870, "~/", 4870, 2, true);
#nullable restore
#line 116 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
AddHtmlAttributeValue("", 4872, data.compdocfilepath, 4872, 21, false);

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
            WriteLiteral("\r\n");
#nullable restore
#line 117 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 126 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Admin\showdata.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                            </table >\r\n                            </div >\r\n                            <!--Card footer-->\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<bbnl.Models.registrationmodel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
