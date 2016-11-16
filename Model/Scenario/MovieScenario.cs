using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LedGeekBox.ViewModel;

namespace LedGeekBox.Model.Scenario
{
    public class MovieScenario : IScenario
    {
        string _scenarioFile = string.Empty;
        public MovieScenario(string scenarioFile)
        {
            _scenarioFile = scenarioFile;
        }

        List<IStep> _steps;
        List<binderClass> list;
        Thread t1 = null;

        int NbrOfCycle = 100;

        public int Start(List<IStep> steps)
        {
             list = ViewModelDesignEditor.Get(_scenarioFile, null, null);

            _steps = steps;
            t1 = new Thread(Render);
            t1.Start();

            return ModelHelper.period * (list.Count+10)*3;
        }


       
        public void Render()
        {
           

            for (int cycle = 0; cycle < NbrOfCycle; cycle++)
            {
             // bool[,] datas = new bool[40, 16];
                foreach (var view in list)
                {
                    // var line1 = ViewModelMain.ConverToList(view.rawData);

                    _steps.ForEach(x => x.Apply(view.rawData));

                    Thread.Sleep(ModelHelper.period*3);
                }
            }


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
