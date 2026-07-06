using System;
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

        public static int MaxIterations { get; set; } = 50;
        public double scale { get; set; } = 0.1;
        public int Width { get; set; } = 400;
        public int Height { get; set; } = 400;

    }
}
