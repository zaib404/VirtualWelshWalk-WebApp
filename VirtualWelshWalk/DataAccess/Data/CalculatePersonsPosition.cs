using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class CalculatePersonsPosition
    {

        public double NewPosition(int totalSteps)
        {
            // Convert to kilometers 
            return Math.Round(totalSteps / 1312.33595801,2);
            //return Convert.ToDouble(totalSteps / 1312.33595801);
        }

    }
}
