#pragma checksum "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a075b8c6e308e1c7e99b4e8f36d56f12535cae3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account_Clients), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/Clients.cshtml")]
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
#line 2 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\_ViewImports.cshtml"
using FinalNew.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\_ViewImports.cshtml"
using FinalNew.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\_ViewImports.cshtml"
using FinalNew.Models.Entity.Membership;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\_ViewImports.cshtml"
using FinalNew.Models.DataContext;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a075b8c6e308e1c7e99b4e8f36d56f12535cae3b", @"/Areas/Admin/Views/Account/Clients.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84e24096c04643a9180718dd4d73d749f17fda81", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Account_Clients : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AppUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Roles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/sweetalert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
  
    ViewData["Title"] = "Clients";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""content"">
    <ul class=""breadcrumb"">
        <li>
            <p>YOU ARE HERE</p>
        </li>
        <li><a href=""#"" class=""active"">Rollar</a> </li>
    </ul>
    <div class=""page-title"">
        <i class=""icon-custom-left""></i>
        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a075b8c6e308e1c7e99b4e8f36d56f12535cae3b4922", async() => {
                WriteLiteral("Rollar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" - <span class=""semi-bold"">Əsas səhifə</span></h3>
    </div>
    <div class=""row"" id=""inbox-wrapper"">
        <div class=""col-md-12"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""grid simple"">
                        <div class=""grid-body no-border email-body"">
                            <br>
                            <div class=""row-fluid"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th>
                                                ");
#nullable restore
#line 31 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                                           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <th>\r\n                                                ");
#nullable restore
#line 34 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </th>
                                            <th>
                                                Role
                                            </th>
                                            <th>
");
            WriteLiteral("                                            </th>\r\n                                        </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 45 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 49 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 52 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                                <td>
                                                    Client
                                                </td>
                                                <td>
                                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 2711, "\"", 2759, 6);
            WriteAttributeValue("", 2721, "postRemove(", 2721, 11, true);
#nullable restore
#line 58 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
WriteAttributeValue("", 2732, item.Id, 2732, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2740, ",", 2740, 1, true);
            WriteAttributeValue(" ", 2741, "`", 2742, 2, true);
#nullable restore
#line 58 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
WriteAttributeValue("", 2743, item.UserName, 2743, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2757, "`)", 2757, 2, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm btn-danger"">
                                                        <i class=""fa fa-trash""></i>
                                                    </a>
                                                </td>
                                            </tr>
");
#nullable restore
#line 63 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>




");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a075b8c6e308e1c7e99b4e8f36d56f12535cae3b11345", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>
        function postRemove(_id,name) {
            swal({
                title: ""Are you sure?"",
                text:  `${name} bazadan silinecek! Razisinizmi?`,
                icon: ""warning"",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {

                        $.ajax({
                            url: `");
#nullable restore
#line 97 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Areas\Admin\Views\Account\Clients.cshtml"
                             Write(Url.Action("DeleteClient"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"`,
                            type: ""post"",
                            data: { id: _id },
                            success: function (response) {

                                swal(""Məlumat Silindi!"", {
                                    icon: ""success"",
                                });
                                window.location.reload();
                            },
                            error: function (response) {
                                alert(""Xeta bas verdi"");
                                console.log(response.error);
                            }
                        })

                    }
                    else {
                        swal(""Məlumat silinmədi!"");
                    }
                });
        }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
