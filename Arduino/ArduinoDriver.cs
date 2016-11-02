using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using LedGeekBox.Model.Scenario;

namespace LedGeekBox.Arduino
{

    public interface IArduino
    {
        //bool Init(string port, int rate);
        void Close();
        //void Write(Dictionary<int, List<byte>> datas);
        void Apply(List<bool[,]> datas, bool firstline);
    }


    public class ArduinoDriver : IArduino, IStep
    {
        private bool _havebeeninit = false;
        SerialPort serial;

        public bool Simulation
        {
            get; set;
        }

        private bool Init(string port = "COM4", int rate = 115200)
        {
            if (Simulation)
            {
                return true;
            }

            if (_havebeeninit == true)
            {
                return _havebeeninit;
            }
            serial = new SerialPort(port, rate);
            serial.Open();
            _havebeeninit = serial.IsOpen;
            return _havebeeninit;
        }


        public void Close()
        {
            serial.Close();
            serial = null;
            _havebeeninit = false;
        }

        public void Apply(List<bool[,]> rawdatas, bool firstrow)
        {
            if (!firstrow)
            {
                return;
            }

            if (Simulation)
            {
                return;
            }

            if (_havebeeninit == false)
            {
                Init();
            }

            Dictionary<int, List<int>> dico = new Dictionary<int, List<int>>();

            if (firstrow)
            {
                List<bool[,]> transposed = new List<bool[,]>();

                foreach (var rawdata in rawdatas)
                {
                    bool[,] t = new bool[8, 8];
                    int x = rawdata.GetLength(0);

                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            t[i, j] = rawdata[ x - 1 - j,i];
                        }
                    }

                    //t[0, 0] = rawdata[7, 0];
                    //t[1, 0] = rawdata[6, 0];
                    //t[2, 0] = rawdata[5, 0];
                    //t[3, 0] = rawdata[4, 0];
                    //t[4, 0] = rawdata[3, 0];
                    //t[5, 0] = rawdata[2, 0];
                    //t[6, 0] = rawdata[1, 0];
                    //t[7, 0] = rawdata[0, 0];

                    //t[0, 1] = rawdata[7, 1];
                    //t[1, 1] = rawdata[6, 1];
                    //t[2, 1] = rawdata[5, 1];
                    //t[3, 1] = rawdata[4, 1];
                    //t[4, 1] = rawdata[3, 1];
                    //t[5, 1] = rawdata[2, 1];
                    //t[6, 1] = rawdata[1, 1];
                    //t[7, 1] = rawdata[0, 1];


                    //t[0, 2] = rawdata[7, 2];
                    //t[1, 2] = rawdata[6, 2];
                    //t[2, 2] = rawdata[5, 2];
                    //t[3, 2] = rawdata[4, 2];
                    //t[4, 2] = rawdata[3, 2];
                    //t[5, 2] = rawdata[2, 2];
                    //t[6, 2] = rawdata[1, 2];
                    //t[7, 2] = rawdata[0, 2];


                    //t[0, 3] = rawdata[7, 3];
                    //t[1, 3] = rawdata[6, 3];
                    //t[2, 3] = rawdata[5, 3];
                    //t[3, 3] = rawdata[4, 3];
                    //t[4, 3] = rawdata[3, 3];
                    //t[5, 3] = rawdata[2, 3];
                    //t[6, 3] = rawdata[1, 3];
                    //t[7, 3] = rawdata[0, 3];


                    //t[0, 4] = rawdata[7, 4];
                    //t[1, 4] = rawdata[6, 4];
                    //t[2, 4] = rawdata[5, 4];
                    //t[3, 4] = rawdata[4, 4];
                    //t[4, 4] = rawdata[3, 4];
                    //t[5, 4] = rawdata[2, 4];
                    //t[6, 4] = rawdata[1, 4];
                    //t[7, 4] = rawdata[0, 4];


                    //t[0, 5 ] = rawdata[7, 5];
                    //t[1, 5 ] = rawdata[6, 5];
                    //t[2, 5 ] = rawdata[5, 5];
                    //t[3, 5 ] = rawdata[4, 5];
                    //t[4, 5 ] = rawdata[3, 5];
                    //t[5, 5 ] = rawdata[2, 5];
                    //t[6, 5 ] = rawdata[1, 5];
                    //t[7, 5 ] = rawdata[0, 5];


                    //t[0, 6] = rawdata[7, 6];
                    //t[1, 6] = rawdata[6, 6];
                    //t[2, 6] = rawdata[5, 6];
                    //t[3, 6] = rawdata[4, 6];
                    //t[4, 6] = rawdata[3, 6];
                    //t[5, 6] = rawdata[2, 6];
                    //t[6, 6] = rawdata[1, 6];
                    //t[7, 6] = rawdata[0, 6];


                    //t[0, 7] = rawdata[7, 7];
                    //t[1, 7] = rawdata[6, 7];
                    //t[2, 7] = rawdata[5, 7];
                    //t[3, 7] = rawdata[4, 7];
                    //t[4, 7] = rawdata[3, 7];
                    //t[5, 7] = rawdata[2, 7];
                    //t[6, 7] = rawdata[1, 7];
                    //t[7, 7] = rawdata[0, 7];

                    //for (int i = 0; i < x; i++)
                    //{
                    //    for (int j = 0; j < y; j++)
                    //    {

                    //    }
                    //}


                    transposed.Add(t);
                }
                rawdatas = transposed;

            }

