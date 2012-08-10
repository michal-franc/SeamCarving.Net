﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaMLibrary;
using LaMImageData;

namespace SeamCarvingAlgorithm
{
   public class DynamicSeamManipulatorWithMark : ISeamManipulator
    {

        #region IManipulator Members

        public void ManipulateSeam(IImageProcessing imgProcessor,SeamDirection seamDirection)
        {
            int[,] energy = imgProcessor.Energy(new LaMImageData.EnergyCalGradient(), false);

            int[] dynamicSeamArray = Library.CreateDynamicSeam(energy,seamDirection);

            imgProcessor.DynamicRow(new PixelColor(), dynamicSeamArray,seamDirection);
        }

        #endregion
    }
}