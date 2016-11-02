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


    public class ArduinoDriver : IArduino , IStep
    {
        private bool _havebeeninit = false;
        SerialPort serial;

        public bool Simulation
        {
            get; set;
        }

        private  bool Init(string port = "COM4", int rate = 115200)
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

            if( Simulation)
            {
                return;
            }

            if (_havebeeninit == false)
            {
                Init();
            }

            Dictionary < int, List < int >> dico = new Dictionary<int, List<int>>();

            
            for (int index = 0; index < rawdatas.Count; index++)
            {
                bool[,] matrix = rawdatas[index];
                List<int> data = new List<int>();

                for (int i = 0; i < 8; i ++)
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



        private void Write(Dictionary<int, List<int>> datas , string prefix)
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
                if (index != (datas.Keys.Count-1))
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
