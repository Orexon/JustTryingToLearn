#pragma checksum "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c669ed785fad15b9ef3dbada06d82bc219f3f9e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assignment_GetCompanyAssignments), @"mvc.1.0.view", @"/Views/Assignment/GetCompanyAssignments.cshtml")]
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
#line 1 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\_ViewImports.cshtml"
using DarboOrganizavimoPlatforma.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\_ViewImports.cshtml"
using DarboOrganizavimoPlatforma.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c669ed785fad15b9ef3dbada06d82bc219f3f9e8", @"/Views/Assignment/GetCompanyAssignments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d87bdba21f18cbdf106e9d89635ac162867027fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Assignment_GetCompanyAssignments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DarboOrganizavimoPlatforma.Domains.Assignment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Assignment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateAssignment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAssignment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AssignmentDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
  
    ViewData["Title"] = "GetAllAssignments";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-6 col-sm-6"">
                <h1>Assignments list</h1>
            </div>
            <div class=""col-6 col-sm-3 offset-sm-3 text-right"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c669ed785fad15b9ef3dbada06d82bc219f3f9e86993", async() => {
                WriteLiteral("Add New Assignment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card mt-2"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">All Assignments</h3>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <table id=""example1"" class=""table table-bordered table-hover"">
                            <!-- /Table-Header -->
                            <thead>
                                <tr>
                                    <th>");
#nullable restore
#line 36 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Company.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 37 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Team.TeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 38 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.AssignmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 39 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.CreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 40 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.AssignmentStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                                    <th> Edit</th>
                                    <th> Details </th>
                                    <th> Delete</th>
                                </tr>
                            </thead>
                            <!-- /Table-Body -->
                            <tbody>
");
#nullable restore
#line 48 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 51 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Company.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 52 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Team.TeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 53 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.AssignmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 54 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.CreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <th>");
#nullable restore
#line 55 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.AssignmentStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c669ed785fad15b9ef3dbada06d82bc219f3f9e814174", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-AssignmentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                                                                                                                       WriteLiteral(item.AssignmentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AssignmentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-AssignmentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AssignmentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c669ed785fad15b9ef3dbada06d82bc219f3f9e816879", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-AssignmentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                                                                                                                       WriteLiteral(item.AssignmentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AssignmentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-AssignmentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AssignmentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                    <td><button id=\"modalDeleteButton\" type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#myModal\" data-AssignmentId=\"");
#nullable restore
#line 58 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                                                                                                                                                     Write(item.AssignmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Delete</button></td>\r\n                                </tr>\r\n");
#nullable restore
#line 60 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                            <!-- /Table-footer -->\r\n                            <tfoot>\r\n                                <tr>\r\n                                    <th>");
#nullable restore
#line 65 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Company.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 66 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Team.TeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 67 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.AssignmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 68 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.CreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th>");
#nullable restore
#line 69 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Assignment\GetCompanyAssignments.cshtml"
                                   Write(Html.DisplayNameFor(model => model.AssignmentStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                                    <th> Edit</th>
                                    <th> Details </th>
                                    <th> Delete</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>
<!-- /.content -->

<!-- Modal on Delete Click-->
<div class=""modal fade"" data-backdrop=""static"" id=""myModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Delete Assignment</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal");
            WriteLiteral(@""" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <p>Are you sure you want to delete this Assignment?</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button id=""button1"" type=""submit"" class=""btn btn-primary"">Delete Assignment</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(""#myModal"").on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('AssignmentId') // Extract info from data-* attributes

            var btn = $(this).find('#button1');
            console.log(recipient)
            btn.on('click', function (event) {
                $.post(""/Assignment/DeleteAssignment/"" + recipient,
                    function (data) {
                        location.reload();
                    });
            })
        });
        $(function () {
            $(""#example1"").DataTable({
                ""responsive"": true,
                ""lengthChange"": false,
                ""autoWidth"": false,
                ""buttons"": [""copy"", ""csv"", ""excel"", ""pdf"", ""print"", ""colvis""]
            }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DarboOrganizavimoPlatforma.Domains.Assignment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
