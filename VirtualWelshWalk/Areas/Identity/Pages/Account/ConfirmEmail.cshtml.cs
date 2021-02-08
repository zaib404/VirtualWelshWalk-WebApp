using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailService;
using EmailTemplate.Services;
using EmailTemplate.Views.Emails.ConfirmAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IEmailSender _emailSender;

        public ConfirmEmailModel(UserManager<User> userManager,
            IRazorViewToStringRenderer razorViewToStringRenderer,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _emailSender = emailSender;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public bool TokenValid { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string Email { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";

            if (result.Succeeded)
            {
                TokenValid = true;
            }
            else
            {
                TokenValid = false;
                Email = user.Email;
                TempData.Keep("Email");
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

            return RedirectToPage("RegisterConfirmation", new { Email, returnUrl = ReturnUrl });

        }
    }
}
