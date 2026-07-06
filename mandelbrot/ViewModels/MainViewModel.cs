using mandelbrot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
// using System.Drawing;
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
using System.Windows;
namespace mandelbrot.ViewModels
{
    internal class MainViewModel : ViewModelBase  
    {
        private readonly IFractalComputer _fractalComputer;
        private Params p;

        public MainViewModel(IFractalComputer fc)
        {
            _fractalComputer = fc;
            RenderCommand = new RelayCommand(Render);
            ResetCommand = new RelayCommand(Reset);
            p = new Params();
        }

      private Point _tp;
      public Point Tp{
        get => _tp;
        set {
          _tp = value;
            OnPropertyChanged(nameof(Tp));
            OnPropertyChanged(nameof(TpX));
            OnPropertyChanged(nameof(TpY));

        }
      }

        public double TpX => Tp.X;
        public double TpY => Tp.Y;

        private Point _mp;
        public Point Mp{
          get => _mp;
          set{
            if (_mp == value)
            return;
            _mp = value;
            OnPropertyChanged(nameof(Mp));
            OnPropertyChanged(nameof(MpX));
            OnPropertyChanged(nameof(MpY));
          }
        }
        public double MpX => Mp.X;
        public double MpY => Mp.Y;
    
        public void UpdateMouse(Point p)
        {
        Mp = p;  
        }


        private BitmapSource _fractalImage;
        public BitmapSource FractalImage
        {
            get => _fractalImage;
            set {  _fractalImage = value; OnPropertyChanged();  }
        }


       

        public ICommand RenderCommand { get; }
        public ICommand ResetCommand {get;}
        private void Render(){
            int[,] data = _fractalComputer.Compute(p);
            FractalImage = ConvertToBitmap(data);
            // MessageBox.Show("Hello, world!");
            
            // Debug.WriteLine($"Bitmap created: {FractalImage != null}, size {FractalImage?.Width}x{FractalImage?.Height}");
            // MessageBox.Show($"Bitmap created: {FractalImage?.Width} x {FractalImage?.Height}");
            // MessageBox.Show(GetType().Name ?? "null");
            // using (var stream = new FileStream(@"C:\Users\fractal_debug.png", FileMode.Create))
            // {
            //     var encoder = new PngBitmapEncoder();
            //     encoder.Frames.Add(BitmapFrame.Create(FractalImage));
            //     encoder.Save(stream);
            // }

        }

        private void Reset(){
          // resent params class to initial values;
          p.CenterX = -.5;
          p.CenterY = 0.0;
          p.Range = 1;
          // Decimal varient
          p.CenterXD = -.5m;
          p.CenterYD = 0.0m;
          p.RangeD = 1m;
          Render();

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
        private decimal mapD(int value, int inMin, int inMax, decimal outMin, decimal outMax)
            {
                return outMin + (value - inMin) * (outMax - outMin) / (inMax - inMin);
            }

        internal void HandleRightClick(Point point)
        {
          if (_fractalComputer.Mode == NumericMode.Double){
          double nx = map(point.X,0,p.Width,p.CenterX - p.Range,p.CenterX + p.Range);
          double ny = map(point.Y,0,p.Height,p.CenterY - p.Range,p.CenterY + p.Range);
          p.CenterX = nx;
          p.CenterY = ny;
          p.Range = p.Range*.2;
          Tp = new Point(nx,ny);

          } else{
          // Decimal varient
          decimal nx =mapD((int)point.X,0,p.Width,p.CenterXD - p.RangeD,p.CenterXD + p.RangeD);
          decimal ny =mapD((int)point.Y,0,p.Width,p.CenterYD - p.RangeD,p.CenterYD + p.RangeD);
          p.CenterXD = nx;
          p.CenterYD = ny;
          p.RangeD = p.RangeD*.2m;

          }
          // decimal nyd = ;

          this.Render();

        }

        internal void UpdateWindowSize(double width, double height)
        {
          p.Width = (int)width;
          p.Height= (int)height;
          Render();

        }
        public System.Windows.Point MousePosition{get;private set;}




    }

}
