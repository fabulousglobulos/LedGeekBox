using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LedGeekBox
{
    public class ViewModelMaxLayout : INotifyPropertyChanged
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
        
        private static Color Black = Color.FromRgb(0, 0, 0);
        private static Color Red = Color.FromRgb(255, 0, 0);

        public ViewModelMaxLayout(List<ViewModelMax7219> vms)
        {
            vm1 = vms[0];
            vm2 = vms[1];
            vm3 = vms[2];
            vm4 = vms[3];
            vm5 = vms[4];
            vm6 = vms[5];
            vm7 = vms[6];
            vm8 = vms[7];
            vm9 = vms[8];
            vm10 = vms[9];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                var args = new PropertyChangedEventArgs(property);
                handlers(this, args);
            }
        }
        

        public void Apply1(List< bool[,]> datas)
        {
            CheckConstraint(datas);

            vm1.Apply(datas[0]);
            vm2.Apply(datas[1]);
            vm3.Apply(datas[2]);

            vm4.Apply(datas[3]);
            vm5.Apply(datas[4]);
        }

        public void Apply2(List<  bool[,]> datas)
        {
            CheckConstraint(datas);

            vm6.Apply(datas[0]);
            vm7.Apply(datas[1]);
            vm8.Apply(datas[2]);

            vm9.Apply(datas[3]);
            vm10.Apply(datas[4]);
        }

        private void CheckConstraint(List<bool[,]> datas)
        {
            if (datas == null || datas.Count != 5)
            {
                throw new ArgumentException("not enough data in input");
            }
        }
    }
}
