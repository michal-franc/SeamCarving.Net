using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace LaMImageData
{
    public unsafe class GdiImageProces  : IImageProcessing
    {
        #region Private Fields
		
        private int _pixelSize;
        private static IImageProcessing _instance;
        private Bitmap _bmp;
        private BitmapData _bmd;

        //Iterator on the image Data
        private byte* _current;

        #endregion

        #region Constructor

        private GdiImageProces(Bitmap bmp)
        {
            _bmp = bmp;
            _pixelSize = 3;
        }
        
        #endregion

        #region Private Methids

        private void GoToX(int x)
        {
            _current += x * _pixelSize;
        }

        private void GoToStart()
        {
            _current = (byte*)(void*)_bmd.Scan0;
        }

        private void GoToXY(int x, int y)
        {
            GoToStart();
            _current += x * _pixelSize;
            _current += _bmd.Stride * y;
        }

        /// <summary>
        /// Sets bitmap data and locks bmp you have to use this functions before performing operations
        /// </summary>
        private void LockBits()
        {
            _bmd = _bmp.LockBits(new Rectangle(0, 0, _bmp.Width , _bmp.Height), ImageLockMode.ReadWrite, _bmp.PixelFormat);
        }

        /// <summary>
        /// Functions which unlocks bmp and cleans data you have to execute this function after operations
        /// </summary>
        private void UnlockBits()
        {
            _bmp.UnlockBits(_bmd);
        }

        /// <summary>
        /// Resizes Bitmap
        /// </summary>
        /// <param name="n">Number of Resizesz to Make</param>
        // TODO : problem with creating new image when there is a image with boundary equal to 1
        private void ResizeBitmap(LaMLibrary.SeamDirection seamDirection)
        {
            UnlockBits();

            if (seamDirection == LaMLibrary.SeamDirection.Horizontal)
            {
                if (_bmp.Width != 1)
                {
                    _bmp = _bmp.Clone(new Rectangle(0, 0, _bmp.Width - 1, _bmp.Height), _bmp.PixelFormat);
                }
            }
            else if (seamDirection == LaMLibrary.SeamDirection.Vertical)
            {
                if (_bmp.Height != 1)
                {
                    _bmp = _bmp.Clone(new Rectangle(0, 0, _bmp.Width, _bmp.Height - 1), _bmp.PixelFormat);
                }
            }
            else
            {
                throw new Exception("This should Never Happen :D Wrong SeamDirection Passed To ResizeBitmap Method");
            }
            LockBits();
        }
    
        #endregion

        #region Public Methods

        /// <summary>
        /// Sets new Bmp
        /// </summary>
        /// <param name="bmp">refference to new Bmo</param>
        public void SetBmp(Bitmap bmp)
        {
            _bmp = bmp;
        }

        public Bitmap GetBmp()
        {
            return _bmp;
        }

        public void Open()
        {
            LockBits();
        }

        public void Close()
        {
            UnlockBits();
        }

        /// <summary>
        /// Returns Instance of Singleton
        /// </summary>
        /// <param name="bmp">Image to Open</param>
        /// <returns></returns>
        public static IImageProcessing GetInstance(Bitmap bmp)
        {
            _instance = _instance ?? new GdiImageProces(bmp);

            return _instance;
        }

        public void StaticRow(IPixelManipulator pixelManipulator, int seam)
        {
            bool resize = false;

            _current = (byte*)(void*)_bmd.Scan0;
            _current += seam * _pixelSize;

            pixelManipulator.SetUp(_bmd.Width,seam,3);

            for (int y = 0; y < _bmp.Height - 1; y++)
            {
                _current += _bmd.Stride;

                //if (pixelManipulator.ChangePixel((int)_current))
                //{
                    //resize = true;
                //}

                throw new NotImplementedException();
            }

            if (resize)
            {
                //ResizeBitmap(1);
            }
        }

        //Tablica Wejsciowa sformatowana jako [x1,y1,x2,y2,......]
        public void DynamicRow(IPixelManipulator pixelManipulator, int [] inTab,LaMLibrary.SeamDirection seamDirection)
        {
            int[] parameters = new int[3];
            bool resize = false;
            if (seamDirection == LaMLibrary.SeamDirection.Horizontal)
            {
                parameters[0] = _bmp.Height;
                parameters[1] = _bmd.Width;
                parameters[2] = 3;
            }
            else if (seamDirection == LaMLibrary.SeamDirection.Vertical)
            {
                parameters[0] = _bmp.Width;
                parameters[1] = _bmd.Height;
                parameters[2] = _bmd.Stride;
            }
                
            for (int i = 0; i < parameters[0] - 1; i++)
            {
                int pxNumber = inTab[i * 2];

                pixelManipulator.SetUp(parameters[1] , pxNumber, parameters[2]);


                if (seamDirection == LaMLibrary.SeamDirection.Horizontal)
                {
                    GoToXY(inTab[i * 2], i);
                }
                else if (seamDirection == LaMLibrary.SeamDirection.Vertical)
                {
                    GoToXY(i, inTab[i * 2]);
                }


                if (pixelManipulator.ChangePixel((int)_current,seamDirection))
                {
                    resize = true;
                }
            }
            if (resize)
            {
                ResizeBitmap(seamDirection);
            }
           

        }


        // Breaki odtwarzajace bug

        /// <summary>
        /// Calculates gradient with or without saving to image
        /// </summary>
        /// <param name="saveBmp">Save to File</param>
        /// <returns>Array of Energies</returns>
        public int[,] Energy(IEnergyCalculator energyCalculator,bool changeBmp)
        {

            int[,] energy = new int[_bmp.Width, _bmp.Height];

            _current = (byte*)(void*)_bmd.Scan0;

            int nOffset = _bmd.Stride - _bmp.Width * _pixelSize;
            int nWidth = _bmp.Width * _pixelSize;
            int currentEnergy = 0;
            int ex = 0, ey = 0;
            // ostatni wiersz narazie pomijam 
            // bo jest problem z przekroczonym adresem jak dodam stride-a
            for (int y = 0; y < _bmp.Height; y++)
            {
                ex = 0;
                for (int x = 0; x < nWidth; x++)
                {
                    if (x % _pixelSize == 0 || x == 0)
                    {
                        if (y == _bmp.Height - 1)
                        {
                            currentEnergy = energyCalculator.CalculateEnergy((int)_current, _bmd, 1);
                        }
                        else
                        {
                            currentEnergy = energyCalculator.CalculateEnergy((int)_current, _bmd, 0);
                        }

                        if (changeBmp)
                            LibraryUnsafe.SetColor(currentEnergy, _current);

                            energy[ex, ey] = currentEnergy;    

                        ex++;
                    }
                    _current++;
                }
                _current += nOffset;
                ey++;
            }

            //energy[_bmp.Width-1, _bmp.Height-1] = 9999999;
            return energy;
        }

        /// <summary>
        /// Saves Bmp
        /// </summary>
        /// <param name="fileLocation">File Path</param>
        public void SaveBmp(string fileLocation)
        {
            _bmp.Save(fileLocation);
            _bmp.Dispose();
        }

        #endregion

        #region Main Method
        static void Main(string[] args)
        {
        } 
        #endregion

    }
}
