using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using LedGeekBox.Model.Scenario;
using LedGeekBox.Helper;

namespace LedGeekBox.Arduino
{

    public interface IArduino
    {
        //bool Init(string port, int rate);
        void Close();
        //void Write(Dictionary<int, List<byte>> datas);
        void Apply(List<bool[,]> datas);
    }


    public class ArduinoDriver : IArduino, IStep
    {
        private bool _havebeeninit = false;
        SerialPort serial;

        public bool Simulation
        {
            get; set;
        }

        //private bool Init(string port = "COM5", int rate = 115200)

        public string Port { get; set; }
        public int Rate { get; set; }

        public void Init()
        {
            if (Simulation)
            {
                return;
            }

            if (_havebeeninit == true)
            {
                if (serial != null)
                {
                    serial.Close();
                }
                //  return _havebeeninit;
            }
            serial = new SerialPort(Port, Rate);
            serial.Open();
            _havebeeninit = serial.IsOpen;
        }


        public void Close()
        {
            serial.Close();
            serial = null;
            _havebeeninit = false;
        }

        public void Apply(List<bool[,]> rawdatas)
        {
            if (Simulation)
            {
                return;
            }

            if (_havebeeninit == false)
            {
                Init();
            }

            Dictionary<int, List<int>> dico = new Dictionary<int, List<int>>();


            List<bool[,]> transposed = new List<bool[,]>();

            //TODO remplacer un for int i= 0  et pour les 5 premiers faires 90 et les 5 autres 270
            int indice = 1;
            foreach (var rawdata in rawdatas)
            {
                bool[,] t = new bool[8, 8];
                int x = rawdata.GetLength(0);

                if (indice > 5)
                {
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            t[i, j] = rawdata[x - 1 - j, i];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            t[i, j] = rawdata[j, x - 1 - i];
                        }
                    }
                }
                transposed.Add(t);
                indice++;
            }
            rawdatas = transposed;

            for (int index = 0; index < rawdatas.Count; index++)
            {
                bool[,] matrix = rawdatas[index];
                var data = HelperMatriceInteger.BuildList(matrix);

                dico.Add(index, data);
            }

            Write(dico);
        }


        private void Write(Dictionary<int, List<int>> datas)
        {
            string final = "1+";

            foreach (int index in datas.Keys)
            {
                string tmp = index.ToString("D2");

                foreach (int i in datas[index])
                {
                    tmp += '-' + i.ToString("D3");
                }
                final += tmp;
                if (index != (datas.Keys.Count - 1))
                {
                    final += "+";
                }
                if (index == 4)
                {
                    final += "2+";
                }
            }

            final = "A" + final + "B";
            byte[] buffer = Encoding.ASCII.GetBytes(final);

            serial.Write(buffer, 0, buffer.Length);
        }




    }
}
