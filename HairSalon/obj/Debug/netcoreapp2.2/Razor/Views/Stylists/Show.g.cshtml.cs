#pragma checksum "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65d88b569fdecb75f0773de8c5ec77358259700d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stylists_Show), @"mvc.1.0.view", @"/Views/Stylists/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stylists/Show.cshtml", typeof(AspNetCore.Views_Stylists_Show))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65d88b569fdecb75f0773de8c5ec77358259700d", @"/Views/Stylists/Show.cshtml")]
    public class Views_Stylists_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 57, true);
            WriteLiteral("<h3>Here are all the clients of this Stylist:</h3>\n\n<ol>\n");
            EndContext();
#line 4 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml"
 foreach (var client in @Model["client"])
{

#line default
#line hidden
            BeginContext(101, 8, true);
            WriteLiteral("  <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 109, "\'", 180, 4);
            WriteAttributeValue("", 116, "/stylists/", 116, 10, true);
#line 6 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml"
WriteAttributeValue("", 126, Model["stylist"].stylist_id, 126, 28, false);

#line default
#line hidden
            WriteAttributeValue("", 154, "/clients/", 154, 9, true);
#line 6 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml"
WriteAttributeValue("", 163, client.client_id, 163, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(181, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(183, 18, false);
#line 6 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml"
                                                                            Write(client.client_name);

#line default
#line hidden
            EndContext();
            BeginContext(201, 10, true);
            WriteLiteral("</a></li>\n");
            EndContext();
#line 7 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml"
}

#line default
#line hidden
            BeginContext(213, 12, true);
            WriteLiteral("</ol>\n\n<p><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 225, "\'", 282, 3);
            WriteAttributeValue("", 232, "/stylists/", 232, 10, true);
#line 10 "/Users/mcstuart/Desktop/Friday-Project-Week8/HairSalon/Views/Stylists/Show.cshtml"
WriteAttributeValue("", 242, Model["stylist"].stylist_id, 242, 28, false);

#line default
#line hidden
            WriteAttributeValue("", 270, "/clients/new", 270, 12, true);
            EndWriteAttribute();
            BeginContext(283, 123, true);
            WriteLiteral(">Add a new client</a></p>\n<p><a href=\'/stylists\'>Return to stylist list</a></p>\n<p><a href=\'/\'>Return to Main Page</a></p>\n");
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
