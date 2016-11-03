using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace LedGeekBox.Model.Scenario
{
    public class FillingScenario : IScenario
    {
        List<IStep> _steps;

        Thread t = null;

        public int Start(List<IStep> steps)
        {
            _steps = steps;
            t = new Thread(Rendering);
            t.Start();
            return ModelHelper.period * 60;
        }

        private void Rendering()
        {
            int step = 0;
           
            do
            {
                List<bool[,]> dico = new List<bool[,]>();

                int total = 0;
                for (int i = 0; i < 5; i++)
                {
                    bool[,] datas = new bool[8, 8];
                    for (int j = 0; j < 8; j++)
                    {
                        if(total <= step)
                        {
                            datas[0, j] = true;
                            datas[1, j] = true;
                            datas[2, j] = true;
                            datas[3, j] = true;

                            datas[4, j] = true;
                            datas[5, j] = true;
                            datas[6, j] = true;
                            datas[7, j] = true;

                        }

                        total ++;
                    }
                    dico.Add(datas);

                }
                dico.Add(dico[0]);
                dico.Add(dico[1]);
                dico.Add(dico[2]);
                dico.Add(dico[3]);
                dico.Add(dico[4]);




                //  ModelHelper.RenderingGeneric(new ThreadObject { WhatToWrite1 = hour, WhatToWrite2 = date, Steps = _steps });

                _steps.ForEach(s => s.Apply(dico));
                Thread.Sleep(ModelHelper.period);

                step++;
            } while (step<40);
            Thread.Sleep(ModelHelper.period*3);
        }

        public void Stop()
        {
            if (t != null && t.IsAlive)
            {
                t.Abort();
            }
            t = null;
        }
    }
}