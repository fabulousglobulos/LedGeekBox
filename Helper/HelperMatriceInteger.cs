using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedGeekBox.Helper
{
    public static class HelperMatriceInteger
    {
        public static bool[,] RevertBuildList(List<int> data)
        {
            bool[,] matrix = new bool[8, 8];

            for (int i = 0; i < 8; i++)
            {
                int d = data[i];
                if ((d & 128) == 128)
                {
                    matrix[i, 0] = true;
                }
                if ((d & 64) == 64)
                {
                    matrix[i, 1] = true;
                }
                if ((d & 32) == 32)
                {
                    matrix[i, 2] = true;
                }
                if ((d & 16) == 16)
                {
                    matrix[i, 3] = true;
                }
                if ((d & 8) == 8)
                {
                    matrix[i, 4] = true;
                }
                if ((d & 4) == 4)
                {
                    matrix[i, 5] = true;
                }
                if ((d & 2) == 2)
                {
                    matrix[i, 6] = true;
                }
                if ((d & 1) == 1)
                {
                    matrix[i, 7] = true;
                }
            }

            return matrix;
        }


        public static List<int> BuildList(bool[,] matrix)
        {
            List<int> data = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                int number = 0;

                bool a = matrix[i, 0]; //bit de poids fort ! (a gauche)
                bool b = matrix[i, 1];
                bool c = matrix[i, 2];
                bool d = matrix[i, 3];

                bool e = matrix[i, 4];
                bool f = matrix[i, 5];
                bool g = matrix[i, 6];
                bool h = matrix[i, 7];//bit de poids faible ! (a droite)
                if (a)
                {
                    number += 128;
                }
                if (b)
                {
                    number += 64;
                }
                if (c)
                {
                    number += 32;
                }
                if (d)
                {
                    number += 16;
                }

                if (e)
                {
                    number += 8;
                }
                if (f)
                {
                    number += 4;
                }
                if (g)
                {
                    number += 2;
                }
                if (h)
                {
                    number += 1;
                }
                data.Add(number);
            }
            return data;
        }
    }
}
