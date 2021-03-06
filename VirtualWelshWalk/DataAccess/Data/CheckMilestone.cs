using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;
using EmailService;
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

        double StepsInMiles { get; set; }
        int steps { get; set; }

        public CheckMilestone(VirtualMilestone dbMilestone, IEmailSender pEmailSender,
            IRazorViewToStringRenderer pRazorViewToStringRenderer,
            AuthenticationStateProvider pAuthenticationStateProvider)
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

        async Task SetData()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            userName = user.Identity.Name;

            IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

            _claims = user.Claims;

            email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
        }

        public bool MilestoneCheckWithEmail(double virtualStepsInMiles, int pSteps)
        {
            StepsInMiles = virtualStepsInMiles;
            steps = pSteps;
            return Check(virtualStepsInMiles);
        }

        bool Check(double stepInMiles)
        {
            int landMarksPassed = PassLandMarkCounter(stepInMiles);

            return SendEmailCheck(landMarksPassed - 1);
        }

        public int CheckMilestoneCounter(double stepInMiles, int pSteps)
        {
            StepsInMiles = stepInMiles;
            steps = pSteps;

            int landMarksPassed = PassLandMarkCounter(stepInMiles);

            Counter = landMarksPassed - 1;

            return Counter;

        }

        public bool SendEmailCheck(int passedLandmarks)
        {
            #region Sending email checks if they have passed multiple landmarks

            List<Message> messages = new List<Message>();
            string RenderViewString = @"\Views\Emails\Milestone\NewMilestone.cshtml";

            string townNameEnglish;
            string townNameWelsh;
            string historicalPlaceNameEnglish;
            string historicalPlaceNameWelsh;
            string townInfoEnglish;
            string townInfoWelsh;
            string image;
            string tel;
            string historicalPlaceEmail;
            List<string> openingTimes;
            string websiteLink;
            List<string> address;

            string emailSubject = "Cerdyn post o {0}, {1} | Postcard from {2}, {3}";

            if (dbMilestone.VirtualWalkName != null)
            {
                if (passedLandmarks >= 0 && !dbMilestone.Milestone1)
                {
                    Counter = 1;

                    townNameEnglish = "Chepstow";
                    townNameWelsh = "Cas-gwent";
                    historicalPlaceNameEnglish = "Tintern Abbey";
                    historicalPlaceNameWelsh = "Tintern Abbey";

                    townInfoEnglish = "Tintern Abbey was founded on 9 May 1131 by Walter de Clare, Lord of Chepstow. " +
                        "It is situated adjacent to the village of Tintern in Monmouthshire, on the Welsh bank of the River Wye, " +
                        "which at this location forms the border between Monmouthshire in Wales and Gloucestershire in England.";

                    townInfoWelsh = "Sefydlwyd Tintern Abbey ar Mai y 9fed 1131 gan Walter de Clare, arglwydd Cas-gwent. " +
                        "Mae wedi ei leoli ger pentref Tintern yn Sir Fynwy, ar lan yr Afon Wye, sydd yn y lleoliad hwn yn " +
                        "ffurfio’r ffin rhwng Sir Fynwy yng Nghymrua a Swydd Gaerloyw yn Lloegr.";

                    image = @"\Assets\Culture\Tintern Abbey.jpg";

                    tel = "01291 689251";

                    historicalPlaceEmail = "TinternAbbey@gov.wales";

                    websiteLink = "https://cadw.gov.wales/visit/places-to-visit/tintern-abbey";

                    address = new List<string> { "North on The A466,", "Tintern,", "NP16 6SE" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps,
                        townNameEnglish, townNameWelsh,
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh,
                        townInfoEnglish, townInfoWelsh,
                        image, tel, historicalPlaceEmail, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone1 = true;
                }
                if (passedLandmarks >= 1 && !dbMilestone.Milestone2)
                {
                    Counter = 2;

                    townNameEnglish = "Newport";
                    townNameWelsh = "Casnewydd";
                    historicalPlaceNameEnglish = "Transporter Bridge";
                    historicalPlaceNameWelsh = "Pont Gludo Casnewydd";

                    townInfoEnglish = "The Newport Transporter Bridge is a transporter bridge that crosses the River Usk in Newport, South East Wales. " +
                        "It is one of fewer than 10 transporter bridges that remain in use worldwide; only a few dozen were ever built. " +
                        "It is one of only two operational transporter bridges in Britain, the other being the Tees Transporter Bridge.";

                    townInfoWelsh = "Pont Gludo Casnewydd yw’r bont sy’n croesi Afon Usk yng Nghasnewydd, de-ddwyrain Cymru. " +
                        "Mae’n un o lain a 10 pont cludo sy’n parhau i gaele u ddefnyddio ledled y byd; dim ond ychydig ddwsin a adeiladwyd erioed.";

                    image = @"\Assets\Culture\Transporter Bridge.jpg";

                    openingTimes = new List<string> { "Mon – Fri: 7:15 – 12:00", "Sat: 9:30 – 12:00", "Sun: Closed" };

                    historicalPlaceEmail = "Transporter.bridge@newport.gov.uk";

                    websiteLink = "http://www.newport.gov.uk/heritage/en/Transporter-Bridge/Visit.aspx";

                    address = new List<string> { "Stephenson Street,", "Newport,", "NP20 2JG" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, null, 
                        historicalPlaceEmail, openingTimes, 
                        websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone2 = true;
                }
                if (passedLandmarks >= 2 && !dbMilestone.Milestone3)
                {
                    Counter = 3;

                    townNameEnglish = "Cardiff";
                    townNameWelsh = "Caerdydd";
                    historicalPlaceNameEnglish = "Cardiff Castle";
                    historicalPlaceNameWelsh = "Castell Caerdydd";

                    townInfoEnglish = "Cardiff Castle is located in the Castle Quarter, in the heart of Cardiff, the capital of Wales. " +
                        "There has been a fort on the site for almost 2,000 years. " +
                        "The current building was built in the late 11th century, replacing a Roman fort.";

                    townInfoWelsh = "Mae Castell Caerdydd wedi’i leoli yng nghanol Caerdydd, prifddinas Cymru. " +
                        "Bu caer ar y safle ers bron i 2,000 o flynyddoedd. " +
                        "Adeiladwyd yr adeilad bresennol ar ddiwedd yr 11eg ganrif, gan ddisodli caer Rufeining.";

                    image = @"\Assets\Culture\Cardiff Castle.jpg";

                    openingTimes = new List<string> { "Mon – Fri: 9:00 – 17:00" };

                    websiteLink = "https://www.cardiffcastle.com/times-prices/";

                    address = new List<string> { "Castle Street,", "Cardiff,", "CF10 3RB" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, null, null, openingTimes, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone3 = true;
                }
                if (passedLandmarks >= 3 && !dbMilestone.Milestone4)
                {
                    Counter = 4;

                    townNameEnglish = "Porthcawl";
                    townNameWelsh = "Porthcawl";
                    historicalPlaceNameEnglish = "Rest Bay Beach";
                    historicalPlaceNameWelsh = "Traeth Rest Bay";

                    townInfoEnglish = "Rest Bay is a golden, sandy beach on the outskirts of the town of Porthcawl, " +
                        "backed by The Royal Porthcawl Golf Club and low cliffs. The beach faces south-west, " +
                        "which means that it is not sheltered from the Atlantic winds and the waves here can be quite large, " +
                        "making it a good beach for surfing, as well as wind/kite surfing.";

                    townInfoWelsh = "Mae Traeth Rest Bay yn draeth euraidd, tywodlyd ar gyrion tref Porthcawl, " +
                        "gyda Chlwb Golf Brenhinol Porthcawl a chlogwyni isel yn gefn iddo. Mae’r traeth yn gwynebu de-orllewin, " +
                        "sy’n golygu nad yw’n cael ei gysgodi rhag y gwyntoedd atlantig a gall y tonnau yma fod yn eithaf mawr, " +
                        "gan ei wneud yn draeth da ar gyfer syrffio, yn ogystal â syrffio gwynt/barcud.";

                    image = @"\Assets\Culture\Rest bay Beach.jpg";

                    tel = "01656 815332";

                    historicalPlaceEmail = "tourism@bridgend.gov.uk";

                    websiteLink = "https://www.visitwales.com/attraction/beach/porthcawl-rest-bay-beach-1821303";

                    address = new List<string> { "Rest Bay Beach,", "Porthcawl,", "CF36 3UW" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone4 = true;
                }
                if (passedLandmarks >= 4 && !dbMilestone.Milestone5)
                {
                    Counter = 5;

                    townNameEnglish = "Swansea";
                    townNameWelsh = "Abertawe";
                    historicalPlaceNameEnglish = "Mumbles Pier";
                    historicalPlaceNameWelsh = "Pier y Mwmbwls";

                    townInfoEnglish = "The Mumbles Pier is one of only six surviving iron piers in Wales. " +
                        "Mumbles Pier was opened to the public on the 10th May 1898. A family run business " +
                        "‘The Pier’ is one of very few privately owned Piers left in the UK. " +
                        "Once a station for the world famous Mumbles Railway, the site is steeped in a rich history and " +
                        "continues to be a seaside tourist attraction for many families across the UK.";

                    townInfoWelsh = "Mae Pier y Mwmbwls yn un o ddim ond chwech phier haearn sydd wedi goroesi yng Nghymru. " +
                        "Agorwyd Pier y Mwmbwls i’r cyhoedd ar y 10fed o Fai 1898. Busnes teulu ‘Y Pier’ yw un o ychydig iawn o " +
                        "pier dan berchnogaeth preifat sydd ar ôl yn y DU. Unwaith yn orsfa ar gyfer y rheilffordd byd-enwog Rheilffordd " +
                        "Mwmbwls, mae gan y safle hanes gyfoethog ac yn parhau i fod yn atyniad twristiaeth glan môr i lawer o deulueodd ledled y DU.";

                    image = @"\Assets\Culture\Mumbles Pier.jpg";

                    address = new List<string> { "Mumbles Road,", "Swansea,", "SA3 4EN" };

                    tel = "01792 365200";

                    historicalPlaceEmail = "enquiries@mumbles-pier.co.uk";

                    websiteLink = "https://www.mumbles-pier.co.uk/";

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone5 = true;
                }
                if (passedLandmarks >= 5 && !dbMilestone.Milestone6)
                {
                    Counter = 6;

                    townNameEnglish = "Rhossili";
                    townNameWelsh = "Rhosili";
                    historicalPlaceNameEnglish = "Fall Bay";
                    historicalPlaceNameWelsh = "Fall Bay";

                    townInfoEnglish = "Fall bay is one of the hardest to reach bays on Gower, " +
                        "however the walk is well worth it and the beach is never crowded due to its remoteness. " +
                        "There is no beach visible at high tide. The beach is very popular with surfers. " +
                        "At very low tide, it is possible to walk over from the beach to Mewslade Bay.";

                    townInfoWelsh = "Fall Bay yw un o’r traethau anoddaf i’w gyrraedd ar Gower, ond mae’n werth " +
                        "chweil cerdded yno ac nid yw’r traeth byth yn orlawn oherwydd ei bellenigrwydd. " +
                        "Ni does traeth i’w weld ar lanw uchel. Mae’r traeth boblogaidd iawn gyda syrffwyr. " +
                        "Ar lawn isel iawn, mae’n bosib cerdded o’r traeth i Fae Mewslade.";

                    image = @"\Assets\Culture\Fall Bay.jpg";

                    address = new List<string> { "Fallbay Cottage Middleton,", "Rhossili,", "Swansea,", "SA3 1PL" };

                    websiteLink = "https://www.gowerholidays.com/things-to-do-see/beaches/fall-bay/";

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, null, null, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone6 = true;
                }
                if (passedLandmarks >= 6 && !dbMilestone.Milestone7)
                {
                    Counter = 7;

                    townNameEnglish = "Llanelli";
                    townNameWelsh = "Llanelli";
                    historicalPlaceNameEnglish = "Parc y Scarlets";
                    historicalPlaceNameWelsh = "Parc y Scarlets";

                    townInfoEnglish = "Parc y Scarlets is a rugby union stadium in Llanelli, Carmarthenshire, " +
                        "that opened in November 2008 as the new home of the Scarlets and Llanelli RFC. " +
                        "The ground replaced Stradey Park, the home of Llanelli's rugby teams for almost 130 years. " +
                        "The stadium complex includes facilities for matchday supporters and for non-matchday revenue generation, " +
                        "as well as a training barn and a training pitch with athletics track.";

                    townInfoWelsh = "Stadiwm undeb rygbi yw Parc y Scarlets, Sir Gaerfyrddin, " +
                        "â agorwyd ym mis Tachwedd 2008 fel cartref newydd Scarlets a Llanelli RFC. " +
                        "Parc y Strade, cartref tîm rygbi Llanelli am bron i 130 o flynyddoedd oedd y safle cyn " +
                        "i Parc y Scarlets ei ddisodli. Mae’r stadiwm yn cynnwys cyfleusterau ar gyfer cefnogwyr " +
                        "gemau a chynyrchu refeniw o ddigwyddiadau eraill, yn ogystal ag ysgubor hyfforddi a chae hyfforddi gyda thrac athletau.";

                    image = @"\Assets\Culture\Parc y Scarlets.jpg";

                    address = new List<string> { "Maes-Ar-Ddafen Road,", "Llanelli,", "SA14 9UZ" };

                    tel = "01554  783900";

                    historicalPlaceEmail = "info@parcyscarlets.com";

                    websiteLink = "https://www.parcyscarlets.com/";

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone7 = true;
                }
                if (passedLandmarks >= 7 && !dbMilestone.Milestone8)
                {
                    Counter = 8;

                    townNameEnglish = "Carmarthen";
                    townNameWelsh = "Caerfyrddin";
                    historicalPlaceNameEnglish = "Kidwelly Castle";
                    historicalPlaceNameWelsh = "Castell Cydweli";

                    townInfoEnglish = "Kidwelly Castle is a Norman castle overlooking the River Gwendraeth and the town of Kidwelly, Carmarthenshire, " +
                        "Wales. Origin of this surname trace back to when it was spelled Cygweli which means " + '\u0022' + "swan." + '\u0022' + "" +
                        " Later in its history, it was unsuccessfully besieged by forces of Owain Glyndŵr in 1403 with assistance from soldiers from " +
                        "France and Brittany who captured Kidwelly town. The castle was relieved by a Norman army after just three weeks.";

                    townInfoWelsh = "Castell Normanaidd yw Castell Cydweli, sy’n gorchwylio Afon Gwendraeth a thrêf Cydweli. Sir Gaerfyrddin, Cymru. " +
                        "Tarddiad olrhain y cyfenw yn ôl i pan gafodd ei sillafu Cygweli sy’n golygu " + '\u0022' + "alarch" + '\u0022' + "." +
                        " Hwyrach mewn hanes, cafodd ei gwarchae yn aflwyddiannus gan fyddin Owain Glyndŵr yn 1403 gyda chymorth milwyr o Ffrainc a Llydaw a " +
                        "gipiodd trêf Cydweli. Rhyddhawyd y castell gan fyddin Normanaidd ar ôl tair wythnos yn unig";

                    image = @"\Assets\Culture\Kidwelly Castle.jpg";

                    tel = "01554 890104";

                    historicalPlaceEmail = "KidwellyCastle@gov.wales";

                    websiteLink = "https://cadw.gov.wales/visit/places-to-visit/kidwelly-castle";

                    address = new List<string> { "Castle Road,", "Kidwelly,", "SA17 5BQ" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone8 = true;
                }
                if (passedLandmarks >= 8 && !dbMilestone.Milestone9)
                {
                    Counter = 9;

                    townNameEnglish = "Tenby";
                    townNameWelsh = "Dinbych-y-Pysgod";
                    historicalPlaceNameEnglish = "St. Catherine’s Island";
                    historicalPlaceNameWelsh = "Ynys Catrin";

                    townInfoEnglish = "St. Catherine’s Island is a small tidal island linked to Tenby in Pembrokeshire, Wales. " +
                        "2016 The Final Problem, the third and last episode of the fourth series of the BBC TV series Sherlock was filmed on the island, " +
                        "with it standing in as a maximum security prison. Formed from an outcrop of limestone, on average 25m high, the island is riddled with tidal caves.";

                    townInfoWelsh = "Ynys llanw fach yw Ynys Catrin, sy’n cysylltu â Dinbych-y-Pysgod yn Sir Benfro, Cymru. " +
                        "Ffilmiwyd ‘The Final Problem’, 2016, cyfres deledu BBC Sherlock, y drydydd bennod a’r olaf o’r bedwaredd gyfres ei " +
                        "ffilimio ar yr Ynys, gydag ef yn sefyll i mewn fel carchar. Mae’r Ynys llawn ogofâu llanw, a ffurfiwyd o brigiad o galchfaen ar gyfartaledd o 25m o uchder.";

                    image = @"\Assets\Culture\St Catherine’s Island.jpg";

                    address = new List<string> { "Castle Beach,", "Tenby,", "SA70 7BL" };

                    websiteLink = "https://saintcatherinesisland.co.uk/";

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, null, null, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone9 = true;
                }
                if (passedLandmarks >= 9 && !dbMilestone.Milestone10)
                {
                    Counter = 10;

                    townNameEnglish = "Pembrokeshire";
                    townNameWelsh = "Sir Benfro";
                    historicalPlaceNameEnglish = "Barafundle Bay";
                    historicalPlaceNameWelsh = "Bae Barafundle";

                    townInfoEnglish = "Barafundle Bay was named in Passport Magazine’s best beaches in the world. " +
                        "The remote sand patch came 17th in the top 25. Barafundle Bay is a remote, slightly curved, " +
                        "east-facing sandy beach in Pembrokeshire, Wales, near Stackpole Quay and is part of the Stackpole Estate, " +
                        "managed by The National Trust.";

                    townInfoWelsh = "Cafodd Bae Barafundle ei henwi fel un o traethau gorau’r byd yn ‘Passport Magazine’s’. " +
                        "Fe ddaeth Traeth Barafundle yn 17eg yn y 25 uchaf. Mae’n draeth anghysbell, weddol crwn, yn gwynebu’r " +
                        "dwyrain yn Sir Benfro, Cymru, ger Cei Ystangbwll ac yn rhan o ystâd Ystangbwll, a reolir gan Yr Ymddiriedolaeth Genedlaethol.";

                    image = @"\Assets\Culture\Barafundle Bay.jpg";

                    websiteLink = "https://www.visitpembrokeshire.com/explore-pembrokeshire/beaches/barafundle-bay";

                    address = new List<string> { "Stackpole Estate,", "Stackpole,", "SA71 5LS" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, null, null, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));

                    EmailSent = true;
                    dbMilestone.Milestone10 = true;
                }
                if (passedLandmarks >= 10 && !dbMilestone.Milestone11)
                {
                    Counter = 11;

                    townNameEnglish = "Milford Haven";
                    townNameWelsh = "Aberdaugleddau";
                    historicalPlaceNameEnglish = "Stack Rock Fort";
                    historicalPlaceNameWelsh = "Caer Stack Rock";

                    townInfoEnglish = "Stack Rock Fort is a fort built on a small island in the Milford Haven Waterway, " +
                        "Pembrokeshire. A 3-gun fort was built between 1850 and 1852, and then upgraded in 1859 with a new building that completely encased the original gun tower. " +
                        "The fort housed three 32-pounder guns, as well as a single 12-pounder for protection of the walls of the dock.";

                    townInfoWelsh = "Mae Caer Stack Rock yn gaer wedi’i hadeiladu ar ynys fach yn nghanol dyfrffordd Aberdaugleddau, Sir Benfro. " +
                        "Adeiladwyd caer â 3 gwn rhwng 1850 a 1852, yna bendwrfynon i adeilad newydd oedd yn gorchuddio’r twr gwn gwreiddiol yn 1859. " +
                        "Roedd y caer yn dal tri gwn 32 pwys, yn ogystal â gwn sengl 12 pwys ar gyfer amddiffyn y waliau’r doc.";

                    image = @"\Assets\Culture\Stack Rock Fort.jpg";

                    tel = "07964 177135";

                    historicalPlaceEmail = "info@stackrockfortCIC.com";

                    websiteLink = "https://stackrockfortcic.com/about-us-2/";

                    address = new List<string> { "Pembrokeshire Coast Path,", "Milford Haven,", "SA73 3RU" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone11 = true;
                }
                if (passedLandmarks >= 11 && !dbMilestone.Milestone12)
                {
                    Counter = 12;

                    townNameEnglish = "St. Davids";
                    townNameWelsh = "Tyddewi";
                    historicalPlaceNameEnglish = "St. Davids Cathedral";
                    historicalPlaceNameWelsh = "Eglwys Gadeiriol Tyddewi";

                    townInfoEnglish = "St. Davids Cathedral is situated in St. Davids in the county of Pembrokeshire, on the most westerly point of Wales. " +
                        "There are at least three services said or sung per day, each week, with sung services on five out of seven days. " +
                        "The cathedral choir at St. Davids was the first cathedral choir in the United Kingdom to use girls and men as the main choir, rather than boys and men.";

                    townInfoWelsh = "Mae Eglwys Dewi Sant wedi’i leoli yn Nhyddewi yn Sir Benfro, ar bwynt mwyaf gorllweinol Cymru. " +
                        "Mae o leiaf tri gwasanaeth yn cael eu adrodd neu ganu bob dydd, bob wythnos, gyda gwasanaethau canu mewn pump allan o saith diwrnod.";

                    image = @"\Assets\Culture\St Davids Cathedral.jpg";

                    tel = "01437 720202";

                    historicalPlaceEmail = "info@stdavidscathedral.org.uk";

                    websiteLink = "https://www.stdavidscathedral.org.uk/";

                    address = new List<string> { "5A The Pebbles,", "St. Davids,", "SA62 6RD" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone12 = true;
                }
                if (passedLandmarks >= 12 && !dbMilestone.Milestone13)
                {
                    Counter = 13;

                    townNameEnglish = "Fishguard";
                    townNameWelsh = "Abergwaun";
                    historicalPlaceNameEnglish = "Strumble Head Lighthouse";
                    historicalPlaceNameWelsh = "Goleudy Pen Strumble";

                    townInfoEnglish = "Strumble Head Lighthouse stands imposingly on Ynysmeicl (St. Michael's Island), " +
                        "an islet to the west of Fishguard, separated from the mainland by a very narrow gap through which " +
                        "the sea boils and froths in stormy weather.";

                    townInfoWelsh = "Mae Goleudy Pen Strumble yn sefyll ar Ynysmeicl, i’r dwyrain o Abergwaun, wedi’i wahanu o’r tir " +
                        "mawr gan bwlch cul iawn lle bu’r môr yn taro yn erbyn y tir mewn tywydd stormus.";

                    image = @"\Assets\Culture\Strumble Head Lighthouse.jpg";

                    tel = "02074 816900";

                    historicalPlaceEmail = "enquiries@trinityhouse.co.uk";

                    websiteLink = "https://www.trinityhouse.co.uk/lighthouses-and-lightvessels/strumble-head-lighthouse";

                    address = new List<string> { "Pencaer,", "SA64 0JL" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone13 = true;
                }
                if (passedLandmarks >= 13 && !dbMilestone.Milestone14)
                {
                    Counter = 14;

                    townNameEnglish = "Cardigan";
                    townNameWelsh = "Aberteifi";
                    historicalPlaceNameEnglish = "Cardigan Castle";
                    historicalPlaceNameWelsh = "Castell Aberteifi";

                    townInfoEnglish = "Cardigan Castle is a castle overlooking the River Teifi in Cardigan, Ceredigion, Wales. " +
                        "The castle dates from the late 11th-century, though was rebuilt in 1244. " +
                        "Castle Green House was built inside the castle walls in the early 1800s.";

                    townInfoWelsh = "Mae Castell Aberteifi yn gorchwilio Afon Teifi yn Aberteifi, Ceredigion, Cymru. " +
                        "Mae’r castell yn dyddio yn ôl i ddiwedd y 11eg ganrif, ag ail-adeiladwyd yn 1244. " +
                        "Cafodd Castell Tŷ Gwyrdd ei adeiladu tu fewn i waliau y castell yn yr 1800au cynnar.";

                    image = @"\Assets\Culture\Cardigan Castle.jpg";

                    tel = "01239 615131";

                    historicalPlaceEmail = "info@cardigancastle.com";

                    websiteLink = "https://www.cardigancastle.com/";

                    address = new List<string> { "Cardigan Castle Green Street,", "Cardigan,", "SA43 1JA" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone14 = true;
                }
                if (passedLandmarks >= 14 && !dbMilestone.Milestone15)
                {
                    Counter = 15;

                    townNameEnglish = "Aberystwyth";
                    townNameWelsh = "Aberystwyth";
                    historicalPlaceNameEnglish = "Plas Tan y Bwlch";
                    historicalPlaceNameWelsh = "Plas Tan y Bwlch";
                    townInfoEnglish = "Plas Tan y Bwlch in Gwynedd, Wales, is the Snowdonia National Park Environmental Studies Centre, administered by the National Park Authority. " +
                        "The Centre aims to provide courses which are of interest to all lovers of the countryside who would like to know about this fascinating area of Wales.";

                    townInfoWelsh = "Plas Tan y Bwlch yng Ngwynedd, Cymru, yw Canolfan Astudiaethau Parc Cenedlaethol Eryri, gweinyddwyd gan Parc Awdurdod Cenedlaethol. " +
                        "Pwrpas y ganolfan yw i ddarparu cyrsiau sydd o ddiddordeb i bawb sy’n hôff o gefn gwlad a hoffai wybod am yr ardal hyfryd yma yng Nghymru.";

                    image = @"\Assets\Culture\St Padarns Church.jpg";

                    tel = "01766 770274";

                    historicalPlaceEmail = "park@snowdonia.gov.wales";

                    websiteLink = "https://www.snowdonia.gov.wales/study-centre";

                    address = new List<string> { "Terrace Road,", "Aberystwyth,", "SY23 2AG" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone15 = true;
                }
                if (passedLandmarks >= 15 && !dbMilestone.Milestone16)
                {
                    Counter = 16;

                    townNameEnglish = "Barmouth";
                    townNameWelsh = "Abermaw";
                    historicalPlaceNameEnglish = "Round House";
                    historicalPlaceNameWelsh = "Tŷ crwn";

                    townInfoEnglish = "This Round House was erected in 1834. It was built as a lock-up where drunkards were detained until they became sober. " +
                        "It was also a place of detention pending the transfer of an accused to the nearest place where justice could be administered. " +
                        "The key was kept by the Parish Constable. The building is divided by a partition wall forming two cells of equal dimensions. " +
                        "One cell was reserved for men and the other for women.";

                    townInfoWelsh = "Adeiladwyd y Tŷ Crwn yma yn 1834. Adeiladwyd fel lle clo i feddwon cael eu cadw nes eu byd yn sobr. " +
                        "Roedd hefyd yn fan cadw hyd nes trosglwyddo cyhuddedig i’r ardal agosaf lle gellid weinyddu cyfiawnder. " +
                        "Cadwyd yr allwedd gan gwnstabl y plwyf. Mae’r adeilad wedi’i rannu a wal raniad sy’n ffurfio dwy gell o ddimensiynau cyfartal. " +
                        "Neilltuwyd un gell i ddynion a’r llall i ferched.";

                    image = @"\Assets\Culture\Round House.jpg";

                    websiteLink = "http://www.barmouth.wales/history/";

                    address = new List<string> { "Barmouth,", "LL42 1HA" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, null, null, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;

                    dbMilestone.Milestone16 = true;
                }
                if (passedLandmarks >= 16 && !dbMilestone.Milestone17)
                {
                    Counter = 17;

                    townNameEnglish = "Harlech";
                    townNameWelsh = "Harlech";
                    historicalPlaceNameEnglish = "Harlech Castle";
                    historicalPlaceNameWelsh = "Castell Harlech";

                    townInfoEnglish = "Harlech Castle in Harlech, Gwynedd, Wales, is a medieval fortification built onto a rocky knoll close to the Irish Sea. " +
                        "It was built by Edward I during his invasion of Wales between 1282 and 1289 at the relatively modest cost of £8,190. " +
                        "Over the next few centuries, the castle played an important part in several wars, withstanding the siege of Madog ap " +
                        "Llywelyn between 1294–95, but falling to Owain Glyndŵr in 1404. It then became Glyndŵr's residence and military headquarters " +
                        "for the remainder of the uprising until being recaptured by English forces in 1409.";

                    townInfoWelsh = "Mae Castell Harlech, Gwynedd, Cymru, yn gastell canoloesol â adeiladwyd ar fryn ger y Môr Iwerydd. " +
                        "Fe adeiladwyd gan Edward 1af yn ystod ei oresgyniad o Gymru rhwn 1282 a 1289 am gost gymharol o £8,190. " +
                        "Dros y canrifoedd nesaf, chwaraeodd y castell ran bwysig mewn sawl rhyfel, yn gwrthsefyll gwarchae Madog ap " +
                        "Llywelyn rhwng 1294-95, ond yn cwympo i Owain Glyndŵr yn 1404. Yna daeth yn breswylfa a pencadlys milwrol Glyndŵr am weddill y " +
                        "gwrthryfela nes iddo ei ail-ddal gan luoedd Lloegr yn 1409.";

                    image = @"\Assets\Culture\Harlech Castle.jpg";

                    tel = "01766 780552";

                    historicalPlaceEmail = "HarlechCastle@gov.wales";

                    websiteLink = "https://cadw.gov.wales/visit/places-to-visit/harlech-castle";

                    address = new List<string> { "Ffordd Newydd Road,", "Harlech,", "LL46 2YH" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;

                    dbMilestone.Milestone17 = true;
                }
                if (passedLandmarks >= 17 && !dbMilestone.Milestone18)
                {
                    Counter = 18;

                    townNameEnglish = "Pwllheli";
                    townNameWelsh = "Pwllheli";
                    historicalPlaceNameEnglish = "Nant Gwrtheyrn";
                    historicalPlaceNameWelsh = "Nant Gwrtheyrn";

                    townInfoEnglish = "Nant Gwrtheyrn is a Welsh Language and Heritage Centre, " +
                        "located near the village of Llithfaen on the northern coast of the Llŷn Peninsula, " +
                        "Gwynedd, in northwest Wales. The Centre specialises in Welsh for Adults (as a second language) " +
                        "and offers intensive residential courses throughout the year. Visitors to the area can enjoy our " +
                        "Heritage Centre which houses displays about the Welsh language and culture, as well as the history " +
                        "of the village which includes a period house set in a Victorian quarry community and information about " +
                        "the unique wildlife which can be discovered in this remote coastal valley and beach.";

                    townInfoWelsh = "Nant Gwrtheyrn yw Canolfan Iaith a Threftadaeth Cymru, wedi’i leoli ger pentref Llithfaen ar arfordir " +
                        "gogleddol y Llŷn Peninsula, Gwynedd, yng Ngogledd Cymru. Mae’r ganolfan yn arbenigo mewn cyrsiau Cymraeg i oedolion " +
                        "(fel ail iaith) ac yn cynnig cyrsiau dwys drwy gydol y flwyddyn. Mae ymwelydd i’r ardal yn gallu mwynhau ein Canolfan " +
                        "Treftadaeth sy’n arddangos gwybodaeth am iaith a diwylliant Cymru, yn ogystal a hanes y pentref sy’n cynnwys tŷ wedi’i " +
                        "leoli mewn  cymuned chwarel oes Fictoria a gwybodaeth am y bywyd gwyllt unigryw a ellir ddarganfod yn y dyffryn a’r traeth " +
                        "arfordirol anghysbell hwn.";

                    image = @"\Assets\Culture\Nant Gwrtheyrn.jpg";

                    tel = "01758 750 334";

                    websiteLink = "https://nantgwrtheyrn.org/";

                    address = new List<string> { "Nant Gwrtheyrn,", "Llithfaen,", "Pwllheli,", "Gwynedd, Wales,", "Ll53 6Nl" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, null, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone18 = true;
                }
                if (passedLandmarks >= 18 && !dbMilestone.Milestone19)
                {
                    Counter = 19;

                    townNameEnglish = "Gwynedd";
                    townNameWelsh = "Gwynedd";
                    historicalPlaceNameEnglish = "Bedd Gelert";
                    historicalPlaceNameWelsh = "Beddgelert";

                    townInfoEnglish = "Beddgelert is a village and community in the Snowdonia area of Gwynedd, Wales. " +
                        "It is reputed to be named after the legendary hound Gelert. " +
                        "Gelert is a legendary dog associated with the village of Beddgelert " +
                        "(whose name means " + '\u0022' + "Gelert's Grave" + '\u0022' + ") in Gwynedd, " +
                        "north-west Wales. In the legend, Llywelyn the Great returns from hunting to find his baby missing, " +
                        "the cradle overturned, and Gelert with a blood-smeared mouth. Believing the dog had savaged the child, " +
                        "Llywelyn draws his sword and kills Gelert. After the dog's dying yelp Llywelyn hears the cries of the baby, " +
                        "unharmed under the cradle, along with a dead wolf which had attacked the child and been killed by Gelert. " +
                        "Llywelyn is overcome with remorse and buries the dog with great ceremony, but can still hear its dying yelp. " +
                        "After that day Llywelyn never smiles again.";

                    townInfoWelsh = "Mae Beddgelert yn bentref a cymuned yn Eryri, Gwynedd, Cymru. Honnir iddo gael ei enwi ar ôl y ci " +
                        "chwedlonol Gelert. Ci chwedlonol yw Gelert sy’n gysylltiedig â phentref Beddgelert yn Ngwynedd, gogled orllewin " +
                        "Cymru. Yn y chwedl, dychwelir Llywelyn o hela i ddod o hyd i’w fabi ar goll, y crud wedi’i wrthdroi, a Gelert â gwaed " +
                        "dros ei geg. Gan gredu mai Gelert achoswyd hyn, mae Llywelyn yn tynnu ei gleddyf ac yn lladd Gelert. Ar ôl i Gelert farw " +
                        "fe glywodd Llywelyn grio babi, yn ddianaf o dan y crud, ynghyd â blaidd marw a ymasododd y babi a gafodd ei ladd gan Gelert. " +
                        "Goresgynir Llywelyn gydag edifeirwch ac yn claddu Gelert â seremoni fawr. Ar ôl y diwrnod hwnnw nid yw Llywelyn byth yn gwenu eto.";

                    image = @"\Assets\Culture\Bedd Gelert.jpg";

                    address = new List<string> { "Dryll Beddgelert,", "Beddgelert,", "LL55 4NE" };

                    websiteLink = "https://www.beddgelerttourism.com/gelert/";

                    openingTimes = new List<string> { "Mon – Sun: 10am – 5:30pm" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, null, null, openingTimes, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone19 = true;
                }
                if (passedLandmarks >= 19 && !dbMilestone.Milestone20)
                {
                    Counter = 20;

                    townNameEnglish = "Caernarfon";
                    townNameWelsh = "Caernarfon";
                    historicalPlaceNameEnglish = "Caernarfon Castle";
                    historicalPlaceNameWelsh = "Castell Caernarfon";

                    townInfoEnglish = "Caernarfon Castle is a medieval fortress in Caernarfon, Gwynedd, north-west Wales cared for by Cadw, " +
                        "the Welsh Government's historic environment service. It was a motte-and-bailey castle from the late 11th century " +
                        "until 1283 when King Edward I of England began to replace it with the current stone structure.";

                    townInfoWelsh = "Castell canoloesol yw Castell Caernarfon, Gwynedd, gogledd orllewin Cymru â gofalwyd gan Cadw, " +
                        "gwasanaeth Amgylchedd Hanesyddol Llywodraeth Cymru. Castell mwnt a beili oedd hi o’r 11eg ganrif hwyr i 1283 " +
                        "pryd ddechreuodd Brenin Lloegr Edward 1af ddisodli’r castell am y strwythur cerrig cyfredol.";

                    image = @"\Assets\Culture\Caernarfon Castle.jpg";

                    tel = "01286 677617";

                    historicalPlaceEmail = "CaernarfonCastle@gov.wales";

                    websiteLink = "https://cadw.gov.wales/visit/places-to-visit/caernarfon-castle";

                    openingTimes = new List<string> { "Mon – Wed: 10am – 4pm", "Thu – Fri: Closed", "Sat – Sun: 10am - 4pm" };

                    address = new List<string> { "Castle Ditch,", "Caernarfon,", "LL55 2AY" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, 
                        townNameEnglish, townNameWelsh, 
                        historicalPlaceNameEnglish, historicalPlaceNameWelsh, 
                        townInfoEnglish, townInfoWelsh, 
                        image, tel, historicalPlaceEmail, openingTimes, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone20 = true;
                }
                if (passedLandmarks >= 20 && !dbMilestone.Milestone21)
                {
                    Counter = 21;

                    townNameEnglish = "Anglesey";
                    townNameWelsh = "Sir Fôn";
                    historicalPlaceNameEnglish = "Beaumaris Castle";
                    historicalPlaceNameWelsh = "Castell Biwmares";

                    townInfoEnglish = "Beaumaris on the island of Anglesey is famous as the greatest castle never built. " +
                        "It was the last of the royal strongholds created by Edward I in Wales – and perhaps his masterpiece. " +
                        "Beaumaris Castle was never fully built, but had it been completed it would probably have closely resembled Harlech Castle. " +
                        "Both castles are concentric in plan, with walls within walls, although Beaumaris is the more regular in design.";

                    townInfoWelsh = "Mae Castell Biwmaris ar ynys Sir Fôn yn enwog fel y castell gorau a chafodd fyth ei adeiladu. " +
                        "Hwn oedd yr olaf o’r cadarnleoedd brenhinol a grêwyd gan Edward y 1af yng Nghymru – ac efallai ei gampwaith. " +
                        "Cafodd Castell Biwmaris byth ei orffen, ond petai y gwaith adeiladu wedi ei orffen fyddai’n debyg iawn i Gastell Harlech. " +
                        "Mae’r ddau gastell yn ganolbwyntiol eu cynllun, gyda waliau o fewn waliau, er mai Biwmaris yw’r mwyaf rheolaidd o ran dyluniad.";

                    image = @"\Assets\Culture\Beaumaris Castle.jpg";

                    tel = "01248 810361";

                    historicalPlaceEmail = "beaumaris.castle@gov.wales";

                    websiteLink = "https://cadw.gov.wales/visit/places-to-visit/beaumaris-castle";

                    address = new List<string> { "Castle Street,", "Beaumaris,", "LL58 8AP" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, null, websiteLink, address);
                    
                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone21 = true;
                }
                if (passedLandmarks >= 21 && !dbMilestone.Milestone22)
                {
                    Counter = 22;

                    townNameEnglish = "Conwy";
                    townNameWelsh = "Conwy";
                    historicalPlaceNameEnglish = "Conwy Castle";
                    historicalPlaceNameWelsh = "Castell Conwy";

                    townInfoEnglish = "Conwy Castle (Welsh: Castell Conwy) is a fortification in Conwy, located in North Wales. " +
                        "It was built by Edward I, during his conquest of Wales, between 1283 and 1289. " +
                        "The castle hugs a rocky coastal ridge of grey sandstone and limestone, and much of the stone from the castle is " +
                        "largely taken from the ridge itself, probably when the site was first cleared.";

                    townInfoWelsh = "Amddiffynfa yw Castell Conwy yng Nghonwy, wedi’i leoli yng Ngogledd Cymru. " +
                        "Fe’i hadeiladwyd gan Edward y 1af yn ystod ei goncwest o Gymru, rhwng 1283 a 1289. " +
                        "Mae’r castell yn cofleidio crib arfordirol greigiog o dywodfaen llwyd a chalchfaen, a llawer o gerrig o’r " +
                        "castell yn cael ei cymryd i raddau health o’r grib ei hun, yn ôl pob tebyg pan gliriwyd y sfale gyntaf.";

                    image = @"\Assets\Culture\Conwy Castle.jpg";

                    tel = "01492 592358";

                    historicalPlaceEmail = "ConwyCastle@gov.wales";

                    websiteLink = "https://cadw.gov.wales/visit/places-to-visit/conwy-castle";

                    openingTimes = new List<string> { "Mon – Wed: 10am -1pm", "Thu – Fri: Closed", "Sat – Sun: 10am – 1pm" };

                    address = new List<string> { "Rose Hill Street,", "Conwy,", "LL32 8AY" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, historicalPlaceEmail, openingTimes, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone22 = true;
                }
                if (passedLandmarks >= 22 && !dbMilestone.Milestone23)
                {
                    Counter = 23;


                    townNameEnglish = "Chester";
                    townNameWelsh = "Caer";
                    historicalPlaceNameEnglish = "City Walls";
                    historicalPlaceNameWelsh = "Muriau’r Ddinas";

                    townInfoEnglish = "The city walls are the oldest, longest and most complete in Britain, " +
                        "parts of which are almost 2000 years old. Chester is the only city in Britain that " +
                        "retains the full circuit of its ancient defensive walls. Walking the complete circuit " +
                        "gives wondrous views down into the city and gives a fantastic insight into Chester's long " +
                        "history.";

                    townInfoWelsh = "Muriau’r ddinas yw’r hynaf, hiraf a mwyaf poblogaidd ym Mhrydain, " +
                        "rhannau ohonynyt bron yn 2000 oed. Caer yw’r unig ddinas ym Mhrydain sydd wedi cadw cylched " +
                        "lawn ei waliau amddiffynnol. Mae cerdded y gylched gyfan yn rhoi golygfeydd rhyfeddol i lawr " +
                        "i’r ddinas ac yn rhoi mewnwelediad gwych i hanes hir Caer.";

                    image = @"\Assets\Culture\City Walls.jpg";

                    tel = "01244 351609";

                    websiteLink = "https://www.visitcheshire.com/things-to-do/chester-city-walls-p22241";

                    address = new List<string> { "St Martins Way,", "Chester,", "CH1 2NR" };

                    var MilestoneModel = new NewMilestoneModel(userName, StepsInMiles, steps, townNameEnglish,
                        townNameWelsh, historicalPlaceNameEnglish, historicalPlaceNameWelsh, townInfoEnglish,
                        townInfoWelsh, image, tel, null, null, websiteLink, address);

                    string body = _razorViewToStringRenderer.RenderViewToStringAsync(RenderViewString, MilestoneModel).Result;

                    messages.Add(new Message(new string[] { email }, string.Format(emailSubject, townNameWelsh, historicalPlaceNameWelsh, townNameEnglish, historicalPlaceNameEnglish), body, image));
                    EmailSent = true;
                    dbMilestone.Milestone23 = true;
                }
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
                await emailSender.SendPostcardEmailAsync(message);
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

        public List<string> GetTownAndHistoricalPlace()
        {
            List<string> Places = new List<string>();

            switch (Counter)
            {
                case 0:
                    Places.Add("Chepstow");
                    Places.Add("Tintern Abbey");
                    break;

                case 1:
                    Places.Add("Newport");
                    Places.Add("Transporter Bridge");
                    break;

                case 2:
                    Places.Add("Cardiff");
                    Places.Add("Cardiff Castle");
                    break;

                case 3:
                    Places.Add("Porthcawl");
                    Places.Add("Rest Bay Beach");
                    break;

                case 4:
                    Places.Add("Swansea");
                    Places.Add("Mumbles Pier");
                    break;

                case 5:
                    Places.Add("Rhossili");
                    Places.Add("Fall Bay");
                    break;

                case 6:
                    Places.Add("Llanelli");
                    Places.Add("Parc y Scarlets");
                    break;

                case 7:
                    Places.Add("Carmarthen");
                    Places.Add("Kidwelly Castle");
                    break;

                case 8:
                    Places.Add("Tenby");
                    Places.Add("St. Catherine’s Island");
                    break;

                case 9:
                    Places.Add("Pembrokeshire");
                    Places.Add("Barafundle Bay");
                    break;

                case 10:
                    Places.Add("Milford Haven");
                    Places.Add("Stack Rock Fort");
                    break;

                case 11:
                    Places.Add("St. Davids");
                    Places.Add("St. Davids Cathedral");
                    break;

                case 12:
                    Places.Add("Fishguard");
                    Places.Add("Strumble Head Lighthouse");
                    break;

                case 13:
                    Places.Add("Cardigan");
                    Places.Add("Cardigan Castle");
                    break;

                case 14:
                    Places.Add("Aberystwyth");
                    Places.Add("Plas Tan y Bwlch");
                    break;

                case 15:
                    Places.Add("Barmouth");
                    Places.Add("Round House");
                    break;

                case 16:
                    Places.Add("Harlech");
                    Places.Add("Harlech Castle");
                    break;

                case 17:
                    Places.Add("Pwllheli");
                    Places.Add("Nant Gwrtheyrn");
                    break;

                case 18:
                    Places.Add("Gwynedd");
                    Places.Add("Bedd Gelert");
                    break;

                case 19:
                    Places.Add("Caernarfon");
                    Places.Add("Caernarfon Castle");
                    break;

                case 20:
                    Places.Add("Anglesey");
                    Places.Add("Beaumaris Castle");
                    break;

                case 21:
                    Places.Add("Conwy");
                    Places.Add("Conwy Castle");
                    break;

                case 22:
                    Places.Add("Chester");
                    Places.Add("City Walls");
                    break;

                default:
                    Places.Add("Chepstow");
                    Places.Add("Tintern Abbey");
                    break;
            }
            return Places;
        }
    }
}
