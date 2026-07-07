using mandelbrot.Models;
using mandelbrot.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace mandelbrot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application

    {
        private IFractalComputer cc;
    private MainViewModel vm;

        protected override void OnStartup(StartupEventArgs e)
        {
            cc = new DoubleFractalComputer();
            // cc = new DecimalFractalComputer();
            vm = new MainViewModel(cc);

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = vm;
            mainWindow.Show();

            base.OnStartup(e);
        }

    }



}
