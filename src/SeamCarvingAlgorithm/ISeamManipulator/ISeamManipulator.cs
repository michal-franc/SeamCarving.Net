using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LaMImageData;

namespace SeamCarvingAlgorithm
{
    public interface ISeamManipulator
    {
        void ManipulateSeam(IImageProcessing imgProcessor,LaMLibrary.SeamDirection seamDirection);
    }
}
