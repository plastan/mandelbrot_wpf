
namespace mandelbrot.Models
{
    internal interface IFractalComputer
    {
        int[,] Compute(Params p);
        
    }
}