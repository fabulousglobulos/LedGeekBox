using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using LedGeekBox.Helper;
using LedGeekBox.Model.Scenario;

namespace LedGeekBox.Model
{
    public static class ModelHelper
    {
        public readonly static int period = 100;

        public static void log(bool[,] msg)
        {
            string line1 = "";
            string line2 = "";
            string line3 = "";
            string line4 = "";
            string line5 = "";
            string line6 = "";
            string line7 = "";
            string line8 = "";

            string line9 = "";
            string line10 = "";
            string line11 = "";
            string line12 = "";
            string line13 = "";
            string line14 = "";
            string line15 = "";
            string line16 = "";

            for (int i = 0; i < msg.GetLength(0); i++)
            {
                line1 += msg[i, 0] ? "#" : "_";
                line2 += msg[i, 1] ? "#" : "_";
                line3 += msg[i, 2] ? "#" : "_";
                line4 += msg[i, 3] ? "#" : "_";
                line5 += msg[i, 4] ? "#" : "_";
                line6 += msg[i, 5] ? "#" : "_";
                line7 += msg[i, 6] ? "#" : "_";
                line8 += msg[i, 7] ? "#" : "_";

                line9 += msg[i, 08] ? "#" : "_";
                line10 += msg[i, 09] ? "#" : "_";
                line11 += msg[i, 10] ? "#" : "_";
                line12 += msg[i, 11] ? "#" : "_";
                line13 += msg[i, 12] ? "#" : "_";
                line14 += msg[i, 13] ? "#" : "_";
                line15 += msg[i, 14] ? "#" : "_";
                line16 += msg[i, 15] ? "#" : "_";
            }
            line1 += " ";
            line2 += " ";
            line3 += " ";
            line4 += " ";
            line5 += " ";
            line6 += " ";
            line7 += " ";
            line8 += " ";

            line9 += " ";
            line10 += " ";
            line11 += " ";
            line12 += " ";
            line13 += " ";
            line14 += " ";
            line15 += " ";
            line16 += " ";


            Trace.Write(line1 + Environment.NewLine);
            Trace.Write(line2 + Environment.NewLine);
            Trace.Write(line3 + Environment.NewLine);
            Trace.Write(line4 + Environment.NewLine);
            Trace.Write(line5 + Environment.NewLine);
            Trace.Write(line6 + Environment.NewLine);
            Trace.Write(line7 + Environment.NewLine);
            Trace.Write(line8 + Environment.NewLine);

            Trace.Write(line9 + Environment.NewLine);
            Trace.Write(line10 + Environment.NewLine);
            Trace.Write(line11 + Environment.NewLine);
            Trace.Write(line12 + Environment.NewLine);
            Trace.Write(line13 + Environment.NewLine);
            Trace.Write(line14 + Environment.NewLine);
            Trace.Write(line15 + Environment.NewLine);
            Trace.Write(line16 + Environment.NewLine);
        }

        public static void log(List<bool[,]> msg)
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

        public static void RenderingGeneric(object param)
        {
            ThreadObject typedParam = param as ThreadObject;

            Rendering(typedParam.WhatToWrite1, typedParam.WhatToWrite2, typedParam.Steps);
        }



        public static void Build(string whatToWrite1, string whatToWrite2, out List<bool[,]> msg1, out List<bool[,]> msg2, out int max, out int totallenght1, out int totallenght2)
        {
            totallenght1 = 0;

            msg1 = new List<bool[,]>();
            foreach (char x in whatToWrite1)
            {
                var y = HelperLetterDefinition.Get(x.ToString());
                totallenght1 += y.GetLength(1);
                msg1.Add(y);
            }

            totallenght2 = 0;

            msg2 = new List<bool[,]>();
            foreach (char x in whatToWrite2)
            {
                var y = HelperLetterDefinition.Get(x.ToString());
                totallenght2 += y.GetLength(1);
                msg2.Add(y);
            }
            if (totallenght1 > totallenght2)
            {
                max = totallenght1;
            }
            else
            {
                max = totallenght2;
            }
        }

        //TODO use : whitetowrite2
        static void Rendering(string whatToWrite1, string whatToWrite2, List<IStep> stp)
        {
            int totallenght1 = 0;
            int totallenght2 = 0;
            List<bool[,]> msg1 = null;
            List<bool[,]> msg2 = null;

            int tmpmax = 0;
            Build(whatToWrite1, whatToWrite2, out msg1, out msg2, out tmpmax, out totallenght1, out totallenght2);


            log(msg1);
            log(msg2);

            bool[,] mainmessage1 = new bool[8, totallenght1];
            bool[,] mainmessage2 = new bool[8, totallenght2];

            int localcursor = 0;
            foreach (bool[,] x in msg1)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                    {
                        mainmessage1[inc, localcursor] = x[inc, j];
                    }

                    localcursor++;
                }
            }

