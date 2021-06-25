#pragma checksum "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0abfad65e69f8ce06c1eec183a4879717b4fe302"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Session_RequestedSessionsIndex), @"mvc.1.0.view", @"/Views/Session/RequestedSessionsIndex.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0abfad65e69f8ce06c1eec183a4879717b4fe302", @"/Views/Session/RequestedSessionsIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f839bfff9840dc32a1f72f6ebfb6f209dd94f2f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Session_RequestedSessionsIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
  
    var Sessions = (List<Session>)ViewData["Sessions"];
    var ConfirmedSessions = (List<Session>)ViewData["ConfirmedSessions"];
    var RequestedSessions = (List<Session>)ViewData["RequstedSessions"];
    var Subjects = (List<Subject>)ViewData["Subjects"];
    var Classes = (List<Class>)ViewData["Classes"];


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n");
#nullable restore
#line 14 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
      
        if (RequestedSessions == null || RequestedSessions.Count == 0)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>No Requested Sessions!!</h3>\r\n");
#nullable restore
#line 19 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"

        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>Requested Sessions</h1>\r\n");
            WriteLiteral("            <table class=\"table\">\r\n                <tr>\r\n                    <th>Time</th>\r\n                    <th>Duration</th>\r\n                    <th>Location</th>\r\n                    <th>Subject</th>\r\n");
#nullable restore
#line 31 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                     if (User.IsInRole("Instructor"))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th></th>\r\n                        <th></th>\r\n                        <th></th>\r\n");
#nullable restore
#line 37 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n                <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                     foreach (var Session in Sessions)
                    {
                        if(Session.Confirmed == false) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 45 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                           Write(Session.SessionTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 46 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                           Write(Session.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 47 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                              var sessionClass = Classes.Find(c => c.Id == Session.ClassId);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 48 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                           Write(sessionClass.ClassName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 50 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                              var sessionSubject = Subjects.Find(s => s.Id == Session.SubjectId);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 51 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                           Write(sessionSubject.SubjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 52 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                             if (User.IsInRole("Instructor"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    <a class=\"btn btn-colour-2\"");
            BeginWriteAttribute("href", " href=\"", 1962, "\"", 2000, 2);
            WriteAttributeValue("", 1969, "../Session/Edit/?id=", 1969, 20, true);
#nullable restore
#line 55 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
WriteAttributeValue("", 1989, Session.Id, 1989, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n                                </td>\r\n                                <td>\r\n                                    <a class=\"btn btn-colour-2\"");
            BeginWriteAttribute("href", " href=\"", 2152, "\"", 2192, 2);
            WriteAttributeValue("", 2159, "../Session/Delete/?id=", 2159, 22, true);
#nullable restore
#line 58 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
WriteAttributeValue("", 2181, Session.Id, 2181, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                                </td>\r\n                                <td>\r\n                                    <a class=\"btn btn-colour-2\"");
            BeginWriteAttribute("href", " href=\"", 2346, "\"", 2387, 2);
            WriteAttributeValue("", 2353, "../Session/Confirm/?id=", 2353, 23, true);
#nullable restore
#line 61 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
WriteAttributeValue("", 2376, Session.Id, 2376, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Confirm</a>\r\n                                </td>\r\n");
#nullable restore
#line 63 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 65 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 69 "C:\Users\96655\source\repos\Tuwaiq Session Booking\Tuwaiq Session Booking\Views\Session\RequestedSessionsIndex.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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