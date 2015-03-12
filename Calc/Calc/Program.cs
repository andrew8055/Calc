using Ninject;

namespace Calc
{
    class Program
    {
        static void Main()
        {
            var kernel = new StandardKernel();
            
            kernel.Bind<INotation>().To<Notation>();

            var calc = kernel.Get<Calc>();

            while (true)
                calc.Run();
        }
    }
}