            for (int index = 0; index < rawdatas.Count; index++)
            {
                bool[,] matrix = rawdatas[index];
                List<int> data = new List<int>();

                for (int i = 0; i < 8; i++)
                {
                    int number = 0;

                    bool a = matrix[i, 0]; //bit de poids fort ! (a gauche)
                    bool b = matrix[i, 1];
                    bool c = matrix[i, 2];
                    bool d = matrix[i, 3];

                    bool e = matrix[i, 4];
                    bool f = matrix[i, 5];
                    bool g = matrix[i, 6];
                    bool h = matrix[i, 7];//bit de poids faible ! (a droite)
                    if (a)
                    {
                        number += 128;
                    }
                    if (b)
                    {
                        number += 64;
                    }
                    if (c)
                    {
                        number += 32;
                    }
                    if (d)
                    {
                        number += 16;
                    }

                    if (e)
                    {
                        number += 8;
                    }
                    if (f)
                    {
                        number += 4;
                    }
                    if (g)
                    {
                        number += 2;
                    }
                    if (h)
                    {
                        number += 1;
                    }
                    data.Add(number);
                }

                dico.Add(index, data);
            }

            Write(dico, firstrow ? "1+" : "2+");
        }



        private void Write(Dictionary<int, List<int>> datas, string prefix)
        {

            string final = prefix;


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
            }

            final = "A" + final + "B";
            byte[] buffer = Encoding.ASCII.GetBytes(final);

            serial.Write(buffer, 0, buffer.Length);
        }


        //public string HelloWorld()
        //{
        //    try
        //    {
        //        //The below setting are for the Hello handshake
        //        byte[] buffer = new byte[5];
        //        buffer[0] = Convert.ToByte(16);
        //        buffer[1] = Convert.ToByte(128);
        //        buffer[2] = Convert.ToByte(0);
        //        buffer[3] = Convert.ToByte(0);
        //        buffer[4] = Convert.ToByte(4);
        //        int intReturnASCII = 0;
        //        char charReturnValue = (Char)intReturnASCII;

        //        serial.Write(buffer, 0, 5);
        //        Thread.Sleep(1000);
        //        int count = serial.BytesToRead;
        //        string returnMessage = "";
        //        while (count > 0)
        //        {
        //            intReturnASCII = serial.ReadByte();
        //            returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
        //            count--;
        //        }

        //        return returnMessage;

        //    }
        //    catch (Exception e)
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
