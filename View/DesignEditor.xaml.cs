using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LedGeekBox.Arduino;
using LedGeekBox.ViewModel;

namespace LedGeekBox.View
{
    /// <summary>
    /// Logique d'interaction pour DesignEditor.xaml
    /// </summary>
    public partial class DesignEditor : Window
    {
        public DesignEditor( ArduinoDriver arduino)
        {
            InitializeComponent();
            ViewModelMaxLayout vmLayout = maxlayout.DataContext as ViewModelMaxLayout;
            vmLayout.DesignMode = true;
            DataContext = new ViewModelDesignEditor(vmLayout, arduino);
        }
    }
}
