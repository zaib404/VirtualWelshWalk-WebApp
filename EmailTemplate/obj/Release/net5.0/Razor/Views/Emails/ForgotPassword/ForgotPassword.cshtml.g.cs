#pragma checksum "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\EmailTemplate\Views\Emails\ForgotPassword\ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f579be71ff19c0b256bdb815ef473c588af957ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Emails_ForgotPassword_ForgotPassword), @"mvc.1.0.view", @"/Views/Emails/ForgotPassword/ForgotPassword.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\EmailTemplate\Views\Emails\ForgotPassword\ForgotPassword.cshtml"
using EmailTemplate.Views.Emails.ForgotPassword;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\EmailTemplate\Views\Emails\ForgotPassword\ForgotPassword.cshtml"
using EmailTemplate.Views.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f579be71ff19c0b256bdb815ef473c588af957ce", @"/Views/Emails/ForgotPassword/ForgotPassword.cshtml")]
    public class Views_Emails_ForgotPassword_ForgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ForgotPasswordEmailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\EmailTemplate\Views\Emails\ForgotPassword\ForgotPassword.cshtml"
  
    ViewData["EmailTitle"] = "Reset your password";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<hr />\r\n\r\n<p class=font-weight-bold>\r\n    Hello ");
#nullable restore
#line 14 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\EmailTemplate\Views\Emails\ForgotPassword\ForgotPassword.cshtml"
     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
</p>

<p>
    You told us that you forgot the password for your Walking Wales account. Use the button below to reset it. 
    <a style=""font-weight:bold"">
    This link is only valid for one hour.
    After that, you'll have to ask for a new one.
    </a>
</p>

<br />

");
#nullable restore
#line 27 "D:\Zaib\Documents\Areca Design\VirtualWelshWalk\EmailTemplate\Views\Emails\ForgotPassword\ForgotPassword.cshtml"
Write(await Html.PartialAsync("EmailButton", new EmailButtonViewModel("Reset your password", Model.ConfirmEmailUrl)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p>If you did not request a password reset, please ignore this email or, you can change your password by logging in to your account.</p>\r\n<br />\r\n\r\n<br />\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ForgotPasswordEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591