using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LedGeekBox.Arduino;
using LedGeekBox.View;
using LedGeekBox.Model;

namespace LedGeekBox.ViewModel
{
    public class binderClass
    {
        //  public string imageLocation { get; set; }
        public byte[,] rawData { get; set; }

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

        ViewModelMaxLayout _vmlayout;
        ArduinoDriver arduino;

        public ViewModelDesignEditor(ViewModelMaxLayout vmlayout, ArduinoDriver arduinoDriver)
        {
            _vmlayout = vmlayout;
            arduino = arduinoDriver;
            ClearCommand = new RelayCommand(o => ClearClick());
            Forwar2ArduinoCommand = new RelayCommand(c => Forwar2ArduinoClick());
            InvertCommand = new RelayCommand(x => InvertClick());
            Datas = new ObservableCollection<binderClass>();
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
    }
}
