#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "973d72d7be1d7584e2f33868644259d7e90b51a0"
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
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "div");
                __builder2.AddAttribute(3, "class", "top-row pl-4 navbar navbar-dark");
                __builder2.AddMarkupContent(4, "<a class=\"navbar-brand\" href>VirtualWelshWalk</a>\r\n        ");
                __builder2.OpenElement(5, "button");
                __builder2.AddAttribute(6, "class", "navbar-toggler");
                __builder2.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\NavMenu.razor"
                                                 ToggleNavMenu

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\"></span>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(9, "\r\n\r\n    ");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", 
#nullable restore
#line 10 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\NavMenu.razor"
                 NavMenuCssClass

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\NavMenu.razor"
                                            ToggleNavMenu

#line default
#line hidden
#nullable disable
                ));
                __builder2.OpenElement(13, "ul");
                __builder2.AddAttribute(14, "class", "nav flex-column");
                __builder2.OpenElement(15, "li");
                __builder2.AddAttribute(16, "class", "nav-item px-3");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(17);
                __builder2.AddAttribute(18, "class", "nav-link");
                __builder2.AddAttribute(19, "href", "");
                __builder2.AddAttribute(20, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 13 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\NavMenu.razor"
                                                         NavLinkMatch.All

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(22, "<span class=\"oi oi-home\" aria-hidden=\"true\"></span> Home\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n            ");
                __builder2.OpenElement(24, "li");
                __builder2.AddAttribute(25, "class", "nav-item px-3");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(26);
                __builder2.AddAttribute(27, "class", "nav-link");
                __builder2.AddAttribute(28, "href", "DailySteps");
                __builder2.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(30, "<span class=\"oi oi-plus\" aria-hidden=\"true\"></span> Input Steps\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n            ");
                __builder2.OpenElement(32, "li");
                __builder2.AddAttribute(33, "class", "nav-item px-3");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(34);
                __builder2.AddAttribute(35, "class", "nav-link");
                __builder2.AddAttribute(36, "href", "fetchdata");
                __builder2.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(38, "<span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> Fetch data\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
