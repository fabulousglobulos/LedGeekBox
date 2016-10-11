using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedGeekBox.Model.Scenario
{
    public class HourScenario : IScenario
    {

        IStep step;

        Thread t = null;

        public int Start(IStep stepper)
        {
            step = stepper;
            t= new Thread(Rendering);
            t.Start();
            return 10000;
        }

        private void Rendering()
        {
            do
            {
                string hour = DateTime.Now.ToString("hh:mm:ss");
                string date = DateTime.Now.ToString("dd.MM.yy");

                ModelHelper.RenderingGeneric(new ThreadObject {WhatToWrite = hour, ViewModel = step, FirstLine = true});
                ModelHelper.RenderingGeneric(new ThreadObject {WhatToWrite = date, ViewModel = step, FirstLine = false});
            } while (true);
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
