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


        public void OnMouseEnter(object sender, EventArgs e)
        {
            var dc = DataContext as ViewModelMax7219;
            if (dc != null)
            {
                if (!dc.DesignMode)
                {//not in design mode, user can edit manually in design mode, in display (main mode) feature not available
                    return;
                }

                //confirm that mosue button have been pressed
                if (Mouse.LeftButton != MouseButtonState.Pressed)
                {
                    return;
                }
             
                //it is really an ellopse object! (normmaly anything else is not possible
                var ellipse = sender as Ellipse;
                if (ellipse != null)
                {
                    dc.OnMouseOver(ellipse.Name);
                }
            }
        }
    }
}
