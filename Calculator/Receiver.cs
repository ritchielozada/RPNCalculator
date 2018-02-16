// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

using System;
using System.Collections.Generic;

namespace Calculator
{
    // Extend Stack to support RpnPop() and RpnPeek() to return '0' value
    // when Stack is Empty instead of throwing error.
    public static class RpnStackExtension
    {
        public static double RpnPop(this Stack<double> rpnStack)
        {
            if (rpnStack.Count == 0)
            {
                return 0;
            }
            else
            {
                return rpnStack.Pop();
            }
        }

        public static double RpnPeek(this Stack<double> rpnStack)
        {
            if (rpnStack.Count == 0)
            {
                return 0;
            }
            else
            {
                return rpnStack.Peek();
            }
        }
    }

    // Receiver - RPN Calculator
    public class Receiver : IReceiver
    {
        private readonly Stack<double> _rpnStack;

        public double CurrentValue => _rpnStack.RpnPeek();

        public string LastErrorMessage => _lastErrorMessage;
        private string _lastErrorMessage;

        public Receiver()
        {
            _rpnStack = new Stack<double>();
            _lastErrorMessage = string.Empty;
        }

        public bool Operand(double v1)
        {
            _rpnStack.Push(v1);
            return true;
        }

        public bool Add()
        {
            var v1 = _rpnStack.RpnPop();
            var v2 = _rpnStack.RpnPop();
            _rpnStack.Push(v1 + v2);
            return true;
        }

        public bool Subtract()
        {
            var v1 = _rpnStack.RpnPop();
            var v2 = _rpnStack.RpnPop();
            _rpnStack.Push(v2 - v1);
            return true;
        }

        public bool Multiply()
        {
            var v1 = _rpnStack.RpnPop();
            var v2 = _rpnStack.RpnPop();
            _rpnStack.Push(v1 * v2);
            return true;
        }

        public bool Divide()
        {
            var v1 = _rpnStack.RpnPop();
            var v2 = _rpnStack.RpnPop();

            if (Math.Abs(v1) > Double.Epsilon)
            {
                _rpnStack.Push(v2 / v1);
                return true;
            }
            else
            {
                _lastErrorMessage = "Divide By Zero Error";
                return false;
            }
        }

        public bool Reciprocal()
        {
            var v1 = _rpnStack.RpnPop();
            if (Math.Abs(v1) > Double.Epsilon)
            {
                _rpnStack.Push(1 / v1);
                return true;
            }
            else
            {
                _lastErrorMessage = "Reciprocal Divide By Zero Error";
                return false;
            }
        }

        public bool Factorial()
        {
            var dval = _rpnStack.RpnPop();
            if (double.IsNaN(dval) || double.IsInfinity(dval) || Math.Abs(dval % 1) > double.Epsilon)
            {
                _rpnStack.Push(dval);
                _lastErrorMessage = "Non Integer Factorial Error";
                return false;
            }


            int v1 = (int) dval;
            double result = v1;
            if (v1 < 0)
            {
                _rpnStack.Push(v1);
                _lastErrorMessage = "Negative Factorial Error";
                return false;
            }
            else if (v1 == 0 || v1 == 1)
            {
                result = 1;
            }
            else
            {
                for (int v = v1 - 1; v > 1; v--)
                {
                    result *= v;
                }
            }

            _rpnStack.Push(result);
            return true;
        }

        public bool Equals()
        {
            return true;
        }

        public bool ClearPrevious()
        {
            _rpnStack.RpnPop();
            _rpnStack.Push(0);
            return true;
        }

        public bool ClearAll()
        {
            _rpnStack.Clear();
            _lastErrorMessage = string.Empty;
            return true;
        }

        public bool Quit()
        {
            return true;
        }
    }
}