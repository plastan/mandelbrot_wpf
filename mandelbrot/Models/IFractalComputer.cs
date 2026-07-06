

namespace mandelbrot.Models

{
  public enum NumericMode{
    Double,
    Decimal
  }
    internal interface IFractalComputer
    {
        NumericMode Mode {get;}

        int[,] Compute(Params p);
        
    }
}
