using mandelbrot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace mandelbrot.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IFractalComputer _fractalComputer;
        private readonly Params p;

        public MainViewModel(IFractalComputer fc)
        {
            _fractalComputer = fc;
            RenderCommand = new RelayCommand(Render);
            p = new Params();
        }

        private BitmapSource _fractalImage;
        public BitmapSource FractalImage
        {
            get => _fractalImage;
            set {  _fractalImage = value; OnPropertyChanged();  }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

       

        public ICommand RenderCommand { get; }
        private void Render()
        {
            int[,] data = _fractalComputer.Compute(p);
            FractalImage = ConvertToBitmap(data);
            
            //Debug.WriteLine($"Bitmap created: {FractalImage != null}, size {FractalImage?.Width}x{FractalImage?.Height}");
            //using (var stream = new FileStream(@"C:\Users\aksdfj\source\repos\mandelbrot\fractal_debug.png", FileMode.Create))
            //{
            //    var encoder = new PngBitmapEncoder();
            //    encoder.Frames.Add(BitmapFrame.Create(FractalImage));
            //    encoder.Save(stream);
            //}

        }


        private BitmapSource ConvertToBitmap(int[,] data)
        {
            int width = data.GetLength(0);
            int height = data.GetLength(1);
            var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            

            int stride = (int)(width * 4);
            byte[] pixels = new byte[height * stride];
            for (int i = 0; i < pixels.Length; i += 4)
            {

                int pixelIndex = i / 4;
                int x = pixelIndex % width;
                int y = pixelIndex / width;
                //double aspect = (double)height/width;


                //byte c = (byte)(255 - (iter * 255 / iqgitterations));
                byte c = (byte)data[x, y];


                pixels[i] = c;     // Blue
                pixels[i + 1] = c; // Green
                pixels[i + 2] = c; // Red
                pixels[i + 3] = 255; // Alpha
            }
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, stride, 0);
            return bitmap;


        }


        private double map(double value, double inMin, double inMax, double outMin, double outMax)
        {
            return outMin + (value - inMin) * (outMax - outMin) / (inMax - inMin);
        }
        
    }
}
