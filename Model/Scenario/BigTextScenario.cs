using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LedGeekBox.Helper;

namespace LedGeekBox.Model.Scenario
{
    public class BigTextScenario : IScenario
    {

        string msg = string.Empty;


        public BigTextScenario(string line)
        {
            msg = line;
        }

        List<IStep> _steps;

        Thread t1 = null;

        public int Start(List<IStep> steps)
        {
            _steps = steps;
            //  t1 = new Thread(ModelHelper.RenderingGeneric);
            //  t1.Start(new ThreadObject { WhatToWrite1 = msg1, WhatToWrite2 =  msg2,  Steps = _steps});

            //t2 = new Thread(ModelHelper.RenderingGeneric);
            //t2.Start(new ThreadObject { WhatToWrite = msg2, Steps = _steps, FirstLine = false });

            //int totallenght1 = 0;
            //int totallenght2 = 0;
            //List<bool[,]> msg1List = null;
            //List<bool[,]> msg2List = null;

            //    int tmpmax = 0;
            //  ModelHelper.Build(msg1, msg2, out msg1List, out msg2List, out totallenght1, out totallenght2, out tmpmax);

            Render();

            return ModelHelper.period * (100);
        }


        private void Render()
        {
            // #1 get all char un single row size
            int totallenght = 0;
            List<bool[,]> tmpArray = msg.ToList().Select(x =>
            {
                var y = HelperLetterDefinition.Get(x.ToString());
                totallenght += y.GetLength(1);
                return y;
            }).ToList();

            // #2 create temp array  with all values one behind each other   
            bool[,] boolMainMessage = new bool[Definition.Number_Led_X_Max7219, totallenght];

            int localcursor = 0;
            foreach (bool[,] x in tmpArray)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    for (int inc = 0; inc < Definition.Number_Led_X_Max7219; inc++)
                    {
                        boolMainMessage[inc, localcursor] = x[inc, j];
                    }
                    localcursor++;
                }
            }


            // #3 create new array two time bigger => so that we can write in it (from boolMainMessage)
            bool[,] mainmessage = new bool[totallenght * 2, Definition.Number_Led_X_Max7219 * 2];

            for (int i = 0; i < totallenght; i++)
            {
                for (int j = 0; j < Definition.Number_Led_X_Max7219; j++)
                {
                    mainmessage[i * 2, j * 2] = boolMainMessage[j, i];
                    mainmessage[i * 2 + 1, j * 2] = boolMainMessage[j, i];
                    mainmessage[i * 2, j * 2 + 1] = boolMainMessage[j, i];
                    mainmessage[i * 2 + 1, j * 2 + 1] = boolMainMessage[j, i];
                }
            }

            ModelHelper.RenderingGeneric(mainmessage, _steps);

            //var line1 = HelperMatriceListConvertor.ConvertToList(mainmessage);

            //_steps.ForEach(x => x.Apply(line1));

        }


        public void Stop()
        {
            if (t1 != null && t1.IsAlive)
            {
                t1.Abort();
            }
            t1 = null;
        }
    }
}
