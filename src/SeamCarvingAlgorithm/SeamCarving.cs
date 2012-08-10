using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SeamCarvingAlgorithm;
using LaMLibrary;
using LaMImageData;

namespace SeamCarvingAlgorithm
{
    public class SeamCarving
    {
        #region Fields
        public IImageProcessing _imgProcessor;
        #endregion

        #region Constructor

        private SeamCarving()
        {
        }

        public SeamCarving(IImageProcessing imgProcessor)
            : this()
        {
            _imgProcessor = imgProcessor;
        }

        #endregion

        #region Public Functions
        /// <summary>
        /// Function to Create Gradient and save it as the current image.
        /// </summary>
        /// <param name="fileName">Path of the Image</param>
        public Bitmap Gradient(IEnergyCalculator energyCalculator)
        {
            _imgProcessor.Open();

            int[,] energy = _imgProcessor.Energy(energyCalculator,true);

            _imgProcessor.Close();

            return _imgProcessor.GetBmp();
        }
        /// <summary>
        /// Seam Manipulation
        /// </summary>
        /// <param name="seamManipulator">Seam Manipulator must</param>
        /// <param name="numberOfOper"></param>
        /// <returns></returns>
        public Bitmap SeamManipulation(ISeamManipulator seamManipulator, int numberOfOper,SeamDirection seamDirection)
        {
            _imgProcessor.Open();
            for (int i = 0; i < numberOfOper; i++)
            {
                seamManipulator.ManipulateSeam(_imgProcessor,seamDirection);
            }
            _imgProcessor.Close();
            return _imgProcessor.GetBmp();
        }
        #endregion

        public static void Main()
        {

        }
    }

}
