using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace LedGeekBox
{
    public static class Model
    {
        private readonly static int period = 200;

        private static void log(List<bool[,]> msg)
        {
            string line1 = "";
            string line2 = "";
            string line3 = "";
            string line4 = "";
            string line5 = "";
            string line6 = "";
            string line7 = "";
            string line8 = "";

            foreach (bool[,] c in msg)
            {
                for (int i = 0; i < c.GetLength(1); i++)
                {
                    line1 += c[0, i] ? "#" : "_";
                    line2 += c[1, i] ? "#" : "_";
                    line3 += c[2, i] ? "#" : "_";
                    line4 += c[3, i] ? "#" : "_";
                    line5 += c[4, i] ? "#" : "_";
                    line6 += c[5, i] ? "#" : "_";
                    line7 += c[6, i] ? "#" : "_";
                    line8 += c[7, i] ? "#" : "_";
                }
                line1 += " ";
                line2 += " ";
                line3 += " ";
                line4 += " ";
                line5 += " ";
                line6 += " ";
                line7 += " ";
                line8 += " ";
            }

            Trace.Write(line1 + Environment.NewLine);
            Trace.Write(line2 + Environment.NewLine);
            Trace.Write(line3 + Environment.NewLine);
            Trace.Write(line4 + Environment.NewLine);
            Trace.Write(line5 + Environment.NewLine);
            Trace.Write(line6 + Environment.NewLine);
            Trace.Write(line7 + Environment.NewLine);
            Trace.Write(line8 + Environment.NewLine);
        }


        public static void Rendering(string whatToWrite, ViewModelMaxLayout vm, bool firstline)
        {
            int totallenght = 0;
            List<bool[,]> msg = whatToWrite.ToList().Select(x =>
            {
                var y = Helper.Get(x.ToString());
                totallenght += y.GetLength(1);
                return y;
            }).ToList();

            log(msg);

            bool[,] mainmessage = new bool[8, totallenght];
            int localcursor = 0;
            foreach (bool[,] x in msg)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    mainmessage[0, localcursor] = x[0, j];
                    mainmessage[1, localcursor] = x[1, j];
                    mainmessage[2, localcursor] = x[2, j];
                    mainmessage[3, localcursor] = x[3, j];
                    mainmessage[4, localcursor] = x[4, j];
                    mainmessage[5, localcursor] = x[5, j];
                    mainmessage[6, localcursor] = x[6, j];
                    mainmessage[7, localcursor] = x[7, j];
                    localcursor++;
                }
            }

            if (totallenght < 40)
            {//center the message
                double reste = (40 - totallenght) / 2.0;
                int final = Convert.ToInt32(reste);
                double division = reste - final;
                if (division >= 0.5)
                {
                    final++;
                }
                if (final > 0)
                {
                    //  var  mainmessage2 = new bool[8, totallenght+ final];

                    //    Array.Copy(mainmessage,0, mainmessage2, final, totallenght );

                    //mainmessage.CopyTo(mainmessage2, final);
                    var vincent = Merge(new bool[8, final], mainmessage);

                    mainmessage = vincent;

                    totallenght = totallenght + final;
                }

            }

            int offsetstatic = totallenght - 5 * 8;
            if (offsetstatic < 0)
            {
                offsetstatic = 0;
            }

            Thread.Sleep(period * 2);

            for (int o = 0; o <= offsetstatic; o++)
            {
                List<bool[,]> z = new List<bool[,]>();

                int index = 0;
                int smallindex = 0;
                bool[,] current = new bool[8, 8];

                for (int i = (0 + o); i < (5 * 8 + o); i++)
                {
                    index = i;

                    if (index > totallenght + 1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex > 7) //on cherche a remplir uniquement une matrix, sinon on passe au suivant
                    {
                        z.Add(current);
                        current = new bool[8, 8];
                        smallindex = 0;
                    }
                    if (i < totallenght)
                    {
                        current[0, smallindex] = mainmessage[0, index];
                        current[1, smallindex] = mainmessage[1, index];
                        current[2, smallindex] = mainmessage[2, index];
                        current[3, smallindex] = mainmessage[3, index];

                        current[4, smallindex] = mainmessage[4, index];
                        current[5, smallindex] = mainmessage[5, index];
                        current[6, smallindex] = mainmessage[6, index];
                        current[7, smallindex] = mainmessage[7, index];
                    }

                    smallindex++;

                    if ((index == ((5 * 8) - 1) + o) && (smallindex != 1))
                    {
                        z.Add(current);
                    }

                }
                if (z.Count == 4)
                {
                    z.Add(current);
                }

                List<bool[,]> dico = new List<bool[,]>();
                dico.Add(z.Count > 0 ? z[0] : Helper.EmptyMatrix);
                dico.Add(z.Count > 1 ? z[1] : Helper.EmptyMatrix);
                dico.Add(z.Count > 2 ? z[2] : Helper.EmptyMatrix);
                dico.Add(z.Count > 3 ? z[3] : Helper.EmptyMatrix);
                dico.Add(z.Count > 4 ? z[4] : Helper.EmptyMatrix);

                if (firstline)
                {
                    vm.Apply1(dico);
                }
                else
                {
                    vm.Apply2(dico);
                }

                Thread.Sleep(period);
            }
        }


        static bool[,] Merge(bool[,] original, bool[,] added)
        {
            int originalX = original.GetLength(0);
            int originalY = original.GetLength(1);

            int addedX = added.GetLength(0);
            int addedY = added.GetLength(1);
            var final = new bool[8, originalY + addedY];

            for (int i = 0; i < addedY; i++)
            {
                final[0, i + originalY] = added[0, i];
                final[1, i + originalY] = added[1, i];
                final[2, i + originalY] = added[2, i];
                final[3, i + originalY] = added[3, i];
                final[4, i + originalY] = added[4, i];
                final[5, i + originalY] = added[5, i];
                final[6, i + originalY] = added[6, i];
                final[7, i + originalY] = added[7, i];

            }


            return final;

        }





        public static void RenderingReverse(string whatToWrite, ViewModelMaxLayout vm, bool firstline)
        {
            int totallenght = 0;
            List<bool[,]> msg = whatToWrite.ToList().Select(x =>
            {
                var y = Helper.Get(x.ToString());
                totallenght += y.GetLength(1);
                return y;
            }).ToList();

            log(msg);

            bool[,] mainmessage = new bool[8, totallenght];
            int localcursor = 0;
            foreach (bool[,] x in msg)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    mainmessage[0, localcursor] = x[0, j];
                    mainmessage[1, localcursor] = x[1, j];
                    mainmessage[2, localcursor] = x[2, j];
                    mainmessage[3, localcursor] = x[3, j];
                    mainmessage[4, localcursor] = x[4, j];
                    mainmessage[5, localcursor] = x[5, j];
                    mainmessage[6, localcursor] = x[6, j];
                    mainmessage[7, localcursor] = x[7, j];
                    localcursor++;
                }
            }

            int offsetstatic = totallenght - 5 * 8;
            if (offsetstatic < 0)
            {
                offsetstatic = 0;
            }

            Thread.Sleep(period * 2);

            for (int o = 0; o <= offsetstatic; o++)
            {
                List<bool[,]> z = new List<bool[,]>();

                int index = 0;
                int smallindex = 0;
                bool[,] current = new bool[8, 8];

                for (int i = (0 + o); i < (5 * 8 + o); i++)
                {
                    index = i;

                    if (index > totallenght + 1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex > 7) //on cherche a remplir uniquement une matrix, sinon on passe au suivant
                    {
                        z.Add(current);
                        current = new bool[8, 8];
                        smallindex = 0;
                    }
                    if (i < totallenght)
                    {
                        current[0, smallindex] = mainmessage[0, index];
                        current[1, smallindex] = mainmessage[1, index];
                        current[2, smallindex] = mainmessage[2, index];
                        current[3, smallindex] = mainmessage[3, index];

                        current[4, smallindex] = mainmessage[4, index];
                        current[5, smallindex] = mainmessage[5, index];
                        current[6, smallindex] = mainmessage[6, index];
                        current[7, smallindex] = mainmessage[7, index];
                    }

                    smallindex++;

                    if ((index == ((5 * 8) - 1) + o) && (smallindex != 1))
                    {
                        z.Add(current);
                    }
                }

                List<bool[,]> dico = new List<bool[,]>();
                dico.Add(z.Count > 0 ? z[0] : Helper.EmptyMatrix);
                dico.Add(z.Count > 1 ? z[1] : Helper.EmptyMatrix);
                dico.Add(z.Count > 2 ? z[2] : Helper.EmptyMatrix);
                dico.Add(z.Count > 3 ? z[3] : Helper.EmptyMatrix);
                dico.Add(z.Count > 4 ? z[4] : Helper.EmptyMatrix);

                if (firstline)
                {
                    vm.Apply1(dico);
                }
                else
                {
                    vm.Apply2(dico);
                }

                Thread.Sleep(period);
            }
        }
    }
}