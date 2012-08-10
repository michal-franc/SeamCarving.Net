using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace LaMImageData
{
    public interface IEnergyCalculator
    {
        int CalculateEnergy(Object current, BitmapData bmd,int last);
    }
}
