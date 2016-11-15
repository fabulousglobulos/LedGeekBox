using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;
using LedGeekBox.Arduino;
using LedGeekBox.View;
using LedGeekBox.Model;

namespace LedGeekBox.ViewModel
{
    public class binderClass
    {
        //  public string imageLocation { get; set; }
        public List<bool[,]> rawData { get; set; }

        public BitmapImage imageSource { get; set; }
    }


    public class ViewModelDesignEditor : INotifyPropertyChanged
    {
        public ObservableCollection<binderClass> Datas { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                var args = new PropertyChangedEventArgs(property);
                handlers(this, args);
            }
        }


        public ICommand ClearCommand { get; set; }
        public ICommand Forwar2ArduinoCommand { get; set; }
        public ICommand InvertCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        ViewModelMaxLayout _vmlayout;
        ArduinoDriver arduino;
        public DesignEditor view  { get; set; }

        public ViewModelDesignEditor(ViewModelMaxLayout vmlayout, ArduinoDriver arduinoDriver)
        {
            _vmlayout = vmlayout;
            arduino = arduinoDriver;
            ClearCommand = new RelayCommand(o => ClearClick());
            Forwar2ArduinoCommand = new RelayCommand(c => Forwar2ArduinoClick());
            InvertCommand = new RelayCommand(x => InvertClick());
            SaveCommand = new RelayCommand(s => SaveToFile());
            LoadCommand = new RelayCommand(l => LoadClick());

            Datas = new ObservableCollection<binderClass>();
        }

        public List<bool[,]> Read()
        {
            return _vmlayout.ReadScreen();
        }

        public void InvertClick()
        {
            var screen = _vmlayout.ReadScreen();

            List<bool[,]> datas = new List<bool[,]>();

            foreach (var s in screen)
            {
                bool[,] newX = new bool[Definition.Number_Led_X_total, Definition.Number_Led_Y_total];
                int x = s.GetLength(0);
                int y = s.GetLength(1);

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        newX[i, j] = !s[i, j];
                    }
                }
                datas.Add(newX);
            }
            _vmlayout.Apply(datas);
        }

        public void ClearClick()
        {
            var emptys = new List<bool[,]>
            {
                Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty,
                Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty, Definition.Empty
            };

            _vmlayout.Apply(emptys);
        }

        public void Forwar2ArduinoClick()
        {
            var result = _vmlayout.ReadScreen();
            arduino.Apply(result);
        }

        string file = @"e:\file.xml";

        public void SaveToFile()
        {

            List<int> final = new List<int>();

            foreach (var data in Datas)
            {
                //var x = ViewModelMain.ConverToList(data.rawData);
                foreach (var y in data.rawData)
                {
                    var z = ArduinoDriver.BuildList(y);
                    final.AddRange(z);
                }
            }

            SerializeObject(final, file);
        }





        private static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();

                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }

        private static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }

        public void LoadClick()
        {
            var result = DeSerializeObject<List<int>>(file);
            if (result != null && result.Count > 0)
            {
                Datas.Clear();

                //MaxLayout layout = new MaxLayout();
                //ViewModelMaxLayout vm = layout.DataContext as ViewModelMaxLayout;
                do
                {
                    var x1 = result.Take(8).ToList();
                    var l1 = ArduinoDriver.RevertBuildList(x1);
                    result.RemoveRange(0, 8);

                    var x2 = result.Take(8).ToList();
                    var l2 = ArduinoDriver.RevertBuildList(x2);
                    result.RemoveRange(0, 8);

                    var x3 = result.Take(8).ToList();
                    var l3 = ArduinoDriver.RevertBuildList(x3);
                    result.RemoveRange(0, 8);

                    var x4 = result.Take(8).ToList();
                    var l4 = ArduinoDriver.RevertBuildList(x4);
                    result.RemoveRange(0, 8);

                    var x5 = result.Take(8).ToList();
                    var l5 = ArduinoDriver.RevertBuildList(x5);
                    result.RemoveRange(0, 8);

                    var x6 = result.Take(8).ToList();
                    var l6 = ArduinoDriver.RevertBuildList(x6);
                    result.RemoveRange(0, 8);

                    var x7 = result.Take(8).ToList();
                    var l7 = ArduinoDriver.RevertBuildList(x7);
                    result.RemoveRange(0, 8);

                    var x8 = result.Take(8).ToList();
                    var l8 = ArduinoDriver.RevertBuildList(x8);
                    result.RemoveRange(0, 8);

                    var x9 = result.Take(8).ToList();
                    var l9 = ArduinoDriver.RevertBuildList(x9);
                    result.RemoveRange(0, 8);

                    var x10 = result.Take(8).ToList();
                    var l10 = ArduinoDriver.RevertBuildList(x10);
                    result.RemoveRange(0, 8);

                    List<bool[,]> screen = new List<bool[,]> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10 };

                    _vmlayout.Apply(screen);

                    view.maxlayout.UpdateLayout();

                    BitmapImage newimg = DesignEditor.GetImage(view.maxlayout);

                    Datas.Add(new binderClass { imageSource = newimg, rawData = screen });

                } while (result.Count > 0);

                OnPropertyChanged("Datas");
                ClearClick();
            }
        }

    }
}
