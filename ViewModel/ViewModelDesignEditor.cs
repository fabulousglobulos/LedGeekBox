using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LedGeekBox.Arduino;
using LedGeekBox.View;
using LedGeekBox.Model;

namespace LedGeekBox.ViewModel
{
    public class ViewModelDesignEditor : INotifyPropertyChanged
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
