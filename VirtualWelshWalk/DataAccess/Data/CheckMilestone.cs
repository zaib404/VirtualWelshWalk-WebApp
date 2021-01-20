using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;
using System.Reflection;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class CheckMilestone
    {
        public VirtualMilestone dbMilestone { get; set; }

        public CheckMilestone(VirtualMilestone dbMilestone)
        {
            this.dbMilestone = dbMilestone;
        }

        public void MilestoneCheck(double virtualStepsInMiles)
        {
            // Retrieve the names of all the boolean properties of dbMilestone class which are true
            int falseCounter = 0;
            int totalBoolCounter = 0;

            foreach (PropertyInfo propertyInfo in dbMilestone.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(bool))
                {
                    bool value = (bool)propertyInfo.GetValue(dbMilestone, null);

                    if (!value)
                    {
                        //add propertyInfo to some result
                        falseCounter++;
                    }
                    totalBoolCounter++;
                }
            }

            Check(falseCounter, virtualStepsInMiles);

        }

        void Check(int falseCounter, double stepInMiles)
        {
            int landMarksPassed = 0;

            #region If statement to check if they have passed a certain landmark
            // First Milestone Tintern Abbey
            if (stepInMiles >= 0 || stepInMiles <= 18.8)
            {
                landMarksPassed = 1;
            }
            // Transporter bridge
            if (stepInMiles >= 18.9 || stepInMiles <= 30.3)
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
            if (stepInMiles >= 30.4 || stepInMiles <= 56.1)
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
            if (stepInMiles >= 56.2 || stepInMiles <= 80)
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
            if (stepInMiles >= 80.1 || stepInMiles <= 95.6)
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
            if (stepInMiles >= 95.7 || stepInMiles <= 114.5)
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
            if (stepInMiles >= 114.6 || stepInMiles <= 124.4)
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
            if (stepInMiles >= 124.5 || stepInMiles <= 152.8)
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
            if (stepInMiles >= 152.9 || stepInMiles <= 164.9)
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
            if (stepInMiles >= 165.0 || stepInMiles <= 179.7)
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
            if (stepInMiles >= 179.8 || stepInMiles <= 211.2)
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
            if (stepInMiles >= 211.3 || stepInMiles <= 227.4)
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
            if (stepInMiles >= 227.5 || stepInMiles <= 249.9)
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
            if (stepInMiles >= 250 || stepInMiles <= 287.8)
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
            if (stepInMiles >= 287.9 || stepInMiles <= 327.2)
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
            if (stepInMiles >= 327.3 || stepInMiles <= 338.1)
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
            if (stepInMiles >= 338.2 || stepInMiles <= 365.7)
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
            if (stepInMiles >= 365.8 || stepInMiles <= 387.2)
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
            if (stepInMiles >= 387.3 || stepInMiles <= 400.1)
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
            if (stepInMiles >= 400.2 || stepInMiles <= 412.5)
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
            if (stepInMiles >= 412.6 || stepInMiles <= 433.5)
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
            if (stepInMiles >= 433.6 || stepInMiles <= 476.9)
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
            if (stepInMiles >= 477)
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

            switch (landMarksPassed-1)
            {
                case 0:
                    if (!dbMilestone.Milestone1)
                    {
                        // send email
                    }
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;

                case 9:
                    break;

                case 10:
                    break;

                case 11:
                    break;

                case 12:
                    break;

                case 13:
                    break;

                case 14:
                    break;

                case 15:
                    break;

                case 16:
                    break;

                case 17:
                    break;

                case 18:
                    break;

                case 19:
                    break;

                case 20:
                    break;

                case 21:
                    
                    break;

                case 22:
                    
                    break;

                case 23:
                    
                    break;

                default:
                    break;
            }
        }
    }
}
