#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5247d6722be1753307b6118f12a4e6f5e0c8b4cd"
// <auto-generated/>
#pragma warning disable 1591
namespace VirtualWelshWalk.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using VirtualWelshWalk;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
using VirtualWelshWalk.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
           [AllowAnonymous]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "jumbotron jumbotron-fluid bg-cover text-white");
            __builder.AddAttribute(2, "style", "margin-bottom:0; background-image: linear-gradient(to bottom, rgba(0,0,0,0.6) 0%,rgba(0,0,0,0.6) 100%), url(\'./Assets/Culture/Strumble Head Lighthouse.jpg\'); background-repeat:no-repeat; background-size:cover;");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container text-center");
            __builder.OpenElement(5, "h1");
            __builder.AddAttribute(6, "class", "display-4");
            __builder.AddContent(7, 
#nullable restore
#line 7 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                               Localizer[Welcome]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(8, "!");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n        <br>\r\n        ");
            __builder.AddMarkupContent(10, "<p class=\"lead\">Take part in Educ8 interactive learning experience.</p>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n\r\n");
            __builder.AddMarkupContent(12, @"<div class=""jumbotron jumbotron-fluid""><div class=""container-fluid""><div class=""row""><div class=""col-4"" style=""background-color: cornsilk;""><h1>A 500 mile long walk</h1>
                <p>From Chepstow to chester following the Welsh coastal path</p></div>
            <div class=""col"" style=""background-color:#667073""><h1>Visit Welsh Landmarks</h1>
                <p>Such as Cardiff Castle, St Davids Cathedral and Beddgelert.</p></div></div></div></div>

");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "jumbotron jumbotron-fluid");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "container");
            __builder.AddMarkupContent(17, "<h1>Learn the history about the significant places of interests as you reach milestones</h1>\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(18);
            __builder.AddAttribute(19, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(20, "<p>View your progress</p>\r\n                ");
                __builder2.AddMarkupContent(21, "<a href=\"Virtual Coastal Map\" class=\"btn btn-primary btn-lg\">View Progress</a>");
            }
            ));
            __builder.AddAttribute(22, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(23, "<p>Register now to start your journey</p>\r\n                ");
                __builder2.AddMarkupContent(24, "<a href=\"Identity/Account/Register\" class=\"btn btn-primary btn-lg\">Register</a>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n\r\n");
            __builder.AddMarkupContent(26, "<div class=\"jumbotron jumbotron-fluid\"><div class=\"container text-center\"><h1>Route:</h1>\r\n        <hr>\r\n        <div class=\"row\"><div class=\"col-md-12\"><div class=\"main-timeline\"><div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">1. Chepstow (Tintern Abbey)</h3>\r\n                            <p class=\"description\">\r\n                                Start\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\" style=\"color:#fd2661;\">2. Newport (Transporter bridge)</h3>\r\n                            <p class=\"description\">\r\n                                20 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">3. Cardiff (Cardiff Castle)</h3>\r\n                            <p class=\"description\">\r\n                                12 miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">4. Porthcawl (Rest Bay Beach)</h3>\r\n                            <p class=\"description\">\r\n                                26 miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">5. Swansea (Mumbles Pier)</h3>\r\n                            <p class=\"description\">\r\n                                24 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">6. Rhossili (Fall Bay)</h3>\r\n                            <p class=\"description\">\r\n                                20 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">7. Llanelli (Parc y Scarlets)</h3>\r\n                            <p class=\"description\">\r\n                                22 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">8. Carmarthen (Kidwelly Castle)</h3>\r\n                            <p class=\"description\">\r\n                                10 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">9. Tenby (St Catherines Island)</h3>\r\n                            <p class=\"description\">\r\n                                35 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">10. Pembrokeshire (Barafundle Bay)</h3>\r\n                            <p class=\"description\">\r\n                                15 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">11. Milford Haven (Stack rock fort)</h3>\r\n                            <p class=\"description\">\r\n                                20 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">12. St David’s (St Davids Cathedral)</h3>\r\n                            <p class=\"description\">\r\n                                23 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">13. Fishguard (Strumble Head Lighthouse)</h3>\r\n                            <p class=\"description\">\r\n                                16 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">14. Cardigan (Cardigan Castle)</h3>\r\n                            <p class=\"description\">\r\n                                22 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">15. Aberystwyth (St Padarns Church)</h3>\r\n                            <p class=\"description\">\r\n                                39 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">16. Barmouth (Round House)</h3>\r\n                            <p class=\"description\">\r\n                                40 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">17. Harlech (Harlech Castle)</h3>\r\n                            <p class=\"description\">\r\n                                11 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">18. Pwllheli (Nant Gwrtheyrn)</h3>\r\n                            <p class=\"description\">\r\n                                26 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">19. Gwynedd (Beddgelert)</h3>\r\n                            <p class=\"description\">\r\n                                22 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">20. Caernarfon (Caernarfon Castle)</h3>\r\n                            <p class=\"description\">\r\n                                13 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">21. Anglesey (Beaumaris Castle)</h3>\r\n                            <p class=\"description\">\r\n                                13 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">22. Conwy (Conwy Castle)</h3>\r\n                            <p class=\"description\">\r\n                                27 Miles\r\n                            </p></a></div>\r\n\r\n                    <div class=\"timeline\"><a class=\"timeline-content\"><h3 class=\"title\">23. Chester (City Walls)</h3>\r\n                            <p class=\"description\">\r\n                                44 Miles\r\n                            </p></a></div></div></div></div></div></div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 267 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
       

    private string Welcome = "Welcome to Educ8’s Welsh Cultural Coastal Walk";

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<App> Localizer { get; set; }
    }
}
#pragma warning restore 1591
