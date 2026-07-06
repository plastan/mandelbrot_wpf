using mandelbrot.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mandelbrot.Views
{
    /// <summary>
    /// Interaction logic for screen.xaml
    /// </summary>
    public partial class screen : Page
    {
        //private WriteableBitmap bitmap;

        public screen()
        {
            InitializeComponent();
            
            //int width = 800;
            //int height = 800;

            //bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            //CanvasImage.Source = bitmap;
            //FillWhite();
        }

        internal void FractalImage_SizeChanged(object sender, SizeChangedEventArgs e){
          if (e.NewSize.Width < 1 || e.NewSize.Height < 1) return;
            if (DataContext is MainViewModel vm){
              vm.UpdateWindowSize(e.NewSize.Width,e.NewSize.Height);
            }

        }


//        private int iterations = 50;
//        private int er = 4;

//        private int Compute(double Cr, double Ci)
//        {
//            double Zr = 0;
//            double Zi = 0;
//            double Tr = 0;
//            double Ti = 0;

//            int n = 0;


//            while((n < iterations) && (Tr + Ti) <= er)
//            {
//                Zi = 2 * Zr * Zi + Ci;
//                Zr = Tr - Ti + Cr;
//                Tr = Zr * Zr;
//                Ti = Zi * Zi;
//                n++;
//            }
////four more iteration to smooth error
//            for (int e = 0; e < 4; e++)
//            {
//                Zi = 2 * Zr * Zi + Ci;
//                Zr = Tr - Ti + Cr;
//                Tr = Zr * Zr;
//                Ti = Zi * Zi;
//            }
//            return n;
//        }
//        private double map(double value, double inMin, double inMax, double outMin, double outMax)
//        {
//            return outMin + (value - inMin) * (outMax - outMin) / (inMax - inMin);
//        }
//        //private int map(int value, int inMin, int inMax, int outMin, int outMax)
//        //{
//        //    return outMin + (value - inMin) * (outMax - outMin) / (inMax - inMin);
//        //}
//        private void FillWhite()
//        {
//            int width = bitmap.PixelWidth;
//            int height = bitmap.PixelHeight;
//            int stride = (int)(width * 4);
//            byte[] pixels = new byte[height * stride];
            
//            for (int i = 0; i < pixels.Length; i+=4) {
                
//                int pixelIndex = i / 4;
//                int x = pixelIndex % width;
//                int y = pixelIndex / width;
//                //double aspect = (double)height/width;
//                double xx = map(x, 0, width, -2, 2);
//                double yy = map(y, 0, height, 2, -2);
//                int iter = Compute(xx, yy);

//                byte c = (byte)(255 - (iter * 255 / iterations));
                
                
//                pixels[i] = c;     // Blue
//                pixels[i + 1] = c; // Green
//                pixels[i + 2] = c; // Red
//                pixels[i + 3] = 255; // Alpha
//            }

//            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, stride, 0);
//        }
    }
    

}

