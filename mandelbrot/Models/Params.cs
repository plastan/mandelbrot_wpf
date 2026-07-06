using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Windows;

namespace mandelbrot.Models
{
    internal class Params
    {
        public double CenterX { get; set; } = -.5;
        public double CenterY { get; set; } = 0.0;

        public int MaxIterations { get; set; } = 50;
        public double scale { get; set; } = 0.1;
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 600;
        public double Range = 1;
        public double Zoom {get; set;} = 10.0;


        // for high precision decimals
        public decimal CenterXD { get; set; } = -.5m;
        public decimal CenterYD { get; set; } = 0.0m;
        public decimal RangeD { get; set; } = 1m;

    }
}
