using System.ComponentModel;
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

namespace mandelbrot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

        }
        private int _x;
        public int X
        {
            get => _x;
            set
            {
                if(_x != value)
                {
                    _x = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

            Point P = e.GetPosition(this);
            this.X = (int)P.X;



        }
    }
}