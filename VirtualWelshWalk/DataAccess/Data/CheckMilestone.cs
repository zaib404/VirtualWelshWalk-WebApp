﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using EmailService;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class CheckMilestone
    {
        public VirtualMilestone dbMilestone { get; set; }

        private readonly IEmailSender emailSender;
        //private readonly UserManager<User> userManager;
        //private readonly IHttpContextAccessor httpContextAccessor;

        private string email { get; set; }
        private string userName { get; set; }

        bool EmailSent = false;

        public int Counter { get; set; } = 0;

        public CheckMilestone(VirtualMilestone dbMilestone, IEmailSender pEmailSender/*, UserManager<User> pUser, IHttpContextAccessor pContextAccessor*/)
        {
            this.dbMilestone = dbMilestone;
            emailSender = pEmailSender;
            //userManager = pUser;
            //httpContextAccessor = pContextAccessor;
        }

        public CheckMilestone()
        {

        }

        public void SetData(string pEmail, string pUsername)
        {
            //var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            email = pEmail;
            userName = pUsername;
        }

        public bool MilestoneCheck(double virtualStepsInMiles)
        {
            //// Retrieve the names of all the boolean properties of dbMilestone class which are true
            //int falseCounter = 0;
            //int totalBoolCounter = 0;

            //foreach (PropertyInfo propertyInfo in dbMilestone.GetType().GetProperties())
            //{
            //    if (propertyInfo.PropertyType == typeof(bool))
            //    {
            //        bool value = (bool)propertyInfo.GetValue(dbMilestone, null);

            //        if (!value)
            //        {
            //            //add propertyInfo to some result
            //            falseCounter++;
            //        }
            //        totalBoolCounter++;
            //    }
            //}

            return Check(virtualStepsInMiles);

        }

        bool Check(double stepInMiles)
        {
            int landMarksPassed = 0;

            #region If statement to check if they have passed a certain landmark
            // First Milestone Tintern Abbey
            if (stepInMiles >= 0 && stepInMiles <= 18.99)
            {
                landMarksPassed = 1;
            }
            // Transporter bridge
            else if (stepInMiles >= 18.99 && stepInMiles <= 30.49)
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
            else if (stepInMiles >= 30.49 && stepInMiles <= 56.29)
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
            else if (stepInMiles >= 56.29 && stepInMiles <= 80.19)
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
            else if (stepInMiles >= 80.19 && stepInMiles <= 95.79)
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
            else if (stepInMiles >= 95.79 && stepInMiles <= 114.69)
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
            else if (stepInMiles >= 114.69 && stepInMiles <= 124.59)
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
            else if (stepInMiles >= 124.59 && stepInMiles <= 152.99)
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
            else if (stepInMiles >= 152.99 && stepInMiles <= 165.9)
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
            else if (stepInMiles >= 165.9 && stepInMiles <= 179.89)
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
            else if (stepInMiles >= 179.89 && stepInMiles <= 211.39)
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
            else if (stepInMiles >= 211.39 && stepInMiles <= 227.59)
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
            else if (stepInMiles >= 227.59 && stepInMiles <= 250.9)
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
            else if (stepInMiles >= 250.9 && stepInMiles <= 287.99)
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
            else if (stepInMiles >= 287.99 && stepInMiles <= 327.39)
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
            else if (stepInMiles >= 327.39 && stepInMiles <= 338.29)
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
            else if (stepInMiles >= 338.29 && stepInMiles <= 365.89)
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
            else if (stepInMiles >= 365.89 && stepInMiles <= 387.39)
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
            else if (stepInMiles >= 387.39 && stepInMiles <= 400.29)
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
            else if (stepInMiles >= 400.29 && stepInMiles <= 412.69)
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
            else if (stepInMiles >= 412.69 && stepInMiles <= 433.69)
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
            else if (stepInMiles >= 433.69 && stepInMiles <= 477)
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
            else if (stepInMiles >= 477)
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

            return SendEmailCheck(landMarksPassed);

            //return EmailSent;

        }

        bool SendEmailCheck(int passedLandmarks)
        {
            #region Sending email checks if they have passed multiple landmarks

            if (passedLandmarks >= 1 && !dbMilestone.Milestone1)
            {
                Counter = 1;
                var message = new Message(new string[] { email }, "Postcard from Tintern Abbey:", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Welsh coastal walk .pdf" } );
                emailSender.SendEmailAsync(message);

                EmailSent = true;
                dbMilestone.Milestone1 = true;
            }
            if (passedLandmarks >= 2 && !dbMilestone.Milestone2)
            {
                Counter = 2;
                var message = new Message(new string[] { email }, "Postcard from Transporter Bridge:", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone2 = true;
            }
            if (passedLandmarks >= 3 && !dbMilestone.Milestone3)
            {
                Counter = 3;
                var message = new Message(new string[] { email }, "Postcard from Cardiff Castle:", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone3 = true;
            }
            if (passedLandmarks >= 4 && !dbMilestone.Milestone4)
            {
                Counter = 4;
                var message = new Message(new string[] { email }, "Postcard from Rest Bay Beach :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone4 = true;
            }
            if (passedLandmarks >= 5 && !dbMilestone.Milestone5)
            {
                Counter = 5;
                var message = new Message(new string[] { email }, "Postcard from Mumbles Pier  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone5 = true;
            }
            if (passedLandmarks >= 6 && !dbMilestone.Milestone6)
            {
                Counter = 6;
                var message = new Message(new string[] { email }, "Postcard from Fall Bay :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone6 = true;
            }
            if (passedLandmarks >= 7 && !dbMilestone.Milestone7)
            {
                Counter = 7;
                var message = new Message(new string[] { email }, "Postcard from Parc y Scarlets :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone7 = true;
            }
            if (passedLandmarks >= 8 && !dbMilestone.Milestone8)
            {
                Counter = 8;
                var message = new Message(new string[] { email }, "Postcard from Kidwelly Castel :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone8 = true;
            }
            if (passedLandmarks >= 9 && !dbMilestone.Milestone9)
            {
                Counter = 9;
                var message = new Message(new string[] { email }, "Postcard from St Catherines Island :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone9 = true;
            }
            if (passedLandmarks >= 10 && !dbMilestone.Milestone10)
            {
                Counter = 10;
                var message = new Message(new string[] { email }, "Postcard from Barafundle Bay  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone10 = true;
            }
            if (passedLandmarks >= 11 && !dbMilestone.Milestone11)
            {
                Counter = 11;
                var message = new Message(new string[] { email }, "Postcard from Stack Rock Fort  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone11 = true;
            }
            if (passedLandmarks >= 12 && !dbMilestone.Milestone12)
            {
                Counter = 12;
                var message = new Message(new string[] { email }, "Postcard from St Davids Cathedral :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone12 = true;
            }
            if (passedLandmarks >= 13 && !dbMilestone.Milestone13)
            {
                Counter = 13;
                var message = new Message(new string[] { email }, "Postcard from Strumble Head Lighthouse  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone13 = true;
            }
            if (passedLandmarks >= 14 && !dbMilestone.Milestone14)
            {
                Counter = 14;
                var message = new Message(new string[] { email }, "Postcard from Cardigan Castle :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone14 = true;
            }
            if (passedLandmarks >= 15 && !dbMilestone.Milestone15)
            {
                Counter = 15;
               var message = new Message(new string[] { email }, "Postcard from Plas Tan y Bwlch  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone15 = true;
            }
            if (passedLandmarks >= 16 && !dbMilestone.Milestone16)
            {
                Counter = 16;
                var message = new Message(new string[] { email }, "Postcard from Round House  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;

                dbMilestone.Milestone16 = true;
            }
            if (passedLandmarks >= 17 && !dbMilestone.Milestone17)
            {
                Counter = 17;
                var message = new Message(new string[] { email }, "Postcard from Harlech Castle  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;

                dbMilestone.Milestone17 = true;
            }
            if (passedLandmarks >= 18 && !dbMilestone.Milestone18)
            {
                Counter = 18;
                var message = new Message(new string[] { email }, "Postcard from Nant Gwrtheyrn :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone18 = true;
            }
            if (passedLandmarks >= 19 && !dbMilestone.Milestone19)
            {
                Counter = 19;
                var message = new Message(new string[] { email }, "Postcard from Bedd Gelert  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone19 = true;
            }
            if (passedLandmarks >= 20 && !dbMilestone.Milestone20)
            {
                Counter = 20;
                var message = new Message(new string[] { email }, "Postcard from Caernarfon Castle  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone20 = true;
            }
            if (passedLandmarks >= 21 && !dbMilestone.Milestone21)
            {
                Counter = 21;
                var message = new Message(new string[] { email }, "Postcard from Beaumaris Castle  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone21 = true;
            }
            if (passedLandmarks >= 22 && !dbMilestone.Milestone22)
            {
                Counter = 22;
                var message = new Message(new string[] { email }, "Postcard from Conwy Castle  :", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone22 = true;
            }
            if (passedLandmarks >= 23 && !dbMilestone.Milestone23)
            {
                Counter = 23;
                var message = new Message(new string[] { email }, "Postcard from City Walls:", "There isnt anything for me to say lmao", new List<string>() { @"EmailAttachments\Virtual Welsh Walk Wireframe V1.pdf" });
                emailSender.SendEmailAsync(message);
                EmailSent = true;
                dbMilestone.Milestone23 = true;
            }

            #endregion

            Counter = passedLandmarks;

            return EmailSent;
        }

        public int CheckMilestoneCounter(double stepInMiles)
        {
            int landMarksPassed = 0;

            #region If statement to check if they have passed a certain landmark
            // First Milestone Tintern Abbey
            if (stepInMiles >= 0 && stepInMiles <= 18.99)
            {
                landMarksPassed = 1;
            }
            // Transporter bridge
            else if (stepInMiles >= 18.99 && stepInMiles <= 30.49)
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
            else if (stepInMiles >= 30.49 && stepInMiles <= 56.29)
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
            else if (stepInMiles >= 56.29 && stepInMiles <= 80.19)
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
            else if (stepInMiles >= 80.19 && stepInMiles <= 95.79)
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
            else if (stepInMiles >= 95.79 && stepInMiles <= 114.69)
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
            else if (stepInMiles >= 114.69 && stepInMiles <= 124.59)
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
            else if (stepInMiles >= 124.59 && stepInMiles <= 152.99)
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
            else if (stepInMiles >= 152.99 && stepInMiles <= 165.9)
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
            else if (stepInMiles >= 165.9 && stepInMiles <= 179.89)
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
            else if (stepInMiles >= 179.89 && stepInMiles <= 211.39)
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
            else if (stepInMiles >= 211.39 && stepInMiles <= 227.59)
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
            else if (stepInMiles >= 227.59 && stepInMiles <= 250.9)
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
            else if (stepInMiles >= 250.9 && stepInMiles <= 287.99)
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
            else if (stepInMiles >= 287.99 && stepInMiles <= 327.39)
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
            else if (stepInMiles >= 327.39 && stepInMiles <= 338.29)
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
            else if (stepInMiles >= 338.29 && stepInMiles <= 365.89)
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
            else if (stepInMiles >= 365.89 && stepInMiles <= 387.39)
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
            else if (stepInMiles >= 387.39 && stepInMiles <= 400.29)
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
            else if (stepInMiles >= 400.29 && stepInMiles <= 412.69)
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
            else if (stepInMiles >= 412.69 && stepInMiles <= 433.69)
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
            else if (stepInMiles >= 433.69 && stepInMiles <= 477)
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
            else if (stepInMiles >= 477)
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

            Counter = landMarksPassed;

            return Counter;

        }
    }
}
