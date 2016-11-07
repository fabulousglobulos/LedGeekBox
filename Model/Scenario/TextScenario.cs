using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedGeekBox.Model.Scenario
{
    public class TextScenario : IScenario
    {

        string msg1 = string.Empty;
        string msg2 = string.Empty;

        public TextScenario(string line1, string line2)
        {
            msg1 = line1;
            msg2 = line2;
        }

        List<IStep> _steps;

        Thread t1 = null;

        public int Start(List<IStep> steps)
        {
            _steps = steps;
            t1 = new Thread(ModelHelper.RenderingGeneric);
            t1.Start(new ThreadObject { WhatToWrite1 = msg1, WhatToWrite2 =  msg2,  Steps = _steps});

            //t2 = new Thread(ModelHelper.RenderingGeneric);
            //t2.Start(new ThreadObject { WhatToWrite = msg2, Steps = _steps, FirstLine = false });

            int totallenght1 = 0;
            int totallenght2 = 0;
            List<bool[,]> msg1List = null;
            List<bool[,]> msg2List = null;

            int tmpmax = 0;
            ModelHelper.Build(msg1, msg2, out msg1List, out msg2List, out totallenght1, out totallenght2, out tmpmax);

            return ModelHelper.period* (tmpmax);
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
