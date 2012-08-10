using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaMLibrary
{
    public static class Library
    {
        /// <summary>
        /// Function to Sum 2 dimensional tab into one dimensonal
        /// </summary>
        public static int[] TabSum(int[,] inTab)
        {
            int [] tabSum = new int[inTab.GetLength(0)];

            for (int i = 0; i < inTab.GetLength(0); i++)
            {
                for (int y = 0; y < inTab.GetLength(1); y++)
                {
                    tabSum[i] += inTab[i, y];
                }
            }

            return tabSum;
        }


        /// <summary>
        /// Returns Array formated as  [x1,y1,x2,y2.......]  of a minimal or maximal road from one side of the bmp
        /// </summary>
        /// <param name="inTab">Tab representing  2 dimensional array</param>
        /// <returns>Array formated as  [x1,y1,x2,y2.......] </returns>
        public static int[] FindMinimalTraverse(int[,] inTab)
        {
            throw new NotImplementedException();
        }

        public static int FindIndexWithLowestValue(int [] inTab)
        {
            int najmniejszy = 0;
            int najmniejszaWartosc = inTab[0];

            for (int i = 0; i < inTab.Length - 1; i++)
            {
                if (najmniejszaWartosc > inTab[i+1])
                {
                    najmniejszaWartosc = inTab[i+1];
                    najmniejszy = i+1;
                }
            }
            return najmniejszy;
        }

        public static void FillArray(ref int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        /// <summary>
        /// Function to find an index of the least imporatnat seam 
        /// </summary>
        /// <returns></returns>
        public static int FindStaticSeam(int[] energySum)
        {
            return FindIndexWithLowestValue(energySum);
        }

        public static int[] CreateDynamicSeam(int[,] energy,LaMLibrary.SeamDirection seamDirection)
        {
            int INFINITE = 999;
            int[] seamArray;
            int[] tmpArray;
            int[] tmpArray1= new int[3];
            int[] parameters = new int[2];

            if (seamDirection == SeamDirection.Horizontal)
            {
                parameters[0]= energy.GetLength(1);
                parameters[1]= energy.GetLength(0);
            }
            else if (seamDirection == SeamDirection.Vertical)
            {
                parameters[0] = energy.GetLength(0);
                parameters[1] = energy.GetLength(1);
            }
            // Na razie nie mam mozliwosci wyboru obu kierunkow na raz....
            else
            {
                throw new NotImplementedException();
            }

            seamArray = new int[parameters[0] * 2];
            tmpArray = new int[parameters[0]];


            int y = 0;
            int iterator = 0;

            // wyciecie jednego wiersza do nowej array z ktorej pobierzemy minimum ;]
            tmpArray = CutFirstRow(energy,seamDirection);

            int x = FindIndexWithLowestValue(tmpArray);

            seamArray[iterator++] = x;
            seamArray[iterator++] = y++;

            while (y < parameters[0] - 1)
            {
                tmpArray = CutOneRow(energy, y, seamDirection);

                if (x < parameters[1] - 1)
                {
                    if (x - 1 >= 0)
                    {

                        tmpArray1[0] = tmpArray[x - 1];
                        tmpArray1[1] = tmpArray[x];
                        tmpArray1[2] = tmpArray[x + 1];
                    }
                    else if (x > 0)
                    {
                        tmpArray1[0] = INFINITE;
                        tmpArray1[1] = tmpArray[x];
                        tmpArray1[2] = tmpArray[x + 1];
                    }
                    else
                    {
                        tmpArray1[0] = INFINITE;
                        tmpArray1[1] = 0;
                        tmpArray1[2] = INFINITE;
                    }
                }
                else if (x > 0)
                {
                    tmpArray1[0] = tmpArray[x - 1];
                    tmpArray1[1] = tmpArray[x];
                    tmpArray1[2] = INFINITE;
                }
                else
                {
                    tmpArray1[0] = INFINITE;
                    tmpArray1[1] = tmpArray[x];
                    tmpArray1[2] = INFINITE;
                }

                x += FindIndexWithLowestValue(tmpArray1) - 1;

                seamArray[iterator++] = x;
                seamArray[iterator++] = y++;

            }

            return seamArray;
        }

        private static int[] CutFirstRow(int[,] energy, SeamDirection seamDirection)
        {
            if (seamDirection == SeamDirection.Horizontal)
            {
                int[] tmpArray = new int[energy.GetLength(0)];
                for (int i = 0; i < energy.GetLength(0); i++)
                {
                    for (int j = 0; j < energy.GetLength(1); j++)
                    {
                        tmpArray[i] += energy[i, j];
                    }
                }
                return tmpArray;
            }
            else
            {
                int[] tmpArray = new int[energy.GetLength(1)];
                for (int i = 0; i < energy.GetLength(1); i++)
                {
                    for (int j = 0; j < energy.GetLength(0); j++)
                    {
                        tmpArray[i] += energy[j, i];
                    }
                }
                return tmpArray;
            }
        }


        private static int[] CutOneRow(int[,] energy, int row,SeamDirection seamDirection)
        {

            if (seamDirection == SeamDirection.Horizontal)
            {
                int[] tmpArray = new int[energy.GetLength(0)];
                for (int i = 0; i < energy.GetLength(0); i++)
                {
                    tmpArray[i] = energy[i, row];
                }
                return tmpArray;
            }
            else
            {
                int[] tmpArray = new int[energy.GetLength(1)];
                for (int i = 0; i < energy.GetLength(1); i++)
                {
                    tmpArray[i] = energy[row, i];
                }
                return tmpArray;
            }
        }
    }
}
