#pragma checksum "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0210006763c91aaa4d56c042c27dfea93052214"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Profile), @"mvc.1.0.view", @"/Views/Member/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0210006763c91aaa4d56c042c27dfea93052214", @"/Views/Member/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d87bdba21f18cbdf106e9d89635ac162867027fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DarboOrganizavimoPlatforma.Domains.AppUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Member", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUserProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePasswordAndEmail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
  
    ViewData["Title"] = "AddTeamMember";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-12 text-center\">\r\n                <h1>");
#nullable restore
#line 11 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
               Write(Model.MemberName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Profile</h1>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12 col-md-12"">
                <div class=""row justify-content-center"">
                    <div class=""col-md-8 card card-primary card-outline mr-1"">
                        <div class=""card-body box-profile"">
                            <div class=""text-center"">
");
#nullable restore
#line 25 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                 if (Model.ProfilePicture != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img class=\"profile-user-img img-circle\"");
            BeginWriteAttribute("src", " src=\"", 981, "\"", 1054, 2);
            WriteAttributeValue("", 987, "data:image/*;base64,", 987, 20, true);
#nullable restore
#line 27 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
WriteAttributeValue("", 1007, Convert.ToBase64String(Model.ProfilePicture), 1007, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"User profile picture\">\r\n");
#nullable restore
#line 28 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img class=\"profile-user-img img-fluid img-circle\"");
            BeginWriteAttribute("src", " src=\"", 1279, "\"", 1285, 0);
            EndWriteAttribute();
            WriteLiteral(" alt=\"User profile picture\" />\r\n");
#nullable restore
#line 32 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <h3 class=\"profile-username text-center\">");
#nullable restore
#line 34 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                                Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                                                 Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p class=\"text-muted text-center\">");
#nullable restore
#line 35 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                         Write(Model.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <ul class=\"list-group list-group-unbordered mb-3\">\r\n                                <li class=\"list-group-item\">\r\n                                    <b>Company</b> <a class=\"float-right\">");
#nullable restore
#line 38 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                                     Write(Model.Company.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                                <li class=\"list-group-item\">\r\n                                    <b>Joined</b> <a class=\"float-right\">");
#nullable restore
#line 41 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                                    Write(Model.JoinDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                                <li class=\"list-group-item\">\r\n                                    <b>Email</b> <a class=\"float-right\">");
#nullable restore
#line 44 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                                   Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                                <li class=\"list-group-item\">\r\n                                    <b>PhoneNumber</b> <a class=\"float-right\">");
#nullable restore
#line 47 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                                         Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </li>
                            </ul>
                            <div class=""card-header"">
                                <h3 class=""card-title"">About Me</h3>
                            </div>
                            <!--/.card-header -->
                            <div class=""card-body"">
                                <strong><i class=""fas fa-map-marker-alt mr-1""></i> Location</strong>
                                <p class=""text-muted"">");
#nullable restore
#line 56 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                 Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <hr>\r\n                                <strong><i class=\"far fa-file-alt mr-1\"></i> Notes</strong>\r\n                                <p class=\"text-muted\">");
#nullable restore
#line 59 "C:\Users\P3CK\Desktop\ProgramingProjects\C# Code\DOP\DarboOrganizavimoPlatforma\DarboOrganizavimoPlatforma.Web\Views\Member\Profile.cshtml"
                                                 Write(Model.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row pb-2\">\r\n                            <div class=\"col-12\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0210006763c91aaa4d56c042c27dfea9305221413459", async() => {
                WriteLiteral("<b>Edit Information</b>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0210006763c91aaa4d56c042c27dfea9305221414953", async() => {
                WriteLiteral("<b>Change Password</b>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
                        <!-- /.card-body -->
                    </div>
                    <!--/.card -->
                </div>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DarboOrganizavimoPlatforma.Domains.AppUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
