using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using VirtualWelshWalk.DataAccess.CRUD;
using VirtualWelshWalk.DataAccess.Models;
using EmailService;
using IEmailSender = EmailService.IEmailSender;
using EmailTemplate.Services;
using EmailTemplate.Views.Emails.ConfirmAccount;
using EmailTemplate.Views.Emails;
using System.Globalization;

namespace VirtualWelshWalk.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        // New
        readonly IPeopleRepository _peopleRepository;
        readonly IVirtualWalkRepository _virtualWalkRepository;
        readonly IMilestoneRepository _milestoneRepository;

        IRazorViewToStringRenderer _razorViewToStringRenderer;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IPeopleRepository peopleRepository,
            IVirtualWalkRepository virtualWalkRepository,
            IMilestoneRepository milestoneRepository,
            IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;

            _peopleRepository = peopleRepository;
            _virtualWalkRepository = virtualWalkRepository;
            _milestoneRepository = milestoneRepository;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(50, ErrorMessage = "Sorry you have exceed the limit of characters allowed, please shorten it to 50 or less")]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "Sorry you have exceed the limit of characters allowed, please shorten it to 50 or less")]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "Sorry you have exceed the limit of characters allowed, please shorten it to 50 or less")]
            [DataType(DataType.Text)]
            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [StringLength(50, ErrorMessage = "Sorry you have exceed the limit of characters allowed, please shorten it to 50 or less")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                IFormatProvider culture = new CultureInfo("en-US", true);

                var user = new User
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.UserName,
                    Email = Input.Email,
                    LastLoginDate = DateTime.ParseExact(DateTime.Today.ToString(), "yyyy-MM-dd", culture)
                };

                var People = new People
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.UserName
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var resultPeople = await _peopleRepository.AddPeople(People);

                    var VWalk = new VirtualWalk
                    {
                        VirtualWalkName = "Welsh Coastal Walk",
                        TotalSteps = 0,
                        PeopleId = resultPeople.PeopleId
                    };

                    var resultVWalk = await _virtualWalkRepository.AddVirtualWalk(VWalk);

                    var virtualMilestone = new VirtualMilestone
                    {
                        VirtualWalkName = VWalk.VirtualWalkName,
                        PeopleId = resultPeople.PeopleId
                    };

                    var resultMilestone = await _milestoneRepository.AddVirtualMilestones(virtualMilestone);


                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    var confirmAccountModel = new ConfirmAccountEmailViewModel(callbackUrl);

                    string body = await _razorViewToStringRenderer.RenderViewToStringAsync(@"\Views\Emails\ConfirmAccount\ConfirmAccount.cshtml", confirmAccountModel);

                    var message = new Message(new string[] { Input.Email }, "Confirm your email", body, null);

                    await _emailSender.SendEmailAsync(message);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount || !_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}

                if (result.Errors.Count() != 0)
                {
                    ModelState.AddModelError(string.Empty, "The User name or Email address appears to be taken.");
                }


            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
