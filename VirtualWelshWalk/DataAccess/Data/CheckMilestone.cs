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

            switch (falseCounter)
            {
                case 0:
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
                    // First Milestone Tintern Abbey
                    if (stepInMiles >= 0 || stepInMiles <= 18.8)
                    {
                        landMarksPassed = 1;
                    }
                    //
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

                    if (stepInMiles >= 30.4 || stepInMiles <= 56.1)
                    {
                        // done
                    }

                    if (stepInMiles >= 56.2 || stepInMiles <= 80)
                    {
                        // done
                    }

                    if (stepInMiles >= 80.1 || stepInMiles <= 95.6)
                    {
                        // done
                    }

                    if (stepInMiles >= 95.7 || stepInMiles <= 114.5)
                    {
                        // done
                    }

                    if (stepInMiles >= 114.6 || stepInMiles <= 124.4)
                    {
                        // done
                    }

                    if (stepInMiles >= 124.5 || stepInMiles <= 152.8)
                    {
                        // done
                    }

                    if (stepInMiles >= 152.9 || stepInMiles <= 164.9)
                    {
                        // done
                    }

                    if (stepInMiles >= 165.0 || stepInMiles <= 179.7)
                    {
                        // done
                    }

                    if (stepInMiles >= 179.8 || stepInMiles <= 211.2)
                    {
                        // done
                    }

                    if (stepInMiles >= 211.3 || stepInMiles <= 227.4)
                    {
                        // done
                    }

                    if (stepInMiles >= 227.5 || stepInMiles <= 249.9)
                    {
                        // done
                    }

                    if (stepInMiles >= 250 || stepInMiles <= 287.8)
                    {
                        // done
                    }

                    if (stepInMiles >= 287.9 || stepInMiles <= 327.2)
                    {
                        // done
                    }

                    if (stepInMiles >= 327.3 || stepInMiles <= 338.1)
                    {
                        // done
                    }

                    if (stepInMiles >= 338.2 || stepInMiles <= 365.7)
                    {
                        // done
                    }

                    if (stepInMiles >= 365.8 || stepInMiles <= 387.2)
                    {
                        // done
                    }

                    if (stepInMiles >= 387.3 || stepInMiles <= 400.1)
                    {
                        // done
                    }

                    if (stepInMiles >= 400.2 || stepInMiles <= 412.5)
                    {
                        // done
                    }

                    if (stepInMiles >= 412.6 || stepInMiles <= 433.5)
                    {
                        // done
                    }

                    if (stepInMiles >= 433.6 || stepInMiles <= 476.9)
                    {
                        // done
                    }

                    if (stepInMiles >= 477)
                    {
                        // done - last one
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
