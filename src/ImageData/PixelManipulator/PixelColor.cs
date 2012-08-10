using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaMImageData
{
    public unsafe class PixelColor : IPixelManipulator
    {

        #region IPixelManipulator Members

        public bool ChangePixel(Object startPixel,LaMLibrary.SeamDirection seamDirection)
        {
            LibraryUnsafe.SetColorRGB(0, 0, 255, (byte*)(int)startPixel);
            return false;
        }

        public void SetUp(int width, int seam,int pixelSize)
        {
            
        }

        #endregion
    }
}