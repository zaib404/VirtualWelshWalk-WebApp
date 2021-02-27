using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VirtualWelshWalk.DataAccess.CRUD;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.Areas.Identity.Pages.Account.Manage
{
    public class DownloadPersonalDataModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<DownloadPersonalDataModel> _logger;

        // New
        readonly IPeopleRepository _peopleRepository;
        readonly IVirtualWalkRepository _virtualWalkRepository;
        readonly IMilestoneRepository _milestoneRepository;

        public DownloadPersonalDataModel(
            UserManager<User> userManager,
            ILogger<DownloadPersonalDataModel> logger,
            IPeopleRepository peopleRepository,
            IVirtualWalkRepository virtualWalkRepository,
            IMilestoneRepository milestoneRepository)
        {
            _userManager = userManager;
            _logger = logger;

            _peopleRepository = peopleRepository;
            _virtualWalkRepository = virtualWalkRepository;
            _milestoneRepository = milestoneRepository;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var people = await _peopleRepository.GetPeople(user.UserName);
            var virtualWalk = await _virtualWalkRepository.GetVirtualWalk(people.PeopleId, "Welsh Coastal Walk");
            var milestones = await _milestoneRepository.GetVirtualMilestones(people.PeopleId, "Welsh Coastal Walk");

            _logger.LogInformation("User with ID '{UserId}' asked for their personal data.", _userManager.GetUserId(User));

            // Only include personal data for download
            var personalData = new Dictionary<string, string>();

            var personalDataProps = typeof(User).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));

            var personalDataWalk = typeof(VirtualWalk).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));

            var personalDataMilestone = typeof(VirtualMilestone).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));

            foreach (var p in personalDataProps)
            {
                personalData.Add(p.Name, p.GetValue(user)?.ToString() ?? "null");
            }

            foreach (var p in personalDataWalk)
            {
                personalData.Add(p.Name, p.GetValue(virtualWalk)?.ToString() ?? "null");
            }

            foreach (var p in personalDataMilestone)
            {
                personalData.Add(p.Name, p.GetValue(milestones)?.ToString() ?? "null");
            }

            var logins = await _userManager.GetLoginsAsync(user);
            foreach (var l in logins)
            {
                personalData.Add($"{l.LoginProvider} external login provider key", l.ProviderKey);
            }

            Response.Headers.Add("Content-Disposition", string.Format("attachment; filename={0}PersonalData.json", user.UserName));
            return new FileContentResult(JsonSerializer.SerializeToUtf8Bytes(personalData), "application/json");
        }
    }
}
