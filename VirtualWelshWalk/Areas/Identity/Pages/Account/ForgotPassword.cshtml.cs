﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using VirtualWelshWalk.DataAccess.Models;
using EmailService;
using IEmailSender = EmailService.IEmailSender;
using EmailTemplate.Services;
using EmailTemplate.Views.Emails.ForgotPassword;

namespace VirtualWelshWalk.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;

        IRazorViewToStringRenderer _razorViewToStringRenderer;
        public ForgotPasswordModel(UserManager<User> userManager, IEmailSender emailSender, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public bool DisplayMessage { get; set; } = false;

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    //return RedirectToPage("./ForgotPasswordConfirmation");
                    DisplayMessage = true;
                    return Page();
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);

                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                var confirmAccountModel = new ForgotPasswordEmailViewModel(callbackUrl, user.FirstName + " " + user.LastName);

                string body = await _razorViewToStringRenderer.RenderViewToStringAsync(@"\Views\Emails\ForgotPassword\ForgotPassword.cshtml", confirmAccountModel);

                var message = new Message(new string[] { Input.Email }, "Forgot your password", body);

                await _emailSender.SendEmailAsync(message);

                //return RedirectToPage("./ForgotPasswordConfirmation");
                DisplayMessage = true;
                return Page();
            }

            return Page();
        }
    }
}
