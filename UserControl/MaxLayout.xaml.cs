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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LedGeekBox
{
    /// <summary>
    /// Logique d'interaction pour MaxLayout.xaml
    /// </summary>
    public partial class MaxLayout : System.Windows.Controls.UserControl
    {
        public MaxLayout()
        {
            InitializeComponent();

            var tmp = new List<ViewModelMax7219>
            {
                this.max1.DataContext as ViewModelMax7219,
                this.max2.DataContext as ViewModelMax7219,
                this.max3.DataContext as ViewModelMax7219,
                this.max4.DataContext as ViewModelMax7219,
                this.max5.DataContext as ViewModelMax7219,
                this.max6.DataContext as ViewModelMax7219,
                this.max7.DataContext as ViewModelMax7219,
                this.max8.DataContext as ViewModelMax7219,
                this.max9.DataContext as ViewModelMax7219,
                this.max10.DataContext as ViewModelMax7219
            };

            DataContext = new ViewModelMaxLayout(tmp);
        }

    }
}
