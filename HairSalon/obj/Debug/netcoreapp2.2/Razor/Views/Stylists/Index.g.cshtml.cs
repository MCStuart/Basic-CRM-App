#pragma checksum "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06c6d66db8483308ed3934113354e0532a591aac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stylists_Index), @"mvc.1.0.view", @"/Views/Stylists/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stylists/Index.cshtml", typeof(AspNetCore.Views_Stylists_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06c6d66db8483308ed3934113354e0532a591aac", @"/Views/Stylists/Index.cshtml")]
    public class Views_Stylists_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 19, true);
            WriteLiteral("<h1>Stylists</h1>\n\n");
            EndContext();
#line 3 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml"
 if (@Model.Count == 0)
{

#line default
#line hidden
            BeginContext(45, 44, true);
            WriteLiteral("  <h3>No stylists have been added yet!</h3>\n");
            EndContext();
#line 6 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml"
}

#line default
#line hidden
            BeginContext(91, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 8 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml"
 foreach (var stylist in Model)
{

#line default
#line hidden
            BeginContext(126, 8, true);
            WriteLiteral("  <h3><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 134, "\'", 170, 2);
            WriteAttributeValue("", 141, "/stylists/", 141, 10, true);
#line 10 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml"
WriteAttributeValue("", 151, stylist.stylist_id, 151, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(171, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(173, 20, false);
#line 10 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml"
                                         Write(stylist.stylist_name);

#line default
#line hidden
            EndContext();
            BeginContext(193, 10, true);
            WriteLiteral("</a></h3>\n");
            EndContext();
#line 11 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Index.cshtml"
}

#line default
#line hidden
            BeginContext(205, 142, true);
            WriteLiteral("\n<p><a href=\'/\'>Back home</a></p>\n\n<form action=\"/stylists/delete\" method=\"post\">\n  <button type=\"submit\">Clear stylist list</button>\n</form>\n");
            EndContext();
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
