#pragma checksum "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Home\success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0be1d9a88dd8178a53386842425049475796250"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_success), @"mvc.1.0.view", @"/Views/Home/success.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0be1d9a88dd8178a53386842425049475796250", @"/Views/Home/success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c42caa58700bcfc8fb99f0a89d71d06e240a509d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\Home\success.cshtml"
  
    ViewData["Title"] = "Success";
    Layout = "../Shared/_innerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""header bg-primary pb-6"">
    <div class=""container-fluid"">
        <div class=""header-body"">
            <div class=""row align-items-center py-4"">
                <div class=""col-lg-6 col-7"">
                    <h6 class=""h2 text-white d-inline-block mb-0"">Registration Form</h6>
                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                            <li class=""breadcrumb-item""><a href=""/""><i class=""fas fa-home""></i></a></li>

                            <li class=""breadcrumb-item active"" aria-current=""page"">Success</li>
                        </ol>
                    </nav>
                </div>
                <div class=""col-lg-6 col-5 text-right"">
");
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</div>

<!-- Page content -->
<div class=""container-fluid mt--6"">
    <div class=""row"">
        <div class=""col"">
            <div class=""card-wrapper"">

               

                    <div class=""card"" id=""otpdiv"" style=""display:none"">
                        <!-- Card header -->
                        <div class=""card-header"">
                            <h3 class=""mb-0"">OTP</h3>
                        </div>
                        <!-- Card body -->
                        <div class=""card-body"">

                            <div class=""row"">
                                <div class=""col-lg-8"">
                                    <p class=""mb-0"">
                                        Registration Completed
                                    </p>
                                </div>
                            </div>

                        </div>
                    </div>
            </div>");
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
