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
        List<IStep> _steps;


        public int Start(List<IStep> steps)
        {
            _steps = steps;
            var emptys = new List<bool[,]>
            {
                Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty,
                Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty
            };

            foreach (IStep step in steps)
            {
                step.Apply(emptys);
            }
            
            return ModelHelper.period;
        }

       

        public void Stop()
        {
           
        }
    }
}
