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
using LedGeekBox.ViewModel;

namespace LedGeekBox.View
{
    /// <summary>
    /// Logique d'interaction pour max7219.xaml
    /// </summary>
    public partial class max7219 : System.Windows.Controls.UserControl
    {
        public max7219()
        {
            InitializeComponent();
            DataContext = new ViewModelMax7219();
        }


        public void OnMouseClick(object sender, EventArgs e)
        {
            var dc = DataContext as ViewModelMax7219;
            if (dc != null)
            {
                var ellipse = sender as Ellipse;
                if (ellipse != null)
                {
                    dc.OnMouseClick(ellipse.Name);
                }
            }
        }
    }
}
