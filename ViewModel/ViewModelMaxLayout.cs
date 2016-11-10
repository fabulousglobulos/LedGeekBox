using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LedGeekBox.Model.Scenario;

namespace LedGeekBox.ViewModel
{
    public class ViewModelMaxLayout : INotifyPropertyChanged, IStep
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

        public bool DesignMode
        {
            set
            {
                vm1.DesignMode = value;
                vm2.DesignMode = value;
                vm3.DesignMode = value;
                vm4.DesignMode = value;
                vm5.DesignMode = value;
                vm6.DesignMode = value;
                vm7.DesignMode = value;
                vm8.DesignMode = value;
                vm9.DesignMode = value;
                vm10.DesignMode = value;
            }
        }
        
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


        public void Apply(List<bool[,]> datas)
        {
            CheckConstraint(datas);

            vm1.Apply(datas[0]);
            vm2.Apply(datas[1]);
            vm3.Apply(datas[2]);
            vm4.Apply(datas[3]);
            vm5.Apply(datas[4]);

            vm6.Apply(datas[5]);
            vm7.Apply(datas[6]);
            vm8.Apply(datas[7]);
            vm9.Apply(datas[8]);
            vm10.Apply(datas[9]);
            //   vm10.Apply(datas[9]);
        }

        private void CheckConstraint(List<bool[,]> datas)
        {
            if (datas == null || datas.Count != 10)
            {
                throw new ArgumentException("not enough data in input");
            }
        }



        public List<bool[,]> ReadScreen()
        {
            List<bool[,]> datas = new List<bool[,]>();

            datas.Add(vm1.Read());
            datas.Add(vm2.Read());
            datas.Add(vm3.Read());
            datas.Add(vm4.Read());
            datas.Add(vm5.Read());

            datas.Add(vm6.Read());
            datas.Add(vm7.Read());
            datas.Add(vm8.Read());
            datas.Add(vm9.Read());
            datas.Add(vm10.Read());

            return datas;
        }
    }
}
