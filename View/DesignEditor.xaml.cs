using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
        public DesignEditor(ArduinoDriver arduino)
        {
            InitializeComponent();
            ViewModelMaxLayout vmLayout = maxlayout.DataContext as ViewModelMaxLayout;
            vmLayout.DesignMode = true;
            ViewModelDesignEditor vm = new ViewModelDesignEditor(vmLayout, arduino);
            DataContext = vm;
            vm.view = this;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)maxlayout.ActualWidth, (int)maxlayout.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(maxlayout);

            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            FileStream stream = new FileStream(@"c:\temp\xxx.png", FileMode.OpenOrCreate);
            png.Save(stream);
            stream.Close();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            //RenderTargetBitmap rtb = new RenderTargetBitmap((int)maxlayout.ActualWidth, (int)maxlayout.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            //rtb.Render(maxlayout);

            //PngBitmapEncoder png = new PngBitmapEncoder();
            //png.Frames.Add(BitmapFrame.Create(rtb));
            //MemoryStream stream = new MemoryStream();
            //png.Save(stream);

            //Bitmap bit = new Bitmap(stream);

            //Bitmap resizedBit = ResizeBitmap(bit, 200, 80);
            //BitmapImage newimg = ToBitmapImage(resizedBit);
            BitmapImage newimg = GetImage(maxlayout);

            ViewModelDesignEditor vm = DataContext as ViewModelDesignEditor;
            vm.Datas.Add(new binderClass { imageSource = newimg , rawData=vm.Read()});
            vm.OnPropertyChanged("Datas");
        }

        public static BitmapImage GetImage( MaxLayout maxlayout)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)maxlayout.ActualWidth, (int)maxlayout.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(maxlayout);

            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            MemoryStream stream = new MemoryStream();
            png.Save(stream);

            Bitmap bit = new Bitmap(stream);

            Bitmap resizedBit = ResizeBitmap(bit, 200, 80);
            BitmapImage newimg = ToBitmapImage(resizedBit);
            return newimg;
        }


        private static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
            return result;
        }

 

        private void DesignerListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModelDesignEditor vm = DataContext as ViewModelDesignEditor;
            if (e.AddedItems.Count > 0)
            {
                binderClass cls = e.AddedItems[0] as binderClass;
                vm.Apply(cls);
            }
        }
    }
}
