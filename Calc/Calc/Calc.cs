using System;
using System.Collections.Generic;

namespace Calc
{
    class Calc : ICalc
    {
        private readonly INotation notation;

        public Calc(INotation notation)
        {
            this.notation = notation;
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("Введите выражение:");
                
                var str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Line is empty!");
                    return;
                }

                Console.WriteLine(Calculation(str));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public double Calculation(string str)
        {
            var postfixNotation = notation.Convert2PostfixNotation(str.Replace('.', ','));
            var values = new Stack<double>();

            foreach (var el in postfixNotation)
            {
                double resultPars;

                values.Push(double.TryParse(el, out resultPars) ? resultPars : el.ApplyTo(values));
            }

            return values.Pop();
        }
    }
}
