#pragma checksum "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\Category\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e47588b781da6bcd7bc862ee00811bbf928c42ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BasicInput_Views_Category_Delete), @"mvc.1.0.view", @"/Areas/BasicInput/Views/Category/Delete.cshtml")]
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
#line 1 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using NourNursery.Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using NourNursery.Portal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using Models.ViewModel.BasicInput;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using Portal.Resource.GlobalRes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\_ViewImports.cshtml"
using Portal.Resource.BasicInput;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e47588b781da6bcd7bc862ee00811bbf928c42ca", @"/Areas/BasicInput/Views/Category/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79840419141d3b3bc2add036bbaab7e3e34b58e9", @"/Areas/BasicInput/Views/_ViewImports.cshtml")]
    public class Areas_BasicInput_Views_Category_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModel.BasicInput.CategoryVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"modal-dialog\" style=\"width: 900px;\">\r\n    <div class=\"modal-content\">\r\n        <div class=\"modal-header\">\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>\r\n            <h4 class=\"modal-title\"> ");
#nullable restore
#line 9 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\Category\Delete.cshtml"
                                Write(GlobalRes.btnDelete);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n        </div>\r\n        <div class=\"modal-body\" style=\"width :900px;\">\r\n\r\n            <h4 class=\"modal-title\"> ");
#nullable restore
#line 13 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\Category\Delete.cshtml"
                                Write(GlobalRes.MessageDeleteDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ? </h4>\r\n            <div class=\"row\">\r\n                <div class=\"col-md-3\">\r\n                    <input type=\"button\"");
            BeginWriteAttribute("value", " value=\"", 584, "\"", 612, 1);
#nullable restore
#line 16 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\Category\Delete.cshtml"
WriteAttributeValue("", 592, GlobalRes.btnDelete, 592, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn yellow Saveee\"");
            BeginWriteAttribute("onclick", " onclick=\"", 639, "\"", 669, 3);
            WriteAttributeValue("", 649, "DeleteRow(", 649, 10, true);
#nullable restore
#line 16 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\Category\Delete.cshtml"
WriteAttributeValue("", 659, Model.Id, 659, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 668, ")", 668, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">");
#nullable restore
#line 17 "E:\work\NourNursery\HD.Portal\Areas\BasicInput\Views\Category\Delete.cshtml"
                                                                                  Write(GlobalRes.btnCancel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModel.BasicInput.CategoryVm> Html { get; private set; }
    }
}
#pragma warning restore 1591