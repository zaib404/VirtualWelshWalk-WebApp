#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a8ccb16bb9f56f467ed2febb7c039e9dfdd6476"
// <auto-generated/>
#pragma warning disable 1591
namespace VirtualWelshWalk.Shared
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
#line 1 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
using Microsoft.AspNetCore.Authentication.Cookies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class _CookieConsentPartial : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 11 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
 if (showBanner)
{
    // Show modal/popup of user confirming

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<div class=\"modal-backdrop fade show\"></div>");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "modal fade show");
            __builder.AddAttribute(3, "tabindex", "-1");
            __builder.AddAttribute(4, "role", "dialog");
            __builder.AddAttribute(5, "style", "display: block;");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "modal-dialog modal-dialog-centered");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "modal-content");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "modal-body");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "id", "cookieConsent");
            __builder.OpenElement(14, "p");
            __builder.AddAttribute(15, "style", "padding-right:3em;");
            __builder.AddContent(16, 
#nullable restore
#line 22 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
                                                       Localizer["This website uses cookies and requires your consent"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(17, " ");
            __builder.OpenElement(18, "a");
            __builder.AddAttribute(19, "href", "privacy-policy");
            __builder.AddContent(20, 
#nullable restore
#line 22 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
                                                                                                                                                  Localizer["Learn More"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddContent(21, ".");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                        ");
            __builder.OpenElement(23, "button");
            __builder.AddAttribute(24, "type", "button");
            __builder.AddAttribute(25, "class", "btn btn-primary");
            __builder.AddAttribute(26, "style", "width:100%; background-color:#af3182; border-color:#af3182;");
            __builder.AddAttribute(27, "data-dismiss", "alert");
            __builder.AddAttribute(28, "aria-label", "Close");
            __builder.AddAttribute(29, "data-cookie-string", 
#nullable restore
#line 23 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
                                                                                                                                                                                                       cookieString

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(30, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
                                                                                                                                                                                                                               AcceptMessage

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenElement(31, "span");
            __builder.AddAttribute(32, "aria-hidden", "true");
            __builder.AddContent(33, 
#nullable restore
#line 24 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
                                                      Localizer["Accept"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 31 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\_CookieConsentPartial.razor"
       
    ITrackingConsentFeature consentFeature;
    bool showBanner;
    string cookieString;

    protected override void OnInitialized()
    {
        consentFeature = hca.HttpContext.Features.Get<ITrackingConsentFeature>();
        showBanner = !consentFeature?.CanTrack ?? false;
        cookieString = consentFeature?.CreateConsentCookie();
    }

    private void AcceptMessage()
    {
        JSRuntime.InvokeVoidAsync(
            "cookieJsFunctions.acceptMessage",
            cookieString);

        showBanner = false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpContextAccessor hca { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRunTime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<App> Localizer { get; set; }
    }
}
#pragma warning restore 1591
