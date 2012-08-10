using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaMLibrary;
using LaMImageData;

namespace SeamCarvingAlgorithm
{
   public class StaticSeamManipulatorwithMark : ISeamManipulator
    {

        #region IManipulator Members

        public void ManipulateSeam(IImageProcessing imgProcessor,SeamDirection seamDirection)
        {
            int[,] energy = imgProcessor.Energy(new LaMImageData.EnergyCalGradient(), false);

            int seam = Library.FindStaticSeam(Library.TabSum(energy));

            imgProcessor.StaticRow(new LaMImageData.PixelColor(), seam);
        }

        #endregion
    }
}