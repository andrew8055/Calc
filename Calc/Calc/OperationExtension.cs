using System;
using System.Collections.Generic;

namespace Calc
{
    static class OperationExtension
    {
        public static double ApplyTo(this string operation, Stack<double> stack)
        {
            double first, second;

            if(stack.Count >= 2) 
            {
                second = stack.Pop();
                first = stack.Pop();
            }
            else
                throw new Exception("Expression is not valid!");

            switch (operation)
            {
                case Operators.Plus: return first + second;
                case Operators.Minus: return first - second;
                case Operators.Multiplication: return first * second;
                case Operators.Division: return first / second;
                default: throw new Exception("Invalid operator!");
            }
        }
    }
}
