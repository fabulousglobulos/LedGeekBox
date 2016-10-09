using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace LedGeekBox
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        private readonly static int period = 200;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                var args = new PropertyChangedEventArgs(property);
                handlers(this, args);
            }
        }


        private string _line1;

        public string Line1
        {
            get { return _line1; }
            set
            {
                if (value != _line1)
                {
                    _line1 = value;
                    OnPropertyChanged("Line1");
                }
            }
        }

        private string _line2;

        public string Line2
        {
            get { return _line2; }
            set
            {
                if (value != _line2)
                {
                    _line2 = value;
                    OnPropertyChanged("Line2");
                }
            }
        }

        public ICommand XDisplayCommand { get; set; }
        public ICommand DisplayCustomTextCommand { get; set; }

        private ViewModelMaxLayout vmLayout;

        public ViewModelMain(ViewModelMaxLayout vm)
        {
            vmLayout = vm;
            XDisplayCommand = new RelayCommand(o => XDisplayClick());
            DisplayCustomTextCommand = new RelayCommand(o => DisplayCustomTextClick());
            Line1 = "Hello World ! 123456";
            Line2 = "@coucou #ABC";
            var a = Helper.Get("a");//force to load setup
        }

        bool x = true;

        private void XDisplayClick()
        {
            #region mapping
            bool[,] zero = new bool[8, 8]
          {
                  {false, false, false, false, false, false, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, false, false, false, false, false, false},
          };

            bool[,] un = new bool[8, 8]
            {
                  {false, false, false, false, false, false, false, false},
                  {false, false, false, false, true, false, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, true, false, true, false, false, false},
                  {false, false, false, false, true, false, false, false},
                  {false, false, false, false, true, false, false, false},
                  {false, false, false, false, true, false, false, false},
                  {false, false, false, false, false, false, false, false}
            };


            bool[,] deux = new bool[8, 8]
             {
                  { false, false, false, false, false, false, false, false },
                  { false, false, true, true, true, false, false, false},
                  { false, false, false, false, false, true, false, false},
                  { false, false, false, true, true, true, false, false},
                  { false, false, true, false, false, false, false, false},
                  { false, false, true, false, false, false, false, false},
                  { false, false, true, true, true, true, false, false},
                  { false, false, false, false, false, false, false, false}
             };


            bool[,] trois = new bool[8, 8]
             {
                  { false, false, false, false, false, false, false, false },
                  { false, false, true, true, true, false, false, false },
                  { false, false, false, false, false, true, false, false },
                  { false, false, false, true, true, true, false, false },
                  { false, false, false, false, false, true, false, false },
                  { false, false, false, false, false, true, false, false },
                  { false, false, true, true, true, false, false, false },
                  { false, false, false, false, false, false, false, false },
             };



            bool[,] quatre = new bool[8, 8]
             {
                  { false, false, false, false, false, false, false, false },
                  { false, false, false, false, true, true, false, false },
                  { false, false, false, true, false, true, false, false },
                  { false, false, true, false, false, true, false, false },
                  { false, false, true, true, true, true, false, false },
                  { false, false, false, false, false, true, false, false },
                  { false, false, false, false, false, true, false, false},
                  { false, false, false, false, false, false, false, false },
             };




            bool[,] cinq = new bool[8, 8]
             {
                  { false, false, false, false, false, false, false, false },
                  { false, false, true, true, true, true, false, false },
                  { false, false, true, false, false, false, false, false },
                  { false, false, true, true, true, false, false, false },
                  { false, false, false, false, false, true, false, false },
                  { false, false, false, false, false, true, false, false },
                  { false, false, true, true, true, false, false, false},
                  { false, false, false, false, false, false, false, false },
             };



            bool[,] six = new bool[8, 8]
             {
                  { false, false, false, false, false, false, false, false },
                  { false, false, false, true, true, true, false, false },
                  { false, false, true, false, false, false, false, false },
                  { false, false, true, false, false, false, false, false },
                  { false, false, true, true, true, false, false, false },
                  { false, false, true, false, false, true, false, false },
                  { false, false, false, true, true, true, false, false},
                  { false, false, false, false, false, false, false, false },
             };


            bool[,] sept = new bool[8, 8]
             {
                  { false, false, false, false, false, false, false, false },
                  { false, false, true, true, true, false, false, false },
                  { false, false, false, false, true, false, false, false },
                  { false, false, false, false, true, false, false, false },
                  { false, false, false, true, true, false, false, false },
                  { false, false, false, false, true, false, false, false },
                  { false, false, false, false, true, false, false, false },
                  { false, false, false, false, false, false, false, false },
             };

            bool[,] huit = new bool[8, 8]
            {
                  {false, false, false, false, false, false, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, false, false, false, false, false, false},
            };

            bool[,] neuf = new bool[8, 8]
            {
                  {false, false, false, false, false, false, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, true, false, false, true, false, false},
                  {false, false, false, true, true, false, false, false},
                  {false, false, false, false, false, true, false, false},
                  {false, false, true, true, true, true, false, false},
                  {false, false, false, false, false, false, false, false},
            };





            bool[,] croix = new bool[8, 8]
            {
                      { true, false, false, false, false, false, false, true },
                      { false, true, false, false, false, false, true, false },
                      { false, false, true, false, false, true, false, false },
                      { false, false, false, true, true, false, false, false },
                      { false, false, false, true, true, false, false, false },
                      { false, false, true, false, false, true, false, false },
                      { false, true, false, false, false, false, true, false },
                      { true, false, false, false, false, false, false, true },
            };
            #endregion mapping

            List<bool[,]> dico1 = new List<bool[,]>();

            dico1.Add(x ? un : croix);
            dico1.Add(x ? deux : croix);
            dico1.Add(x ? trois : croix);
            dico1.Add(x ? quatre : croix);
            dico1.Add(x ? cinq : croix);

            vmLayout.Apply1(dico1);

            List<bool[,]> dico2 = new List<bool[,]>();
            dico2.Add(x ? six : croix);
            dico2.Add(x ? sept : croix);
            dico2.Add(x ? huit : croix);
            dico2.Add(x ? neuf : croix);
            dico2.Add(x ? zero : croix);
            vmLayout.Apply2(dico2);

           
            x = !x;
        }

        private static void log(List<bool[,]> msg)
        {
            string line1 = "";
            string line2 = "";
            string line3 = "";
            string line4 = "";
            string line5 = "";
            string line6 = "";
            string line7 = "";
            string line8 = "";

            foreach (bool[,] c in msg)
            {
                for (int i = 0; i < c.GetLength(1); i++)
                {
                    line1 += c[0, i] ? "#" : "_";
                    line2 += c[1, i] ? "#" : "_";
                    line3 += c[2, i] ? "#" : "_";
                    line4 += c[3, i] ? "#" : "_";
                    line5 += c[4, i] ? "#" : "_";
                    line6 += c[5, i] ? "#" : "_";
                    line7 += c[6, i] ? "#" : "_";
                    line8 += c[7, i] ? "#" : "_";
                }
                line1 += " ";
                line2 += " ";
                line3 += " ";
                line4 += " ";
                line5 += " ";
                line6 += " ";
                line7 += " ";
                line8 += " ";
            }
        }

        private void DisplayCustomTextClick()
        {
            Thread t1 = new Thread(RenderingGeneric);
            t1.Start(new ThreadObject { WhatToWrite = Line1, ViewModel = vmLayout, FirstLine = true });


            Thread t2 = new Thread(RenderingGeneric);
            t2.Start(new ThreadObject { WhatToWrite = Line2, ViewModel = vmLayout, FirstLine = false });
        }

        public class ThreadObject
        {
            public string WhatToWrite { get; set; }
            public ViewModelMaxLayout ViewModel { get; set; }
            public bool FirstLine { get; set; }
        }


        private void RenderingGeneric(object param)
        {
            ThreadObject typedParam = param as ThreadObject;
            Rendering(typedParam.WhatToWrite, typedParam.ViewModel, typedParam.FirstLine);
        }

        private static void Rendering(string whatToWrite, ViewModelMaxLayout vm, bool firstline)
        {
            int totallenght = 0;
            List<bool[,]> msg = whatToWrite.ToList().Select(x =>
            {
                var y = Helper.Get(x.ToString());
                totallenght += y.GetLength(1);
                return y;
            }).ToList();

            log(msg);

            bool[,] mainmessage = new bool[8, totallenght];
            int localcursor = 0;
            foreach (bool[,] x in msg)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    mainmessage[0, localcursor] = x[0, j];
                    mainmessage[1, localcursor] = x[1, j];
                    mainmessage[2, localcursor] = x[2, j];
                    mainmessage[3, localcursor] = x[3, j];
                    mainmessage[4, localcursor] = x[4, j];
                    mainmessage[5, localcursor] = x[5, j];
                    mainmessage[6, localcursor] = x[6, j];
                    mainmessage[7, localcursor] = x[7, j];
                    localcursor++;
                }
            }

            int offsetstatic = totallenght - 5 * 8;
            if (offsetstatic < 0)
            {
                offsetstatic = 0;
            }

            Thread.Sleep(period*2);

            for (int o = 0; o <= offsetstatic; o++)
            {
                List<bool[,]> z = new List<bool[,]>();

                int index = 0;
                int smallindex = 0;
                bool[,] current = new bool[8, 8];

                for (int i = (0 + o); i < (5 * 8 + o); i++)
                {
                    index = i;

                    if (index > totallenght + 1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex > 7) //on cherche a remplir uniquement une matrix, sinon on passe au suivant
                    {
                        z.Add(current);
                        current = new bool[8, 8];
                        smallindex = 0;
                    }
                    current[0, smallindex] = mainmessage[0, index];
                    current[1, smallindex] = mainmessage[1, index];
                    current[2, smallindex] = mainmessage[2, index];
                    current[3, smallindex] = mainmessage[3, index];

                    current[4, smallindex] = mainmessage[4, index];
                    current[5, smallindex] = mainmessage[5, index];
                    current[6, smallindex] = mainmessage[6, index];
                    current[7, smallindex] = mainmessage[7, index];

                    smallindex++;

                    if ((index == ((5 * 8) - 1) + o) && (smallindex != 1))
                    {
                        z.Add(current);
                    }
                }

                List<bool[,]> dico = new List<bool[,]>();
                dico.Add(z.Count > 0 ? z[0] : Helper.EmptyMatrix);
                dico.Add(z.Count > 1 ? z[1] : Helper.EmptyMatrix);
                dico.Add(z.Count > 2 ? z[2] : Helper.EmptyMatrix);
                dico.Add(z.Count > 3 ? z[3] : Helper.EmptyMatrix);
                dico.Add(z.Count > 4 ? z[4] : Helper.EmptyMatrix);

                if (firstline)
                {
                    vm.Apply1(dico);
                }
                else
                {
                    vm.Apply2(dico);
                }

                Thread.Sleep(period);
            }
        }
    }

}

