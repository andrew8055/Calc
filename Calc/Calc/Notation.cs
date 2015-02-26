using System;
using System.Collections.Generic;

namespace Calc
{
    class Notation : INotation
    {
        public List<string> Convert2PostfixNotation(string str)
        {
            var splitSource = Splitter.SplitSourceStr(str);
            var postfixNotation = new List<string>();
            var operationsStack = new Stack<string>();

            foreach (var el in splitSource)
            {
                if (Operators.Priority.ContainsKey(el))
                {
                    if (el.Equals(Operators.CloseBracket))
                    {
                        var isOpenBracketExist = false;

                        while (operationsStack.Count != 0)
                        {
                            if (operationsStack.Peek().Equals(Operators.OpenBracket))
                            {
                                operationsStack.Pop();
                                isOpenBracketExist = true;
                                break;
                            }

                            postfixNotation.Add(operationsStack.Pop());
                        }

                        if(!isOpenBracketExist)
                            throw new Exception("Open bracket not found!");

                        continue;
                    }

                    while (operationsStack.Count != 0)
                    {
                        if (Operators.Priority[el] <= Operators.Priority[operationsStack.Peek()] &&
                            !el.Equals(Operators.OpenBracket))
                            postfixNotation.Add(operationsStack.Pop());
                        else
                            break;
                    }

                    operationsStack.Push(el);
                }
                else
                    postfixNotation.Add(el);
            }
            
            while (operationsStack.Count != 0)
                postfixNotation.Add(operationsStack.Pop());

            return postfixNotation;
        }
    }
}
