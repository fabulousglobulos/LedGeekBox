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
using LedGeekBox.Model;
using LedGeekBox.Model.Scenario;
using LedGeekBox.View;

namespace LedGeekBox.ViewModel
{
    public class ViewModelMain : INotifyPropertyChanged
    {


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


        private string _scenariosList;

        public string Scenarios
        {
            get { return _scenariosList; }
            set
            {
                if (value != _scenariosList)
                {
                    _scenariosList = value;
                    OnPropertyChanged("Scenarios");
                }
            }
        }

        public ICommand XDisplayCommand { get; set; }
        public ICommand DisplayCustomTextCommand { get; set; }
        public ICommand DisplayHourCommand { get; set; }
        public ICommand ScenarioCommand { get; set; }

        private bool _isChecked1;

        public bool Reverse1
        {
            get { return _isChecked1; }
            set
            {
                if (value != _isChecked1)
                {
                    _isChecked1 = value;
                    OnPropertyChanged("Reverse1");
                }
            }
        }


        private bool _isChecked2;
        public bool Reverse2
        {
            get { return _isChecked2; }
            set
            {
                if (value != _isChecked2)
                {
                    _isChecked2 = value;
                    OnPropertyChanged("Reverse2");
                }
            }
        }

        private ViewModelMaxLayout vmLayout;

        public ViewModelMain(ViewModelMaxLayout vm)
        {
            vmLayout = vm;
            XDisplayCommand = new RelayCommand(o => XDisplayClick());
            DisplayCustomTextCommand = new RelayCommand(o => DisplayCustomTextClick());
            DisplayHourCommand = new RelayCommand(o => DisplayHourClick());
            ScenarioCommand = new RelayCommand(o => ScenarioClick());
            Line1 = "Hello World ! 123456";
            Line2 = "@coucou #ABC";

            Reverse2 = true;
            var a = Helper.Get("a");//force to load setup

            Scenarios = "HOUR()" + Environment.NewLine;
            Scenarios += "TEXT(msg1=#coucou c'est nous!;msg2=C0mment c@ v@ ? )" + Environment.NewLine;
            Scenarios += "HOUR()" + Environment.NewLine;
            Scenarios += "TEXT(msg1=prout;msg2=123456789 ? )" ;
        }

        bool x = true;

        private void ScenarioClick()
        {
            Thread t = new Thread(DoScenario);
            t.Start();
        }


        private void DoScenario()
        {
            //List<IScenario> scenarios = new List<IScenario>();

            //scenarios.Add(new HourScenario());
            //scenarios.Add(new TextScenario());
            //scenarios.Add(new HourScenario());
            List<IScenario> scenarios = ScenariosFactory.Build(Scenarios);

            foreach (var scenario in scenarios)
            {
                int wait = scenario.Start(vmLayout);
                Thread.Sleep(wait);
                scenario.Stop();
            }
        }

        private void DisplayHourClick()
        {
            string hour = DateTime.Now.ToString("hh:mm:ss");
            string date = DateTime.Now.ToString("dd.MM.yy");

            ModelHelper.RenderingGeneric(new ThreadObject { WhatToWrite = hour, ViewModel = vmLayout, FirstLine = true });
            ModelHelper.RenderingGeneric(new ThreadObject { WhatToWrite = date, ViewModel = vmLayout, FirstLine = false });
        }


        private void XDisplayClick()
        {
            List<bool[,]> dico1 = new List<bool[,]>();
            dico1.Add(x ? Definition.un : Definition.croix);
            dico1.Add(x ? Definition.deux : Definition.croix);
            dico1.Add(x ? Definition.trois : Definition.croix);
            dico1.Add(x ? Definition.quatre : Definition.croix);
            dico1.Add(x ? Definition.cinq : Definition.croix);
            vmLayout.Apply(dico1, true);

            List<bool[,]> dico2 = new List<bool[,]>();
            dico2.Add(x ? Definition.six : Definition.croix);
            dico2.Add(x ? Definition.sept : Definition.croix);
            dico2.Add(x ? Definition.huit : Definition.croix);
            dico2.Add(x ? Definition.neuf : Definition.croix);
            dico2.Add(x ? Definition.zero : Definition.croix);
            vmLayout.Apply(dico2, false);

            x = !x;
        }


        private void DisplayCustomTextClick()
        {
            Thread t1 = new Thread(ModelHelper.RenderingGeneric);
            t1.Start(new ThreadObject { WhatToWrite = Line1, ViewModel = vmLayout, FirstLine = true, Reverse = Reverse1 });


            Thread t2 = new Thread(ModelHelper.RenderingGeneric);
            t2.Start(new ThreadObject { WhatToWrite = Line2, ViewModel = vmLayout, FirstLine = false, Reverse = Reverse2 });
        }




        //private void RenderingGeneric(object param)
        //{
        //    ThreadObject typedParam = param as ThreadObject;
        //    if (typedParam.Reverse)
        //    {
        //        Model.RenderingReverse(typedParam.WhatToWrite, typedParam.ViewModel, typedParam.FirstLine);
        //    }
        //    else
        //    {
        //        Model.Rendering(typedParam.WhatToWrite, typedParam.ViewModel, typedParam.FirstLine);
        //    }
        //}


    }

}

