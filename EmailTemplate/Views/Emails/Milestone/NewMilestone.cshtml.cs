using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailTemplate.Views.Emails.Milestone
{
    public class NewMilestoneModel : PageModel
    {
        public string UserName { get; set; }

        public double Miles { get; set; }

        public int Steps { get; set; }

        public string TownNameEnglish { get; set; }

        public string TownNameWelsh { get; set; }

        public string HistoricalPlaceNameEnglish { get; set; }

        public string HistoricalPlaceNameWelsh { get; set; }

        public string TownInfoEnglish { get; set; }

        public string TownInfoWelsh { get; set; }

        public string Image { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<string> OpeningTimes { get; set; }

        public string WebsiteLink { get; set; }

        public List<string> Address { get; set; }

        /// <summary>
        /// When a user reaches a new milestone set up the email template for that milestone
        /// </summary>
        /// <param name="userName">Username of user</param>
        /// <param name="miles">How many miles have they walked currently</param>
        /// <param name="steps">How many steps take so far</param>
        /// <param name="townNameEnglish">The towns name in English</param>
        /// <param name="townNameWelsh">The towns name in Welsh</param>
        /// <param name="historicalPlaceNameEnglish">The historical place in English</param>
        /// <param name="historicalPlaceNameWelsh">The historical place in Welsh</param>
        /// <param name="townInfoEnglish">The historical information in English</param>
        /// <param name="townInfoWelsh">The historical information in Welsh</param>
        /// <param name="image">image File Name with location</param>
        /// <param name="tel">telephone Number</param>
        /// <param name="email">Email Address of place</param>
        /// <param name="openingTimes">opening times</param>
        /// <param name="websiteLink">HTML Link to website</param>
        /// <param name="address">Address to place</param>
        public NewMilestoneModel(string userName,
            double miles, int steps,
            string townNameEnglish, string townNameWelsh,
            string historicalPlaceNameEnglish, string historicalPlaceNameWelsh,
            string townInfoEnglish, string townInfoWelsh,
            string image, string tel, string email,
            List<string> openingTimes, string websiteLink, List<string> address)
        {
            UserName = userName;
            Miles = miles;
            Steps = steps;
            TownNameEnglish = townNameEnglish;
            TownNameWelsh = townNameWelsh;
            HistoricalPlaceNameEnglish = historicalPlaceNameEnglish;
            HistoricalPlaceNameWelsh = historicalPlaceNameWelsh;
            TownInfoEnglish = townInfoEnglish;
            TownInfoWelsh = townInfoWelsh;
            Image = image;
            Tel = tel;
            Email = email;
            OpeningTimes = openingTimes;
            WebsiteLink = websiteLink;
            Address = address;
        }
    }
}
