#pragma checksum "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbe167dc0a77729271d73c64712bcd2b1d864597"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
#line 2 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\_ViewImports.cshtml"
using FinalNew.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\_ViewImports.cshtml"
using FinalNew.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\_ViewImports.cshtml"
using Final.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbe167dc0a77729271d73c64712bcd2b1d864597", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3deb200e221bd0bd61f955fec26d2459e4ff3433", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "LogOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3 needs-validation d-none login-form-first"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3 needs-validation registr-form-second"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RegistrClient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3 needs-validation d-none registr-agent-form-third"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RegistrAgent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ckeditor5/ckeditor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Login.cshtml"
  
    ViewData["Title"] = "Login";
    string message = TempData["message"] as string;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("style", async() => {
                WriteLiteral(@"
    <style>
        .ck-editor__editable {
            min-height: 200px !important;
        }

        #imageFile {
            display: none;
        }

        #image-viewer {
            width: 300px;
            height: 300px;
            border: 1px solid #ccc;
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center;
            border-radius:5px;
        }

        #image-viewer > a {
            display:inline-block;
            padding-top:7px;
            padding-left:10px;
            padding-right:10px;
            padding-bottom:10px;
            font-size:20px;
            color:red;
            cursor: pointer;
        }

        .registr-agent-form-third .row > .col-12{
            margin-top: 16px;
        }
    </style>
