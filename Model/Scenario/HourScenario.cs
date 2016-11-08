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
        List<IStep> _steps;

        Thread t = null;

        public int Start(List<IStep> steps)
        {
            _steps = steps;
            t= new Thread(Rendering);
            t.Start();
            return ModelHelper.period*100;
        }

        private void Rendering()
        {
            do
            {
                string hour = DateTime.Now.ToString("HH:mm:ss");
                string date = DateTime.Now.ToString("dd.MM.yy");

                ModelHelper.RenderingGeneric(new ThreadObject {WhatToWrite1 = hour,  WhatToWrite2  =  date,  Steps = _steps});
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
