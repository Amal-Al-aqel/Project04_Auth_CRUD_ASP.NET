#pragma checksum "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3d470dacac0f38e7018707921521f32a62c4b0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Claims), @"mvc.1.0.view", @"/Views/Profile/Claims.cshtml")]
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
#line 1 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\_ViewImports.cshtml"
using Tuwaiq_Session_Booking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\_ViewImports.cshtml"
using Tuwaiq_Session_Booking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3d470dacac0f38e7018707921521f32a62c4b0e", @"/Views/Profile/Claims.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f839bfff9840dc32a1f72f6ebfb6f209dd94f2f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Claims : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Profile>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
  
    ViewData["Title"] = "View User Claims";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 11 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br />\r\n");
#nullable restore
#line 13 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-responsive-sm\">\r\n");
#nullable restore
#line 16 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
         foreach (var claim in User.Claims)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
               Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
               Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
               Write(claim.Issuer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 23 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 25 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Profile\Claims.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Profile>> Html { get; private set; }
    }
}
#pragma warning restore 1591