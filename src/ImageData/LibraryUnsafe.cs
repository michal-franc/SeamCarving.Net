using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaMImageData
{
    public unsafe static class LibraryUnsafe
    {
        public static int SubstractColors(byte* a, byte* b)
        {
           try
           {
                int outpout = Math.Abs(a[0] - b[0])
                     + Math.Abs(a[1] - b[1])
                     + Math.Abs(a[2] - b[2]);
                return outpout;
           }
           catch (Exception e)
           {
              return 0;
           }
        }

        /// <summary>
        /// Sets Color with specified RGB(value,value,value) 
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="pixelToColor">Adress of the Pixel</param>
        public static void SetColor(int value, byte* pixelToColor)
        {
            SetColorRGB(value, value, value, pixelToColor);
        }

        /// <summary>
        /// Sets Color with 3 values input
        /// </summary>
        /// <param name="R">Red</param>
        /// <param name="G">Green</param>
        /// <param name="B">Blue</param>
        /// <param name="pixelToColor">Adress of the Pixel</param>
        public static void SetColorRGB(int R, int G, int B, byte* pixelToColor)
        {
            pixelToColor[0] = (byte)R;
            pixelToColor[1] = (byte)G;
            pixelToColor[2] = (byte)B;
        }

    }
}