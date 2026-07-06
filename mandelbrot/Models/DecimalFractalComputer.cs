namespace mandelbrot.Models{
  internal class DecimalFractalComputer:IFractalComputer{
    private const decimal EscapeRadiusSquare = 4.0m;


        public NumericMode Mode => NumericMode.Decimal;
        public int[,] Compute(Params p)
        {
          decimal xmin = p.CenterXD - p.RangeD;
          decimal ymin = p.CenterYD - p.RangeD;
          decimal xmax= p.CenterXD + p.RangeD;
          decimal ymax= p.CenterYD + p.RangeD;

          int[,] res = new int[p.Width, p.Height];
            for(int row = 0; row < p.Width; row++) { 
                for (int col = 0; col < p.Height; col++){
                    decimal xx = map(row, 0, p.Width, xmin,xmax);
                    decimal yy = map(col, 0, p.Height, ymin, ymax);
                    res[row, col] = (255-Iterate(xx, yy,p) * 255 / p.MaxIterations); 
                    
                    }
            }
            return res;


        }
 public int Iterate(decimal Cr, decimal Ci, Params p)
    {
        decimal Zr = 0, Zi = 0, Tr = 0, Ti = 0;
        int n = 0;
        while (n < p.MaxIterations && (Tr + Ti) <= EscapeRadiusSquare)
        {
            Zi = 2 * Zr * Zi + Ci;
            Zr = Tr - Ti + Cr;
            Tr = Zr * Zr;
            Ti = Zi * Zi;
            n++;
        }
        for (int e = 0; e < 4; e++)
        {
            Zi = 2 * Zr * Zi + Ci;
            Zr = Tr - Ti + Cr;
            Tr = Zr * Zr;
            Ti = Zi * Zi;
        }
        return n;
    }

private decimal map(int value, int inMin, int inMax, decimal outMin, decimal outMax)
    {
        return outMin + (value - inMin) * (outMax - outMin) / (inMax - inMin);
    }
    }

}
