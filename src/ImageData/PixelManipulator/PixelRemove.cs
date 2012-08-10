using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaMImageData
{
    public unsafe class PixelRemove : IPixelManipulator
    {

        #region Private Fields
        private int _maxIterator;
        private int _iterator;
        private int _pixelSize;

        #endregion

        #region IPixelManipulator Members

        public bool ChangePixel(Object startPixel,LaMLibrary.SeamDirection seamDirection)
        {

            if (seamDirection == LaMLibrary.SeamDirection.Horizontal)
            {
                ShiftPixelsHor((byte*)(int)startPixel);
            }
            else if (seamDirection == LaMLibrary.SeamDirection.Vertical)
            {
                ShiftPixelsVer((byte*)(int)startPixel);
            }
            else
            {
                throw new NotImplementedException();
            }

            return true;
        }

        public void SetUp(int width,int x,int pixelSize)
        {
            _maxIterator = width;
            _iterator = x;
            _pixelSize = pixelSize;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Shifts pixels from the current location to the right
        /// </summary>
        /// <param name="startPixel">Adress of the pixel</param>
        /// <param name="x">Location of the pixel in image</param>
        private void ShiftPixelsHor(byte* startPixel)
        {

            if (_iterator >= _maxIterator)
            {
                return;
            }

            byte* nextPixel = startPixel + _pixelSize;
            ChangePixels(ref startPixel, nextPixel);
            ++_iterator;
            ShiftPixelsHor(nextPixel);
        }



        private void ShiftPixelsVer(byte* startPixel)
        {
            if (_iterator >= _maxIterator-1)
            {
                return;
            }

            byte* nextPixel = startPixel + _pixelSize;
            ChangePixels(ref startPixel, nextPixel);
            ++_iterator;
            ShiftPixelsVer(nextPixel);
        }
        
        /// <summary>
        /// Change Pixels
        /// </summary>
        /// <param name="pixelA">Pixel to Change</param>
        /// <param name="pixelB">Pixel to Change from</param>
        private static void ChangePixels(ref byte* pixelA, byte* pixelB)
        {
            pixelA[0] = pixelB[0];
            pixelA[1] = pixelB[1];
            pixelA[2] = pixelB[2];
        } 
        #endregion
    }
}