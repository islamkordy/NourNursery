#pragma checksum "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fd2fb09e89cba2a761988abff79239a83e304c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BasicInput_Views_Product_Search), @"mvc.1.0.view", @"/Areas/BasicInput/Views/Product/Search.cshtml")]
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
#line 1 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using NourNursery.Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using NourNursery.Portal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using Models.ViewModel.BasicInput;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using Portal.Resource.GlobalRes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using Portal.Resource.BasicInput;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fd2fb09e89cba2a761988abff79239a83e304c0", @"/Areas/BasicInput/Views/Product/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79840419141d3b3bc2add036bbaab7e3e34b58e9", @"/Areas/BasicInput/Views/_ViewImports.cshtml")]
    public class Areas_BasicInput_Views_Product_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.ViewModel.BasicInput.ProductVm>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
  
    int str = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"panel\">\r\n    <table id=\"example5\" class=\"table table-bordered table-striped\" style=\"width:100%\">\r\n        <thead>\r\n            <tr>\r\n                <th>");
#nullable restore
#line 10 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
               Write(BasicInputRes.TitleAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 11 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
               Write(BasicInputRes.TitleEn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 12 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
               Write(BasicInputRes.DescAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 13 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
               Write(BasicInputRes.DescEn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 14 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
               Write(BasicInputRes.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
            WriteLiteral("                <th>");
#nullable restore
#line 17 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
               Write(GlobalRes.Action);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 21 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 24 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
                   Write(Html.Raw(item.TitleAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
                   Write(Html.Raw(item.TitleEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
                   Write(Html.Raw(item.DescAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
                   Write(Html.Raw(item.DescEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral(@"                    <td>
                        <div class=""btn-group display-inline pull-right text-align-left hidden-tablet"">
                            <button class=""btn btn-xs btn-default dropdown-toggle"" data-toggle=""dropdown"">
                                <i class=""fa fa-cog fa-lg""></i>
                            </button>
                            <ul class=""dropdown-menu dropdown-menu-xs pull-right"">
                                <li>
                                    <input type=""button"" id=""btnUpdate""");
            BeginWriteAttribute("onclick", " onclick=\"", 1651, "\"", 1675, 3);
            WriteAttributeValue("", 1661, "Edit(", 1661, 5, true);
#nullable restore
#line 38 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
WriteAttributeValue("", 1666, item.Id, 1666, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1674, ")", 1674, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1676, "\"", 1702, 1);
#nullable restore
#line 38 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
WriteAttributeValue("", 1684, GlobalRes.btnEdit, 1684, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </li>\r\n                                <li class=\"divider\"></li>\r\n                                <li>\r\n                                    <input type=\"button\" id=\"btnDelete\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1915, "\"", 1941, 3);
            WriteAttributeValue("", 1925, "Delete(", 1925, 7, true);
#nullable restore
#line 42 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
WriteAttributeValue("", 1932, item.Id, 1932, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1940, ")", 1940, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1942, "\"", 1970, 1);
#nullable restore
#line 42 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
WriteAttributeValue("", 1950, GlobalRes.btnDelete, 1950, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </li>\r\n                                <li class=\"divider\"></li>\r\n                                <li class=\"text-align-center\">\r\n                                    <a href=\"javascript:void(0);\">");
#nullable restore
#line 46 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
                                                             Write(GlobalRes.btnCancel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n                            </ul>\r\n                        </div>\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 53 "E:\work\NourNursery\NourNursery.Portal\Areas\BasicInput\Views\Product\Search.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <br />\r\n    <br />\r\n    <br />\r\n</div>\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        $(\'#example5\').DataTable({\r\n\r\n        });\r\n    });\r\n\r\n</script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.ViewModel.BasicInput.ProductVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
