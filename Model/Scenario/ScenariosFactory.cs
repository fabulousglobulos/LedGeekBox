using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedGeekBox.Model.Scenario
{
    public static class ScenariosFactory
    {

        public static List<IScenario> Build(string scenariosString)
        {
            List<IScenario> scenar = new List<IScenario>();

            var ss = scenariosString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in ss)
            {
                IScenario sco = null;

                string name = s.Substring(0, s.IndexOf("("));
                switch (name.ToUpper())
                {
                    case "HOUR":
                        {
                            sco = new HourScenario();
                            break;
                        }
                    case "CLEAR":
                        {
                            sco = new EmptyScenario();

                            break;
                        }
                    case "SNOW":
                        {
                            sco = new SnowScenario();

                            break;
                        }
                    case "SNAKE":
                        {
                            sco = new SnakeScenario();

                            break;
                        }
                    case "PIXEL":
                        {
                            sco = new PixelScenario();

                            break;
                        }
                    case "TEXT":
                        {
                            Dictionary<string, string> arguments = GetArguments(s);

                            sco = new TextScenario(arguments["MSG1"], arguments["MSG2"]);

                            break;
                        }
                    case "FILLING":
                        {
                            sco = new FillingScenario();
                            break;
                        }
                    case "MOVIE":
                        {
                            Dictionary<string, string> arguments = GetArguments(s);

                            sco = new MovieScenario(arguments["FILE"]);
                            break;
                        }
                }

                if (sco != null)
                {
                    scenar.Add(sco);
                }
            }

            return scenar;
        }


        public static Dictionary<string, string> GetArguments(string rawarguments)
        {
            int first = rawarguments.IndexOf("(");
            string argumentsRaw = rawarguments.Substring(first + 1, rawarguments.Length - first - 2);
            var argumentsList = argumentsRaw.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            foreach (string argumentsListItem in argumentsList)
            {
                string argName = argumentsListItem.Substring(0, argumentsListItem.IndexOf("=")).ToUpper();
                string argvalue = argumentsListItem.Substring(argumentsListItem.IndexOf("=") + 1);
                arguments.Add(argName, argvalue);
            }
            return arguments;
        }
    }
}
