using Ninject;

namespace Calc
{
    class Program
    {
        static void Main()
        {
            var kernel = new StandardKernel();
            
            kernel.Bind<INotation>().To<Notation>();
            kernel.Bind<ICalc>().To<Calc>();

            var calc = kernel.Get<ICalc>();

            while (true)
                calc.Run();
        }
    }
}
