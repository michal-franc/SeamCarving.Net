using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaMImageData
{
    public unsafe interface IPixelManipulator
    {
        /// <summary>
        /// Changes the pixel.
        /// </summary>
        /// <param name="startPixel">The start pixel.</param>
        /// <param name="seamDirection">The seam direction.</param>
        /// <returns>Resize Bitmap - true / false ?</returns>
        bool ChangePixel(Object startPixel,LaMLibrary.SeamDirection seamDirection);

        /// <summary>
        /// Sets up.
        /// </summary>
        /// <param name="maxIterator">The max iterator.</param>
        /// <param name="iterator">The iterator.</param>
        /// <param name="pixelSize">Jump to nextPixel e.g [3 in horizontal stride in vertical]</param>
        void SetUp(int maxIterator, int iterator,int pixelSize);
    }
}
