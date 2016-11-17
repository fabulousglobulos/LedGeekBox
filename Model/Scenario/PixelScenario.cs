using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LedGeekBox.ViewModel;
using LedGeekBox.Helper;

namespace LedGeekBox.Model.Scenario
{
    public class PixelScenario : IScenario
    {
        public PixelScenario()
        {
        }

        List<IStep> _steps;
        Thread t1 = null;

        public int Start(List<IStep> steps)
        {
            _steps = steps;
            t1 = new Thread(Render);
            t1.Start();

            return ModelHelper.period * (40 * 16 + 3)/2;
        }

        private static Random randomX = new Random();
        private static Random randomTTL = new Random();


        private bool[,] BuildMatrice(Dictionary<int, KeyValuePair<int, int>> dico)
        {
            bool[,] datas = new bool[40, 16];

            foreach (var data in dico.Values)
            {
                datas[data.Key, data.Value] = true;
            }
            return datas;
        }


        public void Render()
        {
            //bool[,] datas = new bool[40, 16];
            Dictionary<int, KeyValuePair<int, int>> dico = new Dictionary<int, KeyValuePair<int, int>>();
            int id = 1;
            for (int j = 0; j < 16; j++)
            {
                for (int i = 0; i < 40; i++)
                {
                    dico.Add(id, new KeyValuePair<int, int>(i, j));
                    id++;
                }
            }
            var all = HelperMatriceListConvertor.ConvertToList(BuildMatrice(dico));
            _steps.ForEach(x => x.Apply(all));




            for (int cycle = 0; cycle < 40 * 16/2; cycle++)
            {
                int x1 = FindNewOne(dico);
                if( x1>0)
                dico.Remove(x1);
                
                int x2  = FindNewOne(dico);
                if (x2 > 0)
                    dico.Remove(x2);

                int x3 = FindNewOne(dico);
                if (x3 > 0)
                    dico.Remove(x3);

                all = HelperMatriceListConvertor.ConvertToList(BuildMatrice(dico));
                _steps.ForEach(s => s.Apply(all));

                Thread.Sleep(ModelHelper.period);

                if (dico.Count == 0)
                {
                    continue;
                }
            }
        }


        private int FindNewOne(Dictionary<int, KeyValuePair<int, int>> dico)
        {
            bool trouve1 = false;
            int cnt = 0;
            int x1 = -1;

            if (dico == null || dico.Count == 0)
            {
                return x1;
            }

            if (dico.Count <= 5)
            {
                return dico.First().Key;
            }

            do
            {
                x1 = randomX.Next(1, 16 * 40);
                if (dico.ContainsKey(x1) || (cnt > 30))
                {
                    trouve1 = true;
                }
                cnt++;
            } while (!trouve1);

            return x1;
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