");
            }
            );
            WriteLiteral("\r\n<section class=\"background-img\" data-setbg=\"assets/img/details-background.jpg\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <h1>Login</h1>\r\n                <ul>\r\n                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe167dc0a77729271d73c64712bcd2b1d8645979594", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
            WriteLiteral("                    <li><span class=\"slash\">/</span><span>Login</span></li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n<section class=\"login-form\">\r\n    <div class=\"container\">\r\n");
#nullable restore
#line 64 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Login.cshtml"
         if (message != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-sm-12\">\r\n                    <div class=\"alert alert-danger\" role=\"alert\">\r\n                        ");
#nullable restore
#line 69 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Login.cshtml"
                   Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 73 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Login.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"title\">\r\n            <h2 class=\"d-flex justify-content-between\"><span>Sign In</span>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe167dc0a77729271d73c64712bcd2b1d86459712245", async() => {
                WriteLiteral("Sign Out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</h2>
            <hr>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">

                <ul>
                    <li class=""li-login"">Login</li>
                    <li class=""li-registr selected"">Registration</li>
                    <li class=""li-agent-registr"">Registr As Agent</li>
                </ul>

                <div class=""row"">
                    <div class=""col-lg-5"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe167dc0a77729271d73c64712bcd2b1d86459713950", async() => {
                WriteLiteral(@"
                            <div class=""col-12"">
                                <label for=""username"" class=""form-label"">Username or e-mail</label>
                                <input type=""text"" name=""username"" class=""form-control"" id=""username"" required>
                                <div class=""valid-feedback"">
                                    Looks Good
                                </div>
                                <div class=""invalid-feedback"">
                                    Enter Your Name
                                </div>
                            </div>
                            <div class=""col-12"">
                                <label for=""password"" class=""form-label"">Password</label>
                                <input type=""password"" name=""password"" class=""form-control"" id=""password"" required>
                                <div class=""valid-feedback"">
                                    Looks Good
                                </div>
       ");
                WriteLiteral(@"                         <div class=""invalid-feedback"">
                                    Enter Password Correctly
                                </div>
                            </div>
                            <div class=""col-md-6 col-8"">
                                <button type=""submit"" class=""btn btn-primary"">Daxil Ol</button>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe167dc0a77729271d73c64712bcd2b1d86459717515", async() => {
                WriteLiteral(@"
                            <div class=""col-12"">
                                <label for=""usernameRegistr"" class=""form-label"">Username</label>
                                <input type=""text"" class=""form-control"" name=""usernameRegistr"" id=""usernameRegistr"" required>
                                <div class=""valid-feedback"">
                                    Looks Good
                                </div>
                                <div class=""invalid-feedback"">
                                    Enter Your Username
                                </div>
                            </div>
                            <div class=""col-12"">
                                <label for=""emailRegistr"" class=""form-label"">Email</label>
                                <input type=""email"" class=""form-control"" name=""emailRegistr"" id=""emailRegistr"" required>
                                <div class=""valid-feedback"">
                                    Looks Good
                          ");
                WriteLiteral(@"      </div>
                                <div class=""invalid-feedback"">
                                    Enter An Email Correctly
                                </div>
                            </div>
                            <div class=""col-12"">
                                <label for=""passwordRegistr"" class=""form-label"">Password</label>
                                <input type=""password"" class=""form-control"" name=""passwordRegistr"" id=""passwordRegistr"" required>
                                <div class=""valid-feedback"">
                                    Looks Good
                                </div>
                                <div class=""invalid-feedback"">
                                    Enter Password
                                </div>
                            </div>
                            <div class=""col-md-6 col-8"">
                                <button type=""submit"" class=""btn btn-primary"">Təsdiqlə</button>
                            </di");
                WriteLiteral("v>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-lg-12\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe167dc0a77729271d73c64712bcd2b1d86459721852", async() => {
                WriteLiteral(@"
                            <div class=""col-md-6 col-12"">
                                <div class=""row"">
                                    <div class=""col-12"">
                                        <label for=""agentName"" class=""form-label"">Name</label>
                                        <input type=""text"" class=""form-control"" name=""agentName"" id=""agentName"" required>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter Your Name
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agentSurname"" class=""form-label"">Surname</label>
                                        <input type=""text"" class=""form-contr");
                WriteLiteral(@"ol"" name=""agentSurname"" id=""agentSurname"" required>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter Your Surname
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agentPhone"" class=""form-label"">Phone</label>
                                        <input type=""text"" class=""form-control"" name=""agentPhone"" id=""agentPhone"" required>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                          ");
                WriteLiteral(@"  Enter Your Phone
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agentPhone2"" class=""form-label"">Phone (2)</label>
                                        <input type=""text"" class=""form-control"" name=""agentPhone2"" id=""agentPhone2"" placeholder=""Vacib deyil"">
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agency"" class=""form-label"">Agency</label>
                                        <input type=""text"" class=""form-control"" name=""agency"" placeholder=""Vacib deyil"">
                                        <div class=""valid-feedback"">
                                            ");
                WriteLiteral(@"Looks Good
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agentAdress"" class=""form-label"">Adress</label>
                                        <input type=""text"" class=""form-control"" name=""agentAdress"" id=""agentAdress"" required>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter Your Adress
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""facebookLink"" class=""form-label"">Facebook Link</label>
                                        <input type=""text"" class=""fo");
                WriteLiteral(@"rm-control"" name=""facebookLink"" placeholder=""Vacib deyil"">
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""instagramLink"" class=""form-label"">Instagram Link</label>
                                        <input type=""text"" class=""form-control"" name=""instagramLink"" placeholder=""Vacib deyil"">
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""twitterLink"" class=""form-label"">Twitter Link</label>
                                        <input type=""text"" class=""f");
                WriteLiteral(@"orm-control"" name=""twitterLink"" placeholder=""Vacib deyil"">
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agentDescription"" class=""form-label"">Description</label>
                                        <textarea class=""form-control"" name=""agentDescription"" id=""agentDescription"" rows=""4"" required></textarea>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter A Description
                                        </div>
                                    </div>
                           ");
                WriteLiteral(@"         <div class=""col-12"">
                                        <label for=""agnetUsername"" class=""form-label"">Username</label>
                                        <input type=""text"" class=""form-control"" name=""agnetUsername"" id=""agnetUsername"" required>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter Your Username
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agnetEmail"" class=""form-label"">Email</label>
                                        <input type=""email"" class=""form-control"" name=""agentEmail"" id=""agentEmail"" required>
                                        <div class=""valid-feedback"">
   ");
                WriteLiteral(@"                                         Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter An Email Correctly
                                        </div>
                                    </div>
                                    <div class=""col-12"">
                                        <label for=""agentPassword"" class=""form-label"">Password</label>
                                        <input type=""password"" class=""form-control"" name=""agentPassword"" id=""agentPassword"" required>
                                        <div class=""valid-feedback"">
                                            Looks Good
                                        </div>
                                        <div class=""invalid-feedback"">
                                            Enter Password
                                        </div>
                                    </");
                WriteLiteral(@"div>
                                </div>
                            </div>
                            <div class=""col-md-6 col-12"">
                                <div class=""row"">
                                    <div class=""form-group col-lg-9 offset-lg-3 col-10 offset-sm-2"">
                                        <label for=""imageFile"" id=""image-viewer"">
                                            <a href=""#""><i class=""fas fa-trash-alt""></i></a>
                                        </label>
                                        <input type=""file"" name=""image"" id=""imageFile"" accept=""image/x-png,image/gif,image/jpeg"" />
                                        <p style=""margin-left:29px; color:#8f8f8f;"">
                                            Şəkil seçmək üçün yuxarı click edin
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div clas");
                WriteLiteral("s=\"col-md-6 col-8\">\r\n                                <button type=\"submit\" class=\"btn btn-primary\">Təsdiqlə</button>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbe167dc0a77729271d73c64712bcd2b1d86459734188", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        $('.registr-agent-form-third').on(""keyup keypress"", function (e) {
            var keycode = e.keycode || e.which;
            if (keycode == 13) {
                e.preventDefault();
                return false;
            }
        });

        $('#image-viewer > a').click(function (e) {

            e.preventDefault();
            e.stopPropagation();

            $(e.currentTarget).closest('label').css('background-image', 'none');

            $('#imageFile').val('');


        })


        $('#imageFile').change(function (e) {

            let reader = new FileReader();
            reader.addEventListener(""load"", function () {
                $('#image-viewer').css({
                    'background-image': `url(${reader.result})`
                })
            }, false);

            reader.readAsDataURL(e.target.files[0]);

            //console.log('changed');

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
