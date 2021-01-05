#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1cddb910178d510040da3dd51741c06530f64c7"
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
#line 3 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
using DataAccess.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
using VirtualWelshWalk.DataAccess.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
using VirtualWelshWalk.DataAccess.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Virtual Welsh Map")]
    public partial class VirtualMap : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<link href=\"https://api.mapbox.com/mapbox-gl-js/v2.0.0/mapbox-gl.css\" rel=\"stylesheet\">\r\n\r\n");
            __builder.AddMarkupContent(1, @"<style>
    .marker {
        background-image: url(""data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 19 19' height='19' width='19'%3E%3Ctitle%3Epitch-15.svg%3C/title%3E%3Crect fill='none' x='0' y='0' width='19' height='19'%3E%3C/rect%3E%3Cpath fill='%23000' transform='translate(2 2)' d='M5,3C4.4477,3,4,2.5523,4,2s0.4477-1,1-1s1,0.4477,1,1S5.5523,3,5,3z M12.5,10H10L9,7L8,5.25L9,5l2.3,1l0,0 c0.2761,0.1105,0.5895-0.0239,0.7-0.3S11.9761,5.1105,11.7,5l0,0L9,4H7L5,5L4,6H2.5C2.2239,6,2,6.2239,2,6.5S2.2239,7,2.5,7H5l1-1 l1,2l-2,2v3.5C5,13.7761,5.2239,14,5.5,14S6,13.7761,6,13.5v-3.11L8,9l1,2h3.5c0.2761,0,0.5-0.2239,0.5-0.5S12.7761,10,12.5,10z'%3E%3C/path%3E%3C/svg%3E"");
        background-size: cover;
        width: 50px;
        height: 50px;
        border-radius: 50%;
        cursor: pointer;
    }
</style>

");
            __builder.AddMarkupContent(2, "<h3>VirtualMap</h3>");
#nullable restore
#line 26 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
 if (virtualWalk.Equals(null))
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(3, "<p>Loading...</p>");
#nullable restore
#line 29 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "<br>\r\n    <br>\r\n    <br>\r\n    ");
            __builder.OpenElement(5, "p");
            __builder.AddAttribute(6, "id", "demo");
            __builder.AddContent(7, "  test  ");
            __builder.AddContent(8, 
#nullable restore
#line 35 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
                          err

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n    <br>\r\n    <br>\r\n    <br>\r\n    ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "id", "map");
            __builder.AddAttribute(12, "style", "position:fixed; width: 50%; height: 50%;");
            __builder.AddElementReferenceCapture(13, (__value) => {
#nullable restore
#line 39 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
               mapElement = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
#nullable restore
#line 40 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Pages\VirtualMap.razor"
 
    public People people { get; set; } = new People();
    public VirtualWalk virtualWalk { get; set; } = new VirtualWalk();
    string WalkName = "Welsh Coastal Walk";

    ElementReference mapElement;
    IJSObjectReference mapModule, mapInstance;
    string err = "";

    CalculatePersonsPosition calculatePerson = new CalculatePersonsPosition();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {

            mapModule = await jsRunTime.InvokeAsync<IJSObjectReference>(
               "import", "./scripts/MapBox.js").AsTask();
            mapInstance = await mapModule.InvokeAsync<IJSObjectReference>(
                "initialize", mapElement).AsTask();

            StateHasChanged();
        }

        if (virtualWalk != null && mapModule != null)
        {
            await UpdatePersonLocation();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        people = await PeopleService.GetPeople();
        virtualWalk = await WalkService.GetVirtualWalk(WalkName, people.PeopleId);
    }

    async Task UpdatePersonLocation()
    {
        if (virtualWalk.TotalSteps >= 0)
        {
            try
            {
                await mapModule.InvokeVoidAsync("updatePersonIcon", calculatePerson.NewPosition(virtualWalk.TotalSteps));

            }
            catch (Exception e)
            {

                err = e.Message.ToString();
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRunTime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPeopleService PeopleService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IVirtualWalkService WalkService { get; set; }
    }
}
#pragma warning restore 1591
