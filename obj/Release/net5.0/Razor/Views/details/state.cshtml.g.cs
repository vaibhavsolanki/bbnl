#pragma checksum "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "938fd81eeeb2df6642c762b25a93f13d5573eb66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_details_state), @"mvc.1.0.view", @"/Views/details/state.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"938fd81eeeb2df6642c762b25a93f13d5573eb66", @"/Views/details/state.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c42caa58700bcfc8fb99f0a89d71d06e240a509d", @"/Views/_ViewImports.cshtml")]
    public class Views_details_state : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 5 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml"
  
    ViewData["Title"] = "State";
    Layout = "../Shared/_innerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">

    $(document).ready(function () {
        var urlParams = new URLSearchParams(window.location.search);

        var state = urlParams.get('stateName');
        var stateid = state.split('_')

        $.ajax({

            url: ""/Details/countwrtstate/"" + stateid[1],
            type: ""post"",
            contentType: 'application/x-www-form-urlencoded',

            success: function (result) {
                var obj = JSON.parse(result)
               // $('.statecount').empty();
                $('.districtcount').empty();
                $('.blockcount').empty();
                $('.gpcount').empty();
                $('.upgp').empty();
                $('.downgp').empty();

             //   $('.statecount').append(obj[0].state_count);
                $('.districtcount').append(obj[0].districts_count);
                $('.blockcount').append(obj[0].block_count);
                $('.gpcount').append(obj[0].gp_count);
                $('#upgp').a");
            WriteLiteral(@"ppend(obj[0].gpup_count);
                $('#downgp').append(obj[0].gpdown_count);


            },
            error: function () {
                alert(""Error occured!!"")
            }
        });




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
                    $('#dist_id').empty();

                    $('#dist_id').append(`<option value="""">${""--Select--""}</option>`);
                    $.each(obj.distModels, function (key, value) {

                        $('#dist_id').append(`<option  value=""${value.districts_id}"">${value.districts_name}</option>`);

   ");
            WriteLiteral(@"                 });


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
                    $('.districtcount').empty();
                    $('.blockcount').empty();
                    $('.gpcount').empty();
                    $('#upgp').empty();
                    $('#downgp').empty();

                    //   $('.statecount').append(obj[0].state_count);
                    $('.distdiv').css(""display"", ""non");
            WriteLiteral(@"e"");
                    $('.blockdiv').css(""display"", ""block"");
                    $('.blockcount').append(obj.blockModels.length);
                    $('.gpcount').append(obj.countmodel.gp_count);
                    $('#upgp').append(obj.countmodel.gpup_count);
                    $('#downgp').append(obj.countmodel.gpdown_count);
                    $('#block_id').append(`<option value="""">${""--Select--""}</option>`);
                    $.each(obj.blockModels, function (key, value) {

                        $('#block_id').append(`<option  value=""${value.blocks_id}"">${value.blocks_name}</option>`);

                    });
                },
                error: function () {
                    alert(""Error occured!!"")
                }
            });

        });

        $('#block_id').change(function (event) {

            var block = this.value;//.split;("" _ "");


            $.ajax({
                url: ""/Details/getgpwrtblock/"" + block,
                type: ""post"",
");
            WriteLiteral(@"                contentType: 'application/x-www-form-urlencoded',
                data: { block: block, type: ""gp"" },
                success: function (result) {
                    var obj = JSON.parse(result)
                    $('#gpdata').empty();
                    $('.gpcount').empty();
                    $('#upgp').empty();
                    $('#downgp').empty();
                    $('.blockdiv').css(""display"", ""none"");


                   // const gpstatus = obj.gpModels(v => up_status == ""1"");

                    var downgp = $.grep(obj.gpModels, function (v) {
                        return v.up_status == ""1"";
                    });


                    $('.gpcount').append(obj.gpModels.length);

                    $('#upgp').append(obj.gpModels.length - downgp.length);
                    $('#downgp').append(downgp.length);

                    $.each(obj.gpModels, function (key, value) {
                        //if (value.up_status == ""1"") {
                  ");
            WriteLiteral(@"      $('#gpdata').append(`<tr style=""color:${value.up_status == ""1"" ? ""red"" : ""green""}""> <td>${key + 1}</td> <td>${value.states_name ?? """"}</td> <td>${value.districts_name ?? """"}</td> <td>${value.blocks_name ?? """"}</td> <td>${value.gp_name ?? """"}</td> <td>${value.up_status == ""1""?""DOWN"":""UP""} <td>${value.down_resion ?? ""NA""}</td> </tr>`);
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
  ");
            WriteLiteral("      <div class=\"header-body\">\r\n            <div class=\"row align-items-center py-4\">\r\n                <div class=\"col-lg-6 col-7\">\r\n");
            WriteLiteral(@"                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                            <li class=""breadcrumb-item""><a href=""/""><i class=""fas fa-home""></i></a></li>

                            <li class=""breadcrumb-item active"" aria-current=""page"">GP Details</li>
                        </ol>
                    </nav>
                </div>
            </div>

            <div class=""row"">
                <!--<div class=""col-xl-3 col-md-6"">
                    <div class=""card card-stats"">-->
                        <!-- Card body -->
                        <!--<div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">State</h5>
                                    <span class=""h2 font-weight-bold mb-0 statecount"">Loading...</span");
            WriteLiteral(@">
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-red text-white rounded-circle shadow"">
                                        <i class=""ni ni-active-40""></i>
                                    </div>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>-->
                <div class=""col-xl-3 col-md-6 distdiv"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">District</h5>
                                    <span class=""h2 font-weight-bold mb-0 districtcount"">Loading");
            WriteLiteral(@"...</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-orange text-white rounded-circle shadow"">
                                        <i class=""ni ni-chart-pie-35""></i>
                                    </div>
                                </div>
                            </div>
");
            WriteLiteral(@"                        </div>
                    </div>
                </div>
                <div class=""col-xl-3 col-md-6 blockdiv"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">Block</h5>
                                    <span class=""h2 font-weight-bold mb-0 blockcount"">Loading...</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-green text-white rounded-circle shadow"">
                                        <i class=""ni ni-money-coins""></i>
                                    </div>
                                </div>
                            </div>
");
            WriteLiteral(@"                        </div>
                    </div>
                </div>
                <div class=""col-xl-3 col-md-6 gpdiv"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">GP (<span class=""text-success"" id=""upgp""></span>/<span class=""text-danger"" id=""downgp""></span>)</h5>
                                    <span class=""h2 font-weight-bold mb-0 gpcount"">Loading...</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-info text-white rounded-circle shadow"">
                                        <i class=""ni ni-chart-bar-32""></i>
                                    </div>
                ");
            WriteLiteral("                </div>\r\n                            </div>\r\n");
            WriteLiteral(@"                        </div>
                    </div>
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
                    <h3 class=""mb-0"">");
#nullable restore
#line 293 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml"
                                Write(ViewData["state_name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
                <!-- Light table -->
                <div class=""card-body"">
                    <div class=""form-row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label class=""form-control-label"" for=""validationDefault04"">District </label>
                                <select class="" form-control"" id=""dist_id"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938fd81eeeb2df6642c762b25a93f13d5573eb6616146", async() => {
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
#line 303 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml"
                                     foreach (distModel dist in (List<distModel>)ViewData["distList"])
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938fd81eeeb2df6642c762b25a93f13d5573eb6617663", async() => {
#nullable restore
#line 305 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml"
                                                                      Write(dist.districts_name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 305 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml"
                                           WriteLiteral(dist.districts_id);

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
#line 306 "E:\bbnlnew\bbnl (2)\bbnl\bbnl\Views\details\state.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </select>
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label class=""form-control-label"" for=""validationDefault04"">Block </label>
                                <select class="" form-control"" id=""block_id"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938fd81eeeb2df6642c762b25a93f13d5573eb6620134", async() => {
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
         ");
            WriteLiteral("               </table>\r\n                    </div>\r\n                    <!--Card footer-->\r\n");
            WriteLiteral("                </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n");
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
