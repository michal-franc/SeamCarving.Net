using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaMImageData
{
    public class EnergyCalculatorBase
    {

        protected int _pixelSize;

        #region Constructors
        /// <summary>
        /// Constructor with default _pixelSize =3
        /// </summary>
        protected EnergyCalculatorBase()
        {
            _pixelSize = 3;
        }

        /// <summary>
        /// Constructor with settable pixelSize
        /// </summary>
        /// <param name="pixelSize">Custom Pixelsize</param>
        protected EnergyCalculatorBase(int pixelSize)
        {
            _pixelSize = pixelSize;
        }
        #endregion

    }
}