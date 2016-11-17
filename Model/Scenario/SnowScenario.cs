using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LedGeekBox.Helper;
using LedGeekBox.ViewModel;

namespace LedGeekBox.Model.Scenario
{
    public class SnowScenario : IScenario
    {

        public SnowScenario()
        {

        }

        List<IStep> _steps;

        Thread t1 = null;

        int NbrOfCycle = 100;

        public int Start(List<IStep> steps)
        {
            flakes.Add(SnowFlake.BuildFlake(flakes));
            flakes.Add(SnowFlake.BuildFlake(flakes));

            _steps = steps;
            t1 = new Thread(Render);
            t1.Start();

            return ModelHelper.period * NbrOfCycle * 2;
        }


        List<SnowFlake> flakes = new List<SnowFlake>();

        public void Render()
        {
            for (int cycle = 0; cycle < NbrOfCycle; cycle++)
            {
                flakes.Add(SnowFlake.BuildFlake(flakes));

                List<SnowFlake> incrementY = new List<SnowFlake>();

                bool[,] datas = new bool[40, 16];
                for (int j = 0; j < 16; j++)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        var elligible = flakes.Where(f => f.PositionX == i);
                        if (elligible.Any())
                        {
                            var elligible2 = elligible.Where(f2 =>
                            {
                                int min = f2.PositionY - f2.TTL;
                                int max = f2.PositionY;

                                return j>min && j<=max;
                            });

                            if (elligible2.Any())
                            {
                                datas[i, j] = true;
                                incrementY.AddRange(elligible2);
                            }
                        }
                    }
                }

                incrementY.ToList().ForEach(i => i.PositionY++);

                List<SnowFlake> dead = flakes.Where(f => f.PositionY > 16).ToList();
                dead.ForEach(d => flakes.Remove(d));

                var line1 = HelperMatriceListConvertor.ConvertToList(datas);

                _steps.ForEach(x => x.Apply(line1));

                Thread.Sleep(ModelHelper.period*2);
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

    public class SnowFlake
    {
        public int PositionX { get; set; } // de 0 a 39

        public int PositionY { get; set; } // de 0 a 7

        public int TTL { get; set; } // nombre de ligne sur lequel on a la trace entre 2 et 5


        public override string ToString()
        {
            return string.Format("X:{0}  -   Y:{1}  -   TTL:{2}", PositionX, PositionY, TTL);
        }

        private static Random randomX = new Random();
        private static Random randomTTL = new Random();

        public static SnowFlake BuildFlake(List<SnowFlake> l)
        {

            SnowFlake f = new SnowFlake();
            f.PositionY = 0;

            bool trouve = false;
            do
            {
                int x = randomX.Next(0, 39);
                var contains = l.Where(z => z.PositionX == x);
                if (!contains.Any())
                {
                    f.PositionX = x;
                    trouve = true;
                }

            } while (!trouve);

            f.TTL = randomTTL.Next(2, 5);
            return f;
        }
    }
}
