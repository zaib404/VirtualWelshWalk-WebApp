using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using EmailService;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using EmailTemplate.Views.Emails.Milestone;
using EmailTemplate.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class CheckMilestone
    {
        public VirtualMilestone dbMilestone { get; set; }

        private readonly IEmailSender emailSender;
        
        IRazorViewToStringRenderer _razorViewToStringRenderer;

        readonly AuthenticationStateProvider authenticationStateProvider;

        private string email { get; set; }
        private string userName { get; set; }

        bool EmailSent = false;

        public int Counter { get; set; } = 0;

        public CheckMilestone(VirtualMilestone dbMilestone, IEmailSender pEmailSender, IRazorViewToStringRenderer pRazorViewToStringRenderer, AuthenticationStateProvider pAuthenticationStateProvider)
        {
            this.dbMilestone = dbMilestone;
            emailSender = pEmailSender;
            _razorViewToStringRenderer = pRazorViewToStringRenderer;
            authenticationStateProvider = pAuthenticationStateProvider;

            SetData().Wait();
        }

        public CheckMilestone()
        {
        }

        //public void SetData(string pEmail, string pUsername)
        //{
        //    email = pEmail;
        //    userName = pUsername;
        //}

        async Task SetData()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            userName = user.Identity.Name;

            IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

            _claims = user.Claims;

            email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
        }

        public bool MilestoneCheckWithEmail(double virtualStepsInMiles)
        {
            return Check(virtualStepsInMiles);
        }

        bool Check(double stepInMiles)
        {
            int landMarksPassed = PassLandMarkCounter(stepInMiles);

            return SendEmailCheck(landMarksPassed - 1);

        }

        public int CheckMilestoneCounter(double stepInMiles)
        {
            int landMarksPassed = PassLandMarkCounter(stepInMiles);

            Counter = landMarksPassed - 1;

            return Counter;

        }

        public bool SendEmailCheck(int passedLandmarks)
        {
            #region Sending email checks if they have passed multiple landmarks

            List<Message> messages = new List<Message>();
            string RenderViewString = @"\Views\Emails\Milestone\NewMilestone.cshtml";

            if (passedLandmarks >= 0 && !dbMilestone.Milestone1)
            {
                Counter = 1;

                var MilestoneModel = new NewMilestoneModel("Tintern Abbey", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Tintern Abbey", body, new List<string>() { @"EmailAttachments\Tintern Abbey.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone1 = true;
            }
            if (passedLandmarks >= 1 && !dbMilestone.Milestone2)
            {
                Counter = 2;

                var MilestoneModel = new NewMilestoneModel("Transporter Bridge", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Transporter Bridge", body, new List<string>() { @"EmailAttachments\Transporter Bridge.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone2 = true;
            }
            if (passedLandmarks >= 2 && !dbMilestone.Milestone3)
            {
                Counter = 3;

                var MilestoneModel = new NewMilestoneModel("Cardiff Castle", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Cardiff Castle", body, new List<string>() { @"EmailAttachments\Cardiff Castle.pdf" }));
                
                EmailSent = true;
                dbMilestone.Milestone3 = true;
            }
            if (passedLandmarks >= 3 && !dbMilestone.Milestone4)
            {
                Counter = 4;

                var MilestoneModel = new NewMilestoneModel("Rest Bay Beach", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Rest Bay Beach", body, new List<string>() { @"EmailAttachments\Rest Bay Beach.pdf" }));
                EmailSent = true;
                dbMilestone.Milestone4 = true;
            }
            if (passedLandmarks >= 4 && !dbMilestone.Milestone5)
            {
                Counter = 5;
                
                var MilestoneModel = new NewMilestoneModel("Mumbles Pier", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Mumbles Pier", body, new List<string>() { @"EmailAttachments\Mumbles Pier.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone5 = true;
            }
            if (passedLandmarks >= 5 && !dbMilestone.Milestone6)
            {
                Counter = 6;
                
                var MilestoneModel = new NewMilestoneModel("Fall Bay", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Fall Bay", body, new List<string>() { @"EmailAttachments\Fall Bay.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone6 = true;
            }
            if (passedLandmarks >= 6 && !dbMilestone.Milestone7)
            {
                Counter = 7;

                var MilestoneModel = new NewMilestoneModel("Parc y Scarlets", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Parc y Scarlets", body, new List<string>() { @"EmailAttachments\Parc y Scarlets.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone7 = true;
            }
            if (passedLandmarks >= 7 && !dbMilestone.Milestone8)
            {
                Counter = 8;

                var MilestoneModel = new NewMilestoneModel("Kidwelly Castel", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Kidwelly Castel", body, new List<string>() { @"EmailAttachments\Kidwelly Castle.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone8 = true;
            }
            if (passedLandmarks >= 8 && !dbMilestone.Milestone9)
            {
                Counter = 9;

                var MilestoneModel = new NewMilestoneModel("St. Catherines Island", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from St. Catherines Island", body, new List<string>() { @"EmailAttachments\St. Catherines Island.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone9 = true;
            }
            if (passedLandmarks >= 9 && !dbMilestone.Milestone10)
            {
                Counter = 10;

                var MilestoneModel = new NewMilestoneModel("Barafundle Bay", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Barafundle Bay", body, new List<string>() { @"EmailAttachments\Barafundle Bay.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone10 = true;
            }
            if (passedLandmarks >= 10 && !dbMilestone.Milestone11)
            {
                Counter = 11;

                var MilestoneModel = new NewMilestoneModel("Stack Rock Fort", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Stack Rock Fort", body, new List<string>() { @"EmailAttachments\Stack Rock Fort.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone11 = true;
            }
            if (passedLandmarks >= 11 && !dbMilestone.Milestone12)
            {
                Counter = 12;

                var MilestoneModel = new NewMilestoneModel("St. Davids Cathedral", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from St. Davids Cathedral", body, new List<string>() { @"EmailAttachments\St. Davids Cathedral.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone12 = true;
            }
            if (passedLandmarks >= 12 && !dbMilestone.Milestone13)
            {
                Counter = 13;

                var MilestoneModel = new NewMilestoneModel("Strumble Head Lighthouse", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Strumble Head Lighthouse", body, new List<string>() { @"EmailAttachments\Strumble Head Lighthouse.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone13 = true;
            }
            if (passedLandmarks >= 13 && !dbMilestone.Milestone14)
            {
                Counter = 14;

                var MilestoneModel = new NewMilestoneModel("Cardigan Castle", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Cardigan Castle", body, new List<string>() { @"EmailAttachments\Cardigan Castle.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone14 = true;
            }
            if (passedLandmarks >= 14 && !dbMilestone.Milestone15)
            {
                Counter = 15;

                var MilestoneModel = new NewMilestoneModel("Plas Tan y Bwlch", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Plas Tan y Bwlch", body, new List<string>() { @"EmailAttachments\Plas Tan y Bwlch.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone15 = true;
            }
            if (passedLandmarks >= 15 && !dbMilestone.Milestone16)
            {
                Counter = 16;

                var MilestoneModel = new NewMilestoneModel("Round House", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Round House", body, new List<string>() { @"EmailAttachments\Round House.pdf" }));

                EmailSent = true;

                dbMilestone.Milestone16 = true;
            }
            if (passedLandmarks >= 16 && !dbMilestone.Milestone17)
            {
                Counter = 17;

                var MilestoneModel = new NewMilestoneModel("Harlech Castle", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Harlech Castle", body, new List<string>() { @"EmailAttachments\Harlech Castle.pdf" }));

                EmailSent = true;

                dbMilestone.Milestone17 = true;
            }
            if (passedLandmarks >= 17 && !dbMilestone.Milestone18)
            {
                Counter = 18;

                var MilestoneModel = new NewMilestoneModel("Nant Gwrtheyrn", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Nant Gwrtheyrn", body, new List<string>() { @"EmailAttachments\Nant Gwrtheyrn.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone18 = true;
            }
            if (passedLandmarks >= 18 && !dbMilestone.Milestone19)
            {
                Counter = 19;

                var MilestoneModel = new NewMilestoneModel("Bedd Gelert", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Bedd Gelert", body, new List<string>() { @"EmailAttachments\Bedd Gelert.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone19 = true;
            }
            if (passedLandmarks >= 19 && !dbMilestone.Milestone20)
            {
                Counter = 20;

                var MilestoneModel = new NewMilestoneModel("Caernarfon Castle", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Caernarfon Castle", body, new List<string>() { @"EmailAttachments\Caernarfon Castle.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone20 = true;
            }
            if (passedLandmarks >= 20 && !dbMilestone.Milestone21)
            {
                Counter = 21;

                var MilestoneModel = new NewMilestoneModel("Beaumaris Castle", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Beaumaris Castle", body, new List<string>() { @"EmailAttachments\Beaumaris Castle.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone21 = true;
            }
            if (passedLandmarks >= 21 && !dbMilestone.Milestone22)
            {
                Counter = 22;

                var MilestoneModel = new NewMilestoneModel("Conwy Castle", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from Conwy Castle", body, new List<string>() { @"EmailAttachments\Conwy Castle.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone22 = true;
            }
            if (passedLandmarks >= 22 && !dbMilestone.Milestone23)
            {
                Counter = 23;

                var MilestoneModel = new NewMilestoneModel("City Walls", userName);
                string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                messages.Add(new Message(new string[] { email }, "Postcard from City Walls", body, new List<string>() { @"EmailAttachments\City Walls.pdf" }));

                EmailSent = true;
                dbMilestone.Milestone23 = true;
            }

            #endregion

            Counter = passedLandmarks;

            if (EmailSent == true)
            {
                _ = SendEmails(messages);
            }

            return EmailSent;
        }

        async Task SendEmails(List<Message> messages)
        {
            foreach (var message in messages)
            {
                await emailSender.SendEmailAsync(message);
            }            
        }

        int PassLandMarkCounter(double stepInMiles)
        {
            int landMarksPassed = 0;

            #region If statement to check if they have passed a certain landmark
            // First Milestone Tintern Abbey
            if (stepInMiles >= 0 && stepInMiles <= 18.8)
            {
                landMarksPassed = 1;
            }
            // Transporter bridge
            else if (stepInMiles >= 18.9 && stepInMiles <= 30.3)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 2;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // Cardiff castle
            else if (stepInMiles >= 30.4 && stepInMiles <= 56.1)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 3;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // rest bay beach
            else if (stepInMiles >= 56.2 && stepInMiles <= 80)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 4;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // mumbles pier
            else if (stepInMiles >= 80.1 && stepInMiles <= 95.6)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 5;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // fall bay
            else if (stepInMiles >= 95.7 && stepInMiles <= 114.5)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 6;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // parc y scarlets
            else if (stepInMiles >= 114.6 && stepInMiles <= 124.4)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 7;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // kidwelly castel
            else if (stepInMiles >= 124.5 && stepInMiles <= 152.8)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 8;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // st catherines island
            else if (stepInMiles >= 152.9 && stepInMiles <= 165.8)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 9;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // barafundle bay
            else if (stepInMiles >= 165.9 && stepInMiles <= 179.7)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 10;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // stack rock fort
            else if (stepInMiles >= 179.8 && stepInMiles <= 211.2)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 11;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // st davids catherdral
            else if (stepInMiles >= 211.3 && stepInMiles <= 227.4)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 12;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // strumble head lighthouse
            else if (stepInMiles >= 227.5 && stepInMiles <= 249.9)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 13;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // cardigan castle
            else if (stepInMiles >= 250 && stepInMiles <= 287.8)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 14;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // plas tan y bwlch
            else if (stepInMiles >= 287.9 && stepInMiles <= 327.2)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 15;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            //round house 
            else if (stepInMiles >= 327.3 && stepInMiles <= 337.9)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 16;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // harlech castle
            else if (stepInMiles >= 338 && stepInMiles <= 365.7)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 17;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // nant gwrtheyrn
            else if (stepInMiles >= 365.8 && stepInMiles <= 387.2)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 18;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // bedd gelert
            else if (stepInMiles >= 387.3 && stepInMiles <= 400.1)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 19;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // caernarfon castle
            else if (stepInMiles >= 400.2 && stepInMiles <= 412.7)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 20;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // beaumaris castle 
            else if (stepInMiles >= 412.6 && stepInMiles <= 433)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 21;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // conwy castle
            else if (stepInMiles >= 433.1 && stepInMiles <= 476)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 22;
                }
                else
                {
                    landMarksPassed++;
                }
            }
            // city walls
            else if (stepInMiles >= 476.3)
            {
                if (landMarksPassed == 0)
                {
                    landMarksPassed = 23;
                }
                else
                {
                    landMarksPassed++;
                }
            }

            #endregion

            return landMarksPassed;
        }
    }
}
