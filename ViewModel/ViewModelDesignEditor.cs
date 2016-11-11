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

        ViewModelMaxLayout _vmlayout;
        ArduinoDriver arduino;

        public ViewModelDesignEditor(ViewModelMaxLayout vmlayout, ArduinoDriver arduinoDriver)
        {
            _vmlayout = vmlayout;
            arduino = arduinoDriver;
            ClearCommand = new RelayCommand(o => ClearClick());
            Forwar2ArduinoCommand = new RelayCommand(c => Forwar2ArduinoClick());

            Datas = new ObservableCollection<binderClass>();
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
