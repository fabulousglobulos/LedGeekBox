using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedGeekBox.Model.Scenario
{
    public class EmptyScenario : IScenario
    {
        IStep step;


        public int Start(IStep stepper)
        {
            step = stepper;
            var emptys = new List<bool[,]> {Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty };

            stepper.Apply(emptys,true);
            stepper.Apply(emptys, false);
            return 1000;
        }

       

        public void Stop()
        {
           
        }
    }
}
