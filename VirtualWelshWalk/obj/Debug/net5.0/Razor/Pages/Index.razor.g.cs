#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "245dee008a55505f51225ecfafc36f173fbb9993"
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
#line 13 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
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
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenComponent<VirtualWelshWalk.Pages.VirtualMap>(2);
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(3, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "class", "container-fluid text-white hero");
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "row align-items-center pt-5 heroOverlay");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "col-sm-12 col-md-7 pl-5 pb-3 pt-5");
                __builder2.OpenElement(10, "h1");
                __builder2.AddAttribute(11, "class", "h1 hero-text widow-orpah-me");
                __builder2.AddAttribute(12, "style", "font-weight:900");
                __builder2.AddContent(13, 
#nullable restore
#line 18 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                                                                                     Localizer["Take part in Educ8's interactive learning experience"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n\r\n                ");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "col-7 pt-5 pl-5 pb-5");
                __builder2.OpenElement(17, "a");
                __builder2.AddAttribute(18, "class", "btn rounded-pill text-white");
                __builder2.AddAttribute(19, "style", "background-color:#af3182;");
                __builder2.AddAttribute(20, "href", "Identity/Account/Register");
                __builder2.AddContent(21, 
#nullable restore
#line 23 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                         Localizer["JOIN NOW"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(22, "\r\n\r\n        ");
                __builder2.OpenElement(23, "div");
                __builder2.AddAttribute(24, "class", "container-fluid text-center p-5");
                __builder2.AddAttribute(25, "style", "background-color:#303b3d; color:#dbdc52;");
                __builder2.OpenElement(26, "div");
                __builder2.AddAttribute(27, "class", "container");
                __builder2.AddAttribute(28, "style", "height:100%;");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "row align-items-center pt-5 pb-5");
                __builder2.OpenElement(31, "h1");
                __builder2.AddAttribute(32, "class", "h1 hero-text widow-orpah-me");
                __builder2.AddContent(33, 
#nullable restore
#line 34 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                         Localizer["Discover places of history along the way from Chepstow to Chester"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(34, "\r\n\r\n        ");
                __builder2.OpenElement(35, "div");
                __builder2.AddAttribute(36, "class", "container-fluid text-center text-white p-5");
                __builder2.AddAttribute(37, "style", "background-color:#474e58;");
                __builder2.OpenElement(38, "h1");
                __builder2.AddAttribute(39, "class", "h1 pb-5");
                __builder2.AddContent(40, 
#nullable restore
#line 42 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                 Localizer["Visit exciting places in and around Wales"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n\r\n            ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "row");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "col-sm");
                __builder2.AddMarkupContent(46, "<img src=\"/Assets/WebPage/CardiffCastleRound.png\" class=\"img-fluid\">\r\n                    ");
                __builder2.OpenElement(47, "h5");
                __builder2.AddAttribute(48, "class", "h5 p-3");
                __builder2.AddContent(49, 
#nullable restore
#line 48 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                                        Localizer["Cardiff Castle"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n\r\n                ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "col-sm");
                __builder2.AddMarkupContent(53, "<img src=\"/Assets/WebPage/StDavidsCathedralRound.png\" class=\"img-fluid\">\r\n                    ");
                __builder2.OpenElement(54, "h5");
                __builder2.AddAttribute(55, "class", "h5 p-3");
                __builder2.AddContent(56, 
#nullable restore
#line 53 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                                        Localizer["St. Davids Cathedral"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(57, "\r\n\r\n                ");
                __builder2.OpenElement(58, "div");
                __builder2.AddAttribute(59, "class", "col-sm");
                __builder2.AddMarkupContent(60, "<img src=\"/Assets/WebPage/BeddGelertRound.png\" class=\"img-fluid\">\r\n                    ");
                __builder2.OpenElement(61, "h5");
                __builder2.AddAttribute(62, "class", "h5 p-3");
                __builder2.AddContent(63, 
#nullable restore
#line 58 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
                                        Localizer["Bedd Gelert"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 68 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\Index.razor"
 
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await jsRunTime.InvokeVoidAsync("window.onload");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRunTime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<App> Localizer { get; set; }
    }
}
#pragma warning restore 1591
