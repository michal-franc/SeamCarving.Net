using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using LaMLibrary;

namespace LaMImageData
{
   public  class EnergyCalGradient : EnergyCalculatorBase, IEnergyCalculator
    {


        #region Constructors

       public EnergyCalGradient() 
           : base()
       {
       }

       public EnergyCalGradient(int pixelSize)
           : base(pixelSize)
       { 
       }

        #endregion

        #region IEnergyCalculator Members

        public unsafe int CalculateEnergy(Object current,BitmapData bmd,int last)
        {
            byte* tmpCurrent = (byte*)(int)current;
            byte* lower = tmpCurrent + bmd.Stride,
                  right = tmpCurrent + base._pixelSize,
                  lowerRight = tmpCurrent + bmd.Stride + base._pixelSize;

            int energy = 0;

            if (last == 0)
            {
               energy =
                      LibraryUnsafe.SubstractColors(tmpCurrent, lower)
                    + LibraryUnsafe.SubstractColors(tmpCurrent, right)
                    + LibraryUnsafe.SubstractColors(tmpCurrent, lowerRight);
            }
            else
            {
                byte* upper = tmpCurrent - bmd.Stride,
                    upperRight = tmpCurrent - bmd.Stride + base._pixelSize;;
                energy = LibraryUnsafe.SubstractColors(tmpCurrent, right)
                    + LibraryUnsafe.SubstractColors(tmpCurrent, upper)
                    + LibraryUnsafe.SubstractColors(tmpCurrent, upperRight);
            }

            //if (energy >= 255)
            //    return 255;
            //else
                return energy;
        }

        #endregion
    }
}