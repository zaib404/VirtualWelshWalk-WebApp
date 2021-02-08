using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using VirtualWelshWalk.DataAccess.Models;
using EmailService;
using IEmailSender = EmailService.IEmailSender;
using EmailTemplate.Views.Emails.ConfirmAccount;
using EmailTemplate.Services;

namespace VirtualWelshWalk.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IEmailSender _emailSender;

        public RegisterConfirmationModel(UserManager<User> userManager,
            IRazorViewToStringRenderer razorViewToStringRenderer,
            IEmailSender emailSender)
        {
            _userManager = userManager;

            _razorViewToStringRenderer = razorViewToStringRenderer;
            _emailSender = emailSender;
        }

        [TempData]
        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            TempData.Keep("Email");
            
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            DisplayConfirmAccountLink = false;
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var email = TempData.Peek("Email").ToString();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);

            var confirmAccountModel = new ConfirmAccountEmailViewModel(callbackUrl);

            string body = await _razorViewToStringRenderer.RenderViewToStringAsync(@"\Views\Emails\ConfirmAccount\ConfirmAccount.cshtml", confirmAccountModel);

            var message = new Message(new string[] { email }, "Confirm your email", body, null);

            await _emailSender.SendEmailAsync(message);

            return RedirectToPage("RegisterConfirmation", new { email, returnUrl = returnUrl });
        }
    }
}