            localcursor = 0;
            foreach (bool[,] x in msg2)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                    {
                        mainmessage2[inc, localcursor] = x[inc, j];
                    }

                    localcursor++;
                }
            }

            if (totallenght1 < Definition.Number_Led_X_total)
            {
                //center the message
                double reste1 = (Definition.Number_Led_X_total - totallenght1) / 2.0;
                int final1 = Convert.ToInt32(reste1);
                double division1 = reste1 - final1;
                if (division1 >= 0.5)
                {
                    final1++;
                }
                if (final1 > 0)
                {
                    mainmessage1 = Merge(new bool[Definition.Number_Led_X_Max7219, final1], mainmessage1);
                    totallenght1 = totallenght1 + final1;
                }

            }


            if (totallenght2 < Definition.Number_Led_X_total)
            {//center the message
                double reste2 = (Definition.Number_Led_X_total - totallenght2) / 2.0;
                int final2 = Convert.ToInt32(reste2);
                double division2 = reste2 - final2;
                if (division2 >= 0.5)
                {
                    final2++;
                }
                if (final2 > 0)
                {
                    mainmessage2 = Merge(new bool[Definition.Number_Led_X_Max7219, final2], mainmessage2);
                    totallenght2 = totallenght2 + final2;
                }
            }

            int offsetstatic1 = totallenght1 - Definition.Number_Led_X_total;
            if (offsetstatic1 < 0)
            {
                offsetstatic1 = 0;
            }


            int offsetstatic2 = totallenght2 - Definition.Number_Led_X_total;
            if (offsetstatic2 < 0)
            {
                offsetstatic2 = 0;
            }

            int max = (offsetstatic1 > offsetstatic2) ? offsetstatic1 : offsetstatic2;

            for (int o1 = 0; o1 <= max; o1++)
            {
                List<bool[,]> dico = new List<bool[,]>();

                List<bool[,]> z = new List<bool[,]>();
                #region 1

                int index = 0;
                int smallindex = 0;
                bool[,] current = new bool[Definition.Number_Led_X_Max7219, Definition.Number_Led_Y_Max7219];

                bool touched = false;

                for (int i = o1; i < (Definition.Number_Led_X_total + o1); i++)
                {
                    index = i;

                    if (index > totallenght1 + 1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex > (Definition.Number_Led_X_Max7219 - 1)) //on cherche a remplir uniquement une matrix, sinon on passe au suivant
                    {
                        z.Add(current);
                        current = new bool[Definition.Number_Led_X_Max7219, Definition.Number_Led_Y_Max7219];
                        smallindex = 0;
                    }
                    if (i < totallenght1)
                    {
                        if (index < mainmessage1.GetLength(1))
                        {
                            for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                            {
                                current[inc, smallindex] = mainmessage1[inc, index];
                            }
                        }
                        else
                        {
                            for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                            {
                                current[inc, smallindex] = false;
                            }
                        }
                    }
                    touched = true;
                    smallindex++;

                    if ((index == (Definition.Number_Led_X_total - 1) + o1) && (smallindex != 1))
                    {
                        z.Add(current);
                        touched = false;
                    }
                }

                if (touched)
                {
                    z.Add(current);
                }

                dico.Add(z.Count > 0 ? z[0] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z.Count > 1 ? z[1] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z.Count > 2 ? z[2] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z.Count > 3 ? z[3] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z.Count > 4 ? z[4] : HelperLetterDefinition.EmptyMatrix);

                #endregion 1

                #region 2

                List<bool[,]> z2 = new List<bool[,]>();

                int index2 = 0;
                int smallindex2 = 0;
                bool[,] current2 = new bool[Definition.Number_Led_X_Max7219, Definition.Number_Led_Y_Max7219];

                bool touched2 = false;

                for (int i2 = (0 + o1); i2 < (Definition.Number_Led_X_total + o1); i2++)
                {
                    index2 = i2;

                    if (index2 > totallenght2 + 1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex2 > 7) //on cherche a remplir uniquement une matrix, sinon on passe au suivant
                    {
                        z2.Add(current2);
                        current2 = new bool[Definition.Number_Led_X_Max7219, Definition.Number_Led_Y_Max7219];
                        smallindex2 = 0;
                    }
                    if (i2 < totallenght2)
                    {
                        if (index2 < mainmessage2.GetLength(1))
                        {
                            for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                            {
                                current2[inc, smallindex2] = mainmessage2[inc, index2];
                            }
                        }
                        else
                        {
                            for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                            {
                                current2[inc, smallindex2] = false;
                            }
                        }
                    }

                    smallindex2++;
                    touched2 = true;
                    if ((index2 == (Definition.Number_Led_X_total - 1) + o1) && (smallindex2 != 1))
                    {
                        z2.Add(current2);
                        touched2 = false;
                    }
                }
                if (touched2)// if (z2.Count == 4)
                {
                    z2.Add(current2);
                }

                dico.Add(z2.Count > 0 ? z2[0] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z2.Count > 1 ? z2[1] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z2.Count > 2 ? z2[2] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z2.Count > 3 ? z2[3] : HelperLetterDefinition.EmptyMatrix);
                dico.Add(z2.Count > 4 ? z2[4] : HelperLetterDefinition.EmptyMatrix);

                #endregion 2

                stp.ForEach(s => s.Apply(dico));
                Thread.Sleep(period);
            }
            Thread.Sleep(period * 2);
        }




        public static bool[,] Extract(bool[,] source, int x, int y, int dimX, int dimY)
        {
            bool[,] retour = new bool[dimX, dimY];

            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    retour[i, j] = source[x + i, y + j];
                }
            }
            return retour;
        }


       public  static void RenderingGeneric(bool[,] datas, List<IStep> stp)
        {
            log(datas);

            int max = datas.GetLength(0);

            if (max > Definition.Number_Led_X_total)
            {
                int nbrIncrement = max - Definition.Number_Led_X_total;

                for (int increment = 0; increment <= nbrIncrement; increment++)
                {
                    bool[,] current = ModelHelper.Extract(datas, increment, 0, Definition.Number_Led_X_total,
                        Definition.Number_Led_Y_total);


                    List<bool[,]> dico = HelperMatriceListConvertor.ConvertToList(current);

                    stp.ForEach(s => s.Apply(dico));
                    Thread.Sleep(period);

                    Thread.Sleep(period * 2);
                }
            }
            else
            {
                //TODO centrer
            }

        }


        static bool[,] Merge(bool[,] original, bool[,] added)
        {
            int originalX = original.GetLength(0);
            int originalY = original.GetLength(1);

            int addedX = added.GetLength(0);
            int addedY = added.GetLength(1);
            var final = new bool[Definition.Number_Led_X_Max7219, originalY + addedY];

            for (int i = 0; i < addedY; i++)
            {
                for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                {
                    final[inc, i + originalY] = added[inc, i];
                }
            }
            return final;
        }


        //TODO: A IMPLEMENTER
        static void RenderingReverse(string whatToWrite, IStep stp, bool firstline)
        {
            int totallenght = 0;
            List<bool[,]> msg = whatToWrite.ToList().Select(x =>
            {
                var y = HelperLetterDefinition.Get(x.ToString());
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
                    for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                    {
                        mainmessage[inc, localcursor] = x[inc, j];
                    }
                    localcursor++;
                }
            }

            int offsetstatic = totallenght - Definition.Number_Led_X_total;
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
                bool[,] current = new bool[Definition.Number_Led_X_Max7219, Definition.Number_Led_Y_Max7219];

                for (int i = (0 + o); i < (Definition.Number_Led_X_total + o); i++)
                {
                    index = i;

                    if (index > totallenght + 1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex > (Definition.Number_Led_X_Max7219 - 1)) //on cherche a remplir uniquement une matrix, sinon on passe au suivant
                    {
                        z.Add(current);
                        current = new bool[Definition.Number_Led_X_Max7219, Definition.Number_Led_Y_Max7219];
                        smallindex = 0;
                    }
                    if (i < totallenght)
                    {
                        for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                        {
                            current[inc, smallindex] = mainmessage[inc, index];
                        }
                    }

                    smallindex++;

                    if ((index == (Definition.Number_Led_X_total - 1) + o) && (smallindex != 1))
                    {
                        z.Add(current);
                    }
                }

                List<bool[,]> dico = new List<bool[,]>();

                for (int inc = 0; inc < (Definition.Number_Max7219_X * Definition.Number_Max7219_Y); inc++)
                {
                    dico.Add(z.Count > inc ? z[inc] : HelperLetterDefinition.EmptyMatrix);
                }

                stp.Apply(dico);

                Thread.Sleep(period);
            }
        }

    }
}