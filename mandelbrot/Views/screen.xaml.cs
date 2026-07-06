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

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

            System.Windows.Point P = e.GetPosition(this);
            if (DataContext is MainViewModel vm){
              vm.UpdateMouse(P);
            }
        }
        private void  Window_MouseRightButton(object sender, MouseEventArgs e){
          if (DataContext is MainViewModel vm){

            System.Windows.Point P = e.GetPosition(this);
            vm.HandleRightClick(P);

          }

        }

        }
   

}

