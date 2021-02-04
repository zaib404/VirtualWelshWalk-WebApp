// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 1 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
using DataAccess.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
using VirtualWelshWalk.DataAccess.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
using VirtualWelshWalk.DataAccess.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
using VirtualWelshWalk.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class InputStepsForm : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 105 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\VirtualWelshWalk\Shared\InputStepsForm.razor"
 
    [Parameter]
    public VirtualTotalSteps virtualSteps { get; set; }

    [Parameter]
    public People dbPeople { get; set; }

    [Parameter]
    public VirtualWalk dbVirtualWalk { get; set; }

    [Parameter]
    public VirtualMilestone dbMilestone { get; set; }

    [Parameter]
    public EventCallback<int> OnTotalStepsChanged { get; set; }

    [Parameter]
    public EventCallback OnVirtualMapSubmit { get; set; }

    [Parameter]
    public EventCallback<int> OnVirtualMapGetInfo { get; set; }

    [Parameter]
    public int MilestoneCounter { get; set; }

    CheckMilestone checkMilestone;

    bool ShowConfirmationModal = false;
    bool ShowNewMilestoneUnlocked = false;

    double virtualStepsInMiles = 0;

    string UserName;
    string EmailAddress;
    string Space = "";

    #region When first loading

    protected override void OnInitialized()
    {
        if (virtualSteps == null)
        {
            virtualSteps = new VirtualTotalSteps();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        checkMilestone = new CheckMilestone(dbMilestone, emailSender/*, UserManager, httpContent*/);

        try
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            UserName = authState.User.Identity.Name;


            IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

            _claims = user.Claims;

            EmailAddress = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

            //var user = await UserManager.GetUserAsync(httpContent.HttpContext.User);

            //checkMilestone.SetData(user.Email, user.UserName);

            checkMilestone.SetData(EmailAddress, UserName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    #endregion

    #region Submitting data/checking and calling parent methods

    async Task HandleValidSubmit()
    {
        ShowConfirmationModal = false;

        dbVirtualWalk.TotalSteps += virtualSteps.NewSteps;

        await WalkService.UpdateVirtualWalk(dbVirtualWalk);

        virtualSteps.NewSteps = 0;

        virtualSteps.TotalSteps = dbVirtualWalk.TotalSteps;

        ShowNewMilestoneUnlocked = checkMilestone.MilestoneCheckWithEmail(StepsInKM());
        //ShowNewMilestoneUnlocked = true;

        if (ShowNewMilestoneUnlocked)
        {
            await MilestoneService.UpdateVirtualMilestones(checkMilestone.dbMilestone);
        }
    }

    async Task HandleValidSubmitPart2()
    {
        if (OnTotalStepsChanged.HasDelegate)
        {
            await UpdateTotalStepsChanged();
        }

        if (OnVirtualMapSubmit.HasDelegate)
        {
            await VirtualMapModalSubmitChanged();
        }

        if (OnVirtualMapGetInfo.HasDelegate)
        {
            await VirtualMapGetInfoChanged();
        }

        ShowNewMilestoneUnlocked = false;
    }

    async Task UpdateMilestoneInformation()
    {
        await OnVirtualMapGetInfo.InvokeAsync(checkMilestone.CheckMilestoneCounter(StepsInKM()));
    }

    async Task UpdateTotalStepsChanged()
    {
        await OnTotalStepsChanged.InvokeAsync(virtualSteps.TotalSteps);
    }

    async Task VirtualMapModalSubmitChanged()
    {
        await OnVirtualMapSubmit.InvokeAsync();
    }

    async Task VirtualMapGetInfoChanged()
    {
        if (checkMilestone.Counter == 0)
        {
            virtualSteps.TotalSteps = dbVirtualWalk.TotalSteps;
            await OnVirtualMapGetInfo.InvokeAsync(checkMilestone.CheckMilestoneCounter(StepsInKM()));
        }
        else
        {
            await OnVirtualMapGetInfo.InvokeAsync(checkMilestone.Counter);
        }

    }

    public async Task<int> CallVirtualMapGetInfoChanged(int pSteps)
    {
        if (virtualSteps == null)
        {
            virtualSteps = new VirtualTotalSteps();
        }

        virtualSteps.TotalSteps = pSteps;

        if (checkMilestone == null)
        {
            checkMilestone = new CheckMilestone();
        }

        var milestoneNum = checkMilestone.CheckMilestoneCounter(StepsInKM());

        if (virtualSteps.TotalSteps == 0)
        {
            if (checkMilestone.SendEmailCheck(milestoneNum))
            {
                await MilestoneService.UpdateVirtualMilestones(dbMilestone);
            }
        }

        return milestoneNum;
    }

    #endregion

    #region Misc

    double StepsInKM()
    {
        // Convert to kilometers
        double km = Math.Round(virtualSteps.TotalSteps / 1312.33595801, 2);


        // Convert to miles
        return virtualStepsInMiles = Math.Round(km * 0.62137, 1);
    }

    public void Dispose()
    {
        //UserManager.Dispose();
    }

    #endregion

    public void SetUpFromVirtualMap(IVirtualMilestonesService milestonesService,
        VirtualMilestone pDbMilestone, EmailService.IEmailSender pEmailSender,
        string pEmailAddress, string pUserName)
    {
        checkMilestone = new CheckMilestone(pDbMilestone, pEmailSender);
        checkMilestone.SetData(pEmailAddress, pUserName);

        dbMilestone = pDbMilestone;
        MilestoneService = milestonesService;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private EmailService.IEmailSender emailSender { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IVirtualMilestonesService MilestoneService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPeopleService PeopleService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IVirtualWalkService WalkService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<App> Localizer { get; set; }
    }
}
#pragma warning restore 1591
