using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace mandelbrot.Models
{
    internal class DoubleFractalComputer : IFractalComputer
    {
        private double EscapeRadiusSqure = 4.0;
        public DoubleFractalComputer()
        {

        }
        public int[,] Compute(Params p)
        {
            int[,] res = new int[p.Width, p.Height];
            for(int row = 0; row < p.Width; row++) { 
                for (int col = 0; col < p.Height; col++){
                    double xx = map(row, 0, p.Width, -2, 2);
                    double yy = map(col, 0, p.Height, 2, -2);
                    res[row, col] = (255-Iterate(xx, yy) * 255 / Params.MaxIterations); 
                    
                    }
            }
            return res;
        }
        public int Iterate(double Cr, double Ci)
        {
            double Zr = 0;
            double Zi = 0;
            double Tr = 0;
            double Ti = 0;

            int n = 0;


            while ((n < Params.MaxIterations) && (Tr + Ti) <= 4.0)
            {
                Zi = 2 * Zr * Zi + Ci;
                Zr = Tr - Ti + Cr;
                Tr = Zr * Zr;
                Ti = Zi * Zi;
                n++;
            }
            //four more iteration to smooth error
            for (int e = 0; e < 4; e++)
            {
                Zi = 2 * Zr * Zi + Ci;
                Zr = Tr - Ti + Cr;
                Tr = Zr * Zr;
                Ti = Zi * Zi;
            }
            return n;
        }
        private double map(double value, double inMin, double inMax, double outMin, double outMax)
        {
            return outMin + (value - inMin) * (outMax - outMin) / (inMax - inMin);
        }
    }
}
