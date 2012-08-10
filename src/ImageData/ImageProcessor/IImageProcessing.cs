using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LaMImageData
{
    public interface IImageProcessing
    {
        void Open();
        void Close();

        void SetBmp(Bitmap bmp);
        Bitmap GetBmp();
        void SaveBmp(string fileLocation);

        void StaticRow(IPixelManipulator pixelManippulator, int seam);
        void DynamicRow(IPixelManipulator pixelManippulator, int[] inTab,LaMLibrary.SeamDirection seamDirection );

        int[,] Energy(IEnergyCalculator energyCalculator,bool changeBmp);
    }
}
