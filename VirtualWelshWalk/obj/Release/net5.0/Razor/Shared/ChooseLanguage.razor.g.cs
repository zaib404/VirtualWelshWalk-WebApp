#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\ChooseLanguage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3eba836cbdbf89210020d9f7e5b45740e0889e76"
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
#line 13 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class ChooseLanguage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\ChooseLanguage.razor"
 if (cultures != null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "custom-control custom-switch");
            __builder.OpenElement(2, "input");
            __builder.AddAttribute(3, "type", "checkbox");
            __builder.AddAttribute(4, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\ChooseLanguage.razor"
                                                                () => RequestCultureChange(isWelshChecked = !isWelshChecked)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "class", "custom-control-input");
            __builder.AddAttribute(6, "id", "lngSwitch");
            __builder.AddAttribute(7, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 7 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\ChooseLanguage.razor"
                                      isWelshChecked

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => isWelshChecked = __value, isWelshChecked));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.AddMarkupContent(10, "<label class=\"custom-control-label\" for=\"lngSwitch\">EN/CY</label>");
            __builder.CloseElement();
#nullable restore
#line 10 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\ChooseLanguage.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\ChooseLanguage.razor"
       

    private string selectedCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
    private Dictionary<string, string> cultures;
    bool isWelshChecked { get; set; }

    protected override void OnInitialized()
    {
        cultures = Configuration.GetSection("Cultures")
            .GetChildren().ToDictionary(x => x.Key, x => x.Value);

        if (selectedCulture.ToLower() == "en-gb".ToLower())
        {
            isWelshChecked = false;
        }
        else
        {
            isWelshChecked = true;
        }
    }

    private void RequestCultureChange(bool pWelshCheck)
    {
        var uri = new Uri(NavigationManager.Uri)
        .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);

        if (!pWelshCheck)
        {
            selectedCulture = cultures.FirstOrDefault(x => x.Value.ToLower() == "English".ToLower()).Key;
        }
        else
        {
            selectedCulture = cultures.FirstOrDefault(x => x.Value.ToLower() == "Welsh".ToLower()).Key;
        }
        var query = $"?culture={Uri.EscapeDataString(selectedCulture)}&" +
        $"redirectUri={Uri.EscapeDataString(uri)}";

        NavigationManager.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);

        isWelshChecked = pWelshCheck;

    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Configuration.IConfiguration Configuration { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRunTime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<App> Localizer { get; set; }
    }
}
#pragma warning restore 1591
