﻿using System;
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
    /// Logique d'interaction pour max7219.xaml
    /// </summary>
    public partial class max7219 : UserControl
    {
        public max7219()
        {
            InitializeComponent();
            DataContext = new ViewModelMax7219();
        }
    }
}
