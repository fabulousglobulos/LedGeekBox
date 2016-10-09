using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Size = System.Windows.Size;


namespace LedGeekBox
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelMax7219 vm1 = null;
        ViewModelMax7219 vm2 = null;
        ViewModelMax7219 vm3 = null;
        ViewModelMax7219 vm4 = null;
        ViewModelMax7219 vm5 = null;
        ViewModelMax7219 vm6 = null;
        ViewModelMax7219 vm7 = null;
        ViewModelMax7219 vm8 = null;
        ViewModelMax7219 vm9 = null;
        ViewModelMax7219 vm10 = null;

        public MainWindow()
        {
            InitializeComponent();

            vm1 = this.max1.DataContext as ViewModelMax7219;
            vm2 = this.max2.DataContext as ViewModelMax7219;
            vm3 = this.max3.DataContext as ViewModelMax7219;
            vm4 = this.max4.DataContext as ViewModelMax7219;
            vm5 = this.max5.DataContext as ViewModelMax7219;
            vm6 = this.max6.DataContext as ViewModelMax7219;
            vm7 = this.max7.DataContext as ViewModelMax7219;
            vm8 = this.max8.DataContext as ViewModelMax7219;
            vm9 = this.max9.DataContext as ViewModelMax7219;
            vm10 = this.max10.DataContext as ViewModelMax7219;
        }

        bool x = true;

        private void log(List<bool[,]> msg)
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


        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            int totallenght = 0;
            List<bool[,]> msg = message.Text.ToList().Select(x =>
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

            // int offsetdynamic = 0;
            int offsetstatic = totallenght - 5 * 8;


            for (int o = 0; o <= offsetstatic; o++)
            {




                List<bool[,]> z = new List<bool[,]>();

                int index = 0;
                int smallindex = 0;
                bool[,] current = new bool[8, 8];
                // for (int i = 0; i < totallenght; i++)

                for (int i = (0+ o); i < (5*8+o); i++)
                {
                    index = i;

                   // if (index == ((5 * 8) + 1)) // on a que 5 affichagse , donc ca ne sert a rien
                   if(index > totallenght+1) //on a depasser la taille total du message le message !
                    {
                        break;
                    }

                    if (smallindex > 7) //on cherche a remplir uniquement un matrix, sion passe au suivant
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



                    if ((index == ((5 * 8) - 1)+ o) && (smallindex != 1))
                    {
                        z.Add(current);
                    }

                }


                if (z.Count > 0)
                {
                    vm1.Apply(z[0]);
                }
                else
                {
                    vm1.Apply(Helper.EmptyMatrix);
                }

                if (z.Count > 1)
                {
                    vm2.Apply(z[1]);
                }
                else
                {
                    vm2.Apply(Helper.EmptyMatrix);
                }

                if (z.Count > 2)
                {
                    vm3.Apply(z[2]);
                }
                else
                {
                    vm3.Apply(Helper.EmptyMatrix);
                }

                if (z.Count > 3)
                {
                    vm4.Apply(z[3]);
                }
                else
                {
                    vm4.Apply(Helper.EmptyMatrix);
                }


                if (z.Count > 4)
                {
                    vm5.Apply(z[4]);
                }
                else
                {
                    vm5.Apply(Helper.EmptyMatrix);
                }

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                          new Action(delegate { }));
                System.Threading.Thread.Sleep(200);

            }

        }



        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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




            bool[,] cing = new bool[8, 8]
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


            if (x)
            {
                vm1.Apply(un);
                vm2.Apply(deux);
                vm3.Apply(trois);

                vm4.Apply(quatre);
                vm5.Apply(cing);
                vm6.Apply(six);


                vm7.Apply(sept);
                vm8.Apply(huit);
                vm9.Apply(neuf);

                vm10.Apply(zero);
            }
            else
            {
                vm1.Apply(croix);
                vm2.Apply(croix);
                vm3.Apply(croix);

                vm4.Apply(croix);
                vm5.Apply(croix);
                vm6.Apply(croix);

                vm7.Apply(croix);
                vm8.Apply(croix);
                vm9.Apply(croix);

                vm10.Apply(croix);
            }
            x = !x;
        }
    }





}
