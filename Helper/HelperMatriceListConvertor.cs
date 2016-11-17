using System.Collections.Generic;

namespace LedGeekBox.Helper
{
    public static class HelperMatriceListConvertor
    {
        public static bool[,] ConvertToMatrice(List<bool[,]> datas)
        {
            bool[,] matrice = new bool[40, 16];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        matrice[i * 8 + j, k] = datas[i][k, j];
                        matrice[i * 8 + j, k + 8] = datas[i + 5][k, j];
                    }
                }
            }

            return matrice;
        }

        public static List<bool[,]> ConvertToList(bool[,] datas)
        {
            List<bool[,]> l = new List<bool[,]>();

            for (int i = 0; i < 5; i++)
            {
                bool[,] x = new bool[8, 8];
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        x[k, j] = datas[i * 8 + j, k]; //TODO verifier // int inf = firstline ? 0 : 8;
                    }
                }
                l.Add(x);
            }

            for (int i = 0; i < 5; i++)
            {
                bool[,] x2 = new bool[8, 8];
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        x2[k, j] = datas[i * 8 + j, 8 + k]; //TODO verifier // int inf = firstline ? 0 : 8;
                    }
                }
                l.Add(x2);
            }

            return l;
        }

    }
}