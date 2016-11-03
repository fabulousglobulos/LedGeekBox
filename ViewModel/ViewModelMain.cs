using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using LedGeekBox.Arduino;
using LedGeekBox.Model;
using LedGeekBox.Model.Scenario;
using LedGeekBox.View;
using Microsoft.Win32;

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

        private bool _isSimulation;

        public bool IsSimulation
        {
            get { return _isSimulation; }
            set
            {
                if (value != _isSimulation)
                {
                    _isSimulation = value;
                    arduino.Simulation = value;
                    OnPropertyChanged("IsSimulation");
                }
            }
        }



        public ICommand XDisplayCommand { get; set; }
        public ICommand DisplayCustomTextCommand { get; set; }
        public ICommand DisplayHourCommand { get; set; }
        public ICommand ScenarioCommand { get; set; }
        public ICommand ImportCommand { get; set; }

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

        //private ViewModelMaxLayout vmLayout;
        //private ArduinoDriver arduino;
        private List<IStep> steps = null;

        ArduinoDriver arduino = new ArduinoDriver();

        public ViewModelMain(ViewModelMaxLayout vm)
        {
            steps = new List<IStep> { vm, arduino };
            //vmLayout = vm;
            //arduino = arduinoController;
            XDisplayCommand = new RelayCommand(o => XDisplayClick());
            DisplayCustomTextCommand = new RelayCommand(o => DisplayCustomTextClick());
            DisplayHourCommand = new RelayCommand(o => DisplayHourClick());
            ScenarioCommand = new RelayCommand(o => ScenarioClick());
            ImportCommand = new RelayCommand(o => ImportClick());


            Line1 = "Hello World ! 123456";
            Line2 = "@coucou #ABC";
            IsSimulation = false;
            Reverse2 = true;
            var a = Helper.Get("a");//force to load setup

            Scenarios = "HOUR()" + Environment.NewLine;
            Scenarios += "TEXT(msg1=#coucou c'est nous!;msg2=C0mment c@ v@ ? )" + Environment.NewLine;
            Scenarios += "HOUR()" + Environment.NewLine;
            Scenarios += "TEXT(msg1=prout;msg2=123456789 ? )" + Environment.NewLine;
            Scenarios += "CLEAR()" + Environment.NewLine;
        }

        bool x = true;

        private void ImportClick()
        {

            OpenFileDialog f = new OpenFileDialog();
            var result = f.ShowDialog();
            string fullpath = @"e:\g.png";
            if (result == false)
            {
                return;
            }
            fullpath = f.FileName;


            var original = Image.FromFile(fullpath);
            original = ResizePicture(original, 40, 16);
            Bitmap bmp = new Bitmap(original);
            var rectangle = new Rectangle(0, 0, original.Width, original.Height);
            var bmp1bpp = bmp.Clone(rectangle, PixelFormat.Format1bppIndexed);
            bmp1bpp.Save(@"e:\image.bmp");
            bool[,] datas = new bool[40, 16];
            for (int i = 0; i < bmp1bpp.Width; i++)
            {
                string line = string.Empty;
                for (int j = 0; j < bmp1bpp.Height; j++)
                {
                    Color pixel = bmp1bpp.GetPixel(i, j);
                    bool r = !((pixel.R == Color.White.R) && (pixel.G == Color.White.G) && (pixel.B == Color.White.B));
                    line += r ? "x" : "_";
                    datas[i, j] = r;
                }
                line += Environment.NewLine;
            }
            ModelHelper.log(datas);

            var line1 = ConverToList(datas);
            steps.ForEach(x => x.Apply(line1));
            ModelHelper.log(line1);

            //var line2 = ConverToList(datas, false);
            //steps.ForEach(x => x.Apply(line2, false));
            //ModelHelper.log(line2);
        }

        List<bool[,]> ConverToList(bool[,] datas)
        {
            // int inf = firstline ? 0 : 8;

            List<bool[,]> l = new List<bool[,]>();

            for (int i = 0; i < 5; i++)
            {
                    bool[,] x = new bool[8, 8];
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            x[k, j] = datas[i * 8 + j, k]; //TODO verifier // int inf = firstline ? 0 : 8;
                        }
                    }
                    l.Add(x);
            }

            for (int i = 0; i < 5; i++)
            {
                bool[,] x2 = new bool[8, 8];
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        x2[k, j] = datas[i * 8 + j, 8 + k]; //TODO verifier // int inf = firstline ? 0 : 8;
                    }
                }
                l.Add(x2);
            }

            return l;
        }


        private Bitmap ResizePicture(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.HorizontalResolution, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

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
                int wait = scenario.Start(steps);
                Thread.Sleep(wait);
                scenario.Stop();
            }
        }

        private void DisplayHourClick()
        {
            string hour = DateTime.Now.ToString("hh:mm:ss");
            string date = DateTime.Now.ToString("dd.MM.yy");

            ModelHelper.RenderingGeneric(new ThreadObject { WhatToWrite1 = hour, WhatToWrite2 = date, Steps = steps, });
        }


        private void XDisplayClick()
        {
            List<bool[,]> dico1 = new List<bool[,]>();
            dico1.Add(x ? Definition.un : Definition.croix);
            dico1.Add(x ? Definition.deux : Definition.croix);
            dico1.Add(x ? Definition.trois : Definition.croix);
            dico1.Add(x ? Definition.quatre : Definition.croix);
            dico1.Add(x ? Definition.cinq : Definition.croix);

            dico1.Add(x ? Definition.six : Definition.croix);
            dico1.Add(x ? Definition.sept : Definition.croix);
            dico1.Add(x ? Definition.huit : Definition.croix);
            dico1.Add(x ? Definition.neuf : Definition.croix);
            dico1.Add(x ? Definition.zero : Definition.croix);

            steps.ForEach(x => x.Apply(dico1));

            x = !x;
        }


        private void DisplayCustomTextClick()
        {
            Thread t1 = new Thread(ModelHelper.RenderingGeneric);
            t1.Start(new ThreadObject { WhatToWrite1 = Line1, WhatToWrite2 = Line2, Steps = steps, Reverse = Reverse1 });
        }

    }

}

