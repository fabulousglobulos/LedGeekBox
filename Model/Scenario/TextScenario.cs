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

        IStep step;

        Thread t1 = null;
        Thread t2 = null;

        public int Start(IStep stepper)
        {
            step = stepper;
            t1 = new Thread(ModelHelper.RenderingGeneric);
            t1.Start(new ThreadObject { WhatToWrite = msg1, ViewModel = step, FirstLine = true });

            t2 = new Thread(ModelHelper.RenderingGeneric);
            t2.Start(new ThreadObject { WhatToWrite = msg2, ViewModel = step, FirstLine = false });

            return 10000;
        }


        public void Stop()
        {
            if (t1 != null && t1.IsAlive)
            {
                t1.Abort();
            }
            t1 = null;
            if (t2 != null && t2.IsAlive)
            {
                t2.Abort();
            }
            t2 = null;
        }
    }
}
