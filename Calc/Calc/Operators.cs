using System.Collections.Generic;

namespace Calc
{
    class Operators
    {
        public const string OpenBracket = "(";
        public const string CloseBracket = ")";
        public const string Plus = "+";
        public const string Minus = "-";
        public const string Multiplication = "*";
        public const string Division = "/";

        public static readonly Dictionary<string, int> Priority = new Dictionary<string, int>
        {
            {OpenBracket, 0},
            {CloseBracket, 0},
            {Plus, 1},
            {Minus, 1},
            {Multiplication, 2},
            {Division, 2}
        };
    }
}
