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
                string hour = DateTime.Now.ToString("hh:mm:ss");
                string date = DateTime.Now.ToString("dd.MM.yy");

                ModelHelper.RenderingGeneric(new ThreadObject {WhatToWrite = hour, Steps = _steps, FirstLine = true});
                ModelHelper.RenderingGeneric(new ThreadObject {WhatToWrite = date, Steps = _steps, FirstLine = false});
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
