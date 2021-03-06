#pragma checksum "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\gpuser\gpdetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bf2567a348d254b2d95bf022b7cf84408cd24e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_gpuser_gpdetails), @"mvc.1.0.view", @"/Views/gpuser/gpdetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bf2567a348d254b2d95bf022b7cf84408cd24e6", @"/Views/gpuser/gpdetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c42caa58700bcfc8fb99f0a89d71d06e240a509d", @"/Views/_ViewImports.cshtml")]
    public class Views_gpuser_gpdetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\gpuser\gpdetails.cshtml"
  
    ViewData["Title"] = "GPDetails";
    Layout = "../Shared/_gpLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">

    $(document).ready(function () {
        $('#state_id').change(function (event) {

            var stateid = this.value;//.split;("" _ "");
            //var data = {

            //    states_id: states_id

            //};

            $.ajax({
                url: ""/Details/getdistrict/"" + stateid,
                type: ""post"",
                contentType: 'application/x-www-form-urlencoded',

                success: function (result) {
                    var obj = JSON.parse(result)
                    $('#block_id').empty();
                    $('#gpdata').empty();
                    $('#dist_id').empty();
                    $('#gp_download').empty();
                    $('#dist_id').append(`<option value="""">${""--Select--""}</option>`);
                    $.each(obj.distModels, function (key, value) {

                        $('#dist_id').append(`<option  value=""${value.districts_id}"">${value.districts_name}</option>`);

               ");
            WriteLiteral(@"     });


                },
                error: function () {
                    alert(""Error occured!!"")
                }
            });


        });

        $('#dist_id').change(function (event) {

            var distid = this.value;//.split;("" _ "");


            $.ajax({
                url: ""/Details/getblockwrtdist/"" + distid,
                type: ""post"",
                contentType: 'application/x-www-form-urlencoded',

                success: function (result) {
                    var obj = JSON.parse(result)
                    $('#block_id').empty();
                    $('#gpdata').empty();
                    $('#gp_download').empty();
                    $('#block_id').append(`<option value="""">${""--Select--""}</option>`);
                    $.each(obj.blockModels, function (key, value) {

                        $('#block_id').append(`<option  value=""${value.blocks_id}"">${value.blocks_name}</option>`);

                    });
                },
   ");
            WriteLiteral(@"             error: function () {
                    alert(""Error occured!!"")
                }
            });

        });

        $('#block_id').change(function (event) {

            var block = this.value;//.split;("" _ "");


            $.ajax({
                url: ""/Details/getgpwrtblock/"" + block,
                type: ""post"",
                contentType: 'application/x-www-form-urlencoded',
                data: { block: block, type: ""gp"" },
                success: function (result) {
                    var obj = JSON.parse(result)
                    $('#gpdata').empty();
                    $('#gp_download').empty();

                    $('#gp_download').append(`<a href=""/gpuser/exportgp/${block}""> Download GPs</a>`);

                    $.each(obj.gpModels, function (key, value) {
                        //if (value.up_status == ""1"") {
                        $('#gpdata').append(`<tr style=""color:${value.up_status == ""1"" ? ""red"" : ""green""}""> <td>${key + 1}</td> <td>");
            WriteLiteral(@"${value.states_name ?? """"}</td> <td>${value.districts_name ?? """"}</td> <td>${value.blocks_name ?? """"}</td> <td>${value.gp_name ?? """"}</td> <td>${value.up_status == ""1""?""DOWN"":""UP""} <td>${value.down_resion ?? ""NA""}</td> </tr>`);
                        //}
                        //else {
                        //    $('#gpdata').append(`<p style=""color:green"" onclick=""getvillage(${value.gp_id ?? """"})"" id=""gp${value.gp_id ?? """"}"" class=""district-list"">${value.gp_name ?? """"}</p>`);
                        //}
                    });

                },
                error: function () {
                    alert(""Error occured!!"")
                }
            });

        });

        $(""#nextbtn"").click(function () {
            $('#otpdiv').css(""display"", ""block"");
        });


    })

</script>
<div class=""header bg-primary pb-6"">
    <div class=""container-fluid"">
        <div class=""header-body"">
            <div class=""row align-items-center py-4"">
                <div class");
            WriteLiteral("=\"col-lg-6 col-7\">\r\n");
            WriteLiteral(@"                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                            <li class=""breadcrumb-item""><a href=""/""><i class=""fas fa-home""></i></a></li>

                            <li class=""breadcrumb-item active"" aria-current=""page"">GP Details</li>
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
                <div class=""card-header border-0"">
                    <h3 class=""mb-0"">GP Details</h3>
                </div>
                <!-- Light table -->
                <div class=""card-body"">
                    <div class=""form-row"">
                        <div class=""col-md-4"">
                            <div class=""form-");
            WriteLiteral("group\">\r\n                                <label class=\"form-control-label\" for=\"validationDefault04\">State </label>\r\n                                <select class=\" form-control\" id=\"state_id\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bf2567a348d254b2d95bf022b7cf84408cd24e69266", async() => {
                WriteLiteral("--Select--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 154 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\gpuser\gpdetails.cshtml"
                                     foreach (stateModel dist in (List<stateModel>)ViewData["stateList"])
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bf2567a348d254b2d95bf022b7cf84408cd24e610788", async() => {
#nullable restore
#line 156 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\gpuser\gpdetails.cshtml"
                                                                   Write(dist.states_name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 156 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\gpuser\gpdetails.cshtml"
                                           WriteLiteral(dist.states_id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 157 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\gpuser\gpdetails.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </select>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label class=""form-control-label"" for=""validationDefault04"">District </label>
                                <select class="" form-control"" id=""dist_id"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bf2567a348d254b2d95bf022b7cf84408cd24e613261", async() => {
                WriteLiteral("--Select--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    
                                </select>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label class=""form-control-label"" for=""validationDefault04"">Block </label>
                                <select class="" form-control"" id=""block_id"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bf2567a348d254b2d95bf022b7cf84408cd24e614909", async() => {
                WriteLiteral("--Select--");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""table-responsive"">
                    <div class=""container my-2"" style=""text-align:right"" id=""gp_download"">
                        
");
            WriteLiteral(@"                    </div>
                    <table class=""table align-items-center table-flush"">
                        <thead class=""thead-light"">
                            <tr>
                                <th>Sr. No</th>
                                <th>State</th>
                                <th>District</th>
                                <th>Block</th>
                                <th>GP</th>
                                <th>Status</th>
                                <th>Reason</th>

                            </tr>

                        </thead>
                        <tbody class=""list"" id=""gpdata"">
                        </tbody>
                    </table>
                </div>
                <!--Card footer-->
");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n");
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
