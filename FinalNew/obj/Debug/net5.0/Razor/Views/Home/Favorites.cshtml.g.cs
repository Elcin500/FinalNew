#pragma checksum "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbfabaa455aad3e1e2bd5498aee3bf58dd6fc29d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Favorites), @"mvc.1.0.view", @"/Views/Home/Favorites.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbfabaa455aad3e1e2bd5498aee3bf58dd6fc29d", @"/Views/Home/Favorites.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3deb200e221bd0bd61f955fec26d2459e4ff3433", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Favorites : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<Home>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "announces", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
  
    ViewData["Title"] = "Favorites";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""background-img"" data-setbg=""assets/img/details-background.jpg"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <h1>My Favorites</h1>
                <ul>
                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbfabaa455aad3e1e2bd5498aee3bf58dd6fc29d4943", async() => {
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
            WriteLiteral(@"                    <li><span class=""slash"">/</span><span>Favorites</span></li>
                </ul>
            </div>
        </div>
    </div>
</section>

<section class=""homes"">
    <div class=""container"">
        <div class=""title"">
            <h2>My Favorites</h2>
            <hr>
        </div>
        <div class=""row"">
");
#nullable restore
#line 28 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
             if (Model != null && Model.Count > 0)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                 foreach (var home in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4 col-md-6 col-12 single-home\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbfabaa455aad3e1e2bd5498aee3bf58dd6fc29d7287", async() => {
                WriteLiteral("\r\n                            <img");
                BeginWriteAttribute("src", " src=\"", 1165, "\"", 1213, 2);
                WriteAttributeValue("", 1171, "uploads/", 1171, 8, true);
#nullable restore
#line 34 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
WriteAttributeValue("", 1179, home.Images.FirstOrDefault().Path, 1179, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1214, "\"", 1220, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                                             WriteLiteral(home.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div class=\"caption\">\r\n                            <h4> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbfabaa455aad3e1e2bd5498aee3bf58dd6fc29d10398", async() => {
#nullable restore
#line 37 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                                                                       Write(home.Address);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                                                      WriteLiteral(home.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1429, "\"", 1466, 3);
            WriteAttributeValue("", 1439, "addFavorite(", 1439, 12, true);
#nullable restore
#line 37 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
WriteAttributeValue("", 1451, home.Id, 1451, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1459, ",event)", 1459, 7, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"padding-right:0; \" class=\"like\"><i style=\"color:#EA2027\" class=\"fas fa-heart\"></i></a></h4>\r\n                            <span>\r\n                                $");
#nullable restore
#line 39 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                            Write(home.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <span>\r\n                                    /\r\n");
#nullable restore
#line 42 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                     if (home.AnnounceType == "Rent")
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                   Write(home.Period);

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                    
                                    }
                                    else if (home.AnnounceType == "Sale")
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                    Write("sale");

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                 
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </span>
                            </span>
                            <ul>
                                <li>
                                    <i class=""fas fa-vector-square""></i>
                                    <span>
");
#nullable restore
#line 56 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                         if (!string.IsNullOrWhiteSpace(home.Area))
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                       Write(home.Area);

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                      
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(" sq ft\r\n                                    </span>\r\n                                </li>\r\n                                <li>\r\n                                    <i class=\"fas fa-bath\"></i>\r\n                                    <span>\r\n");
#nullable restore
#line 65 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                         if (home.BathCount > 0)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                       Write(home.BathCount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                           
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                        Write(0);

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        bathrooms
                                    </span>
                                </li>
                            </ul>

                            <ul class=""second-ul"">
                                <li>
                                    <span>
                                        <i class=""fas fa-bed""></i>
");
#nullable restore
#line 82 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                         if (home.RoomCount > 0)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                       Write(home.RoomCount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                           
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                        Write(0);

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        rooms
                                    </span>
                                </li>
                                <li>
                                    <span>
                                        <i class=""fas fa-car""></i>
");
#nullable restore
#line 96 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                         if (home.GarageCount > 0)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                       Write(home.GarageCount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                             
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                        Write(0);

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        garages\r\n                                    </span>\r\n                                </li>\r\n                            </ul>\r\n                            <p>\r\n");
#nullable restore
#line 109 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                 if (home.Description.Length > 100)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                               Write(home.Description.Substring(0, 100));

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                                   Write("...");

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                                               
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                               Write(home.Description);

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </p>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 120 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-12 text-center\"><h1 style=\" color: #46474a; margin-left: 10%; margin-top: 20px;\">Secilmis Hec Bir Elan Yoxdur</h1></div>\r\n");
#nullable restore
#line 125 "C:\Users\hp\source\repos\FinalNewHome\FinalNew\Views\Home\Favorites.cshtml"

                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
   
    <script>


        function onlyUnique(value, index, self) {
            return self.indexOf(value) === index;
        }

        function addFavorite(id, event) {
            // event.stopPropagation();
            event.preventDefault();

            let cardItems = $.cookie('card-items');
            let items;

            if ($(event.currentTarget.children[0]).hasClass('fas fa-heart')) {
                $(event.currentTarget).html('<i class=""far fa-heart""></i>');
                console.log('--------ag');

                if (cardItems == null) {
                    items = [];
                }
                else {
                    items = cardItems.split(',').map(e => parseInt(e));
                }


                //items.forEach(e => {
                //    if (e==id) {
                //        $(items).remove(e);


                //        console.log('silindi');
                //    }
                //});
                var removeItem = id;
");
                WriteLiteral(@"
                items = $.grep(items, function (value) {
                    return value != removeItem;
                })

                //console.log(items);

                $.cookie('card-items', items.toString(), { expires: 5, path: '/'} );

               // console.log('cookiden silindi');
                //console.log($.cookie('card-items'));


            }
            else {
                $(event.currentTarget).html('<i style=""color:#EA2027"" class=""fas fa-heart""></i>');
                //console.log('-----------qirmizi');


                if (cardItems == null) {
                    items = [];
                }
                else {
                    items = cardItems.split(',').map(e => parseInt(e));
                }

                items.push(id);
                items = items.filter(onlyUnique);


                $.cookie('card-items', items.toString(), { expires: 5, path: '/'});

                //console.log('cookide');

            }

          ");
                WriteLiteral("  // $(\'.item-count\').removeClass(\'d-none\').html(items.length);\r\n\r\n        }\r\n\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<Home>> Html { get; private set; }
    }
}
#pragma warning restore 1591
