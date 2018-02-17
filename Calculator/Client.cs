// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Client
    {
        private readonly int _maxInputLen;
        private readonly Invoker _invoker;
        private readonly Dictionary<string, int> _precedenceDict;
        private readonly Dictionary<string, string> _replacementDict;
        private readonly HashSet<string> _commandSet;
        private readonly Receiver _receiver;


        // TODO: Parse multi-character operators        
        private const string ParseRegex = @"[\(\)\!\+\*/\=RCAQ]{1}|\-?\d*\.*\d*|\-{1}";

        private readonly Regex _regex = new Regex(ParseRegex);

        public Client(int maxInputLen = 1024)
        {
            _maxInputLen = maxInputLen;
            _receiver = new Receiver();
            _invoker = new Invoker(
                new Operand(_receiver),
                new AddCommand(_receiver),
                new SubtractCommand(_receiver),
                new MultiplyCommand(_receiver),
                new DivideCommand(_receiver),
                new ReciprocalCommand(_receiver),
                new FactorialCommand(_receiver),
                new EqualsCommand(_receiver),
                new ClearPreviousCommand(_receiver),
                new ClearAllCommand(_receiver),
                new QuitCommand(_receiver)
            );

            // TODO: Handle this in equation parsing                                    
            _replacementDict = new Dictionary<string, string>
            {
                {"1/X", "R"} // Reciprocal                
            };

            // Setup Lookup Tables instead of Token Enums
            // Define Operator Precedence
            _precedenceDict = new Dictionary<string, int>
            {
                {"!", 1},
                {"R", 1},
                {"*", 2},
                {"/", 2},
                {"+", 3},
                {"-", 3},
                {"C", 3},
                {"Q", 3},
                {"A", 3},              
                {"=", 99}
            };

            // Commands and Unary Operators
            _commandSet = new HashSet<string>
            {
                "C",    // Clear Previous Number
                "A",    // All Clear
                "Q",    // Quit
                "R",    // Reciprocal                
                "!"     // Factorial
            };
        }


        // TODO: Change Parsing Approach
        private string OperatorReplacement(string str)
        {
            var s = str.ToUpper();
            foreach (var kvp in _replacementDict)
            {
                s = s.Replace(kvp.Key, kvp.Value);
            }

            return s;
        }

        // Infix to Postfix Direction Conversion without using Evaluation Tree
        public bool Parse(string str, out double result, out string errorMessage)
        {
            Queue<string> tokenQueue = new Queue<string>();
            Stack<string> operatorStack = new Stack<string>(); // Operators
            Queue<string> outputQueue = new Queue<string>(); // Output in RPN            
            bool invokeResult = true;

            // Error Traps
            if (str.Length > _maxInputLen)
            {
                errorMessage = $"Input exceeds maximum supported length ({_maxInputLen} characters)";
                result = 0;
                return false;
            }

            var matchString = OperatorReplacement(str);
            var matchResults = _regex.Matches(matchString); // Convert multi-char operators
            foreach (var matches in matchResults)
            {
                // Eliminate empty strings
                if (string.IsNullOrEmpty(matches.ToString()))
                    continue;

                tokenQueue.Enqueue(matches.ToString());
            }

            // Convert to RPN            
            while (tokenQueue.Count > 0)
            {
                var token = tokenQueue.Dequeue();

                // Operator/Function Check
                if (_precedenceDict.ContainsKey(token))
                {
                    if (!_commandSet.Contains(token) && tokenQueue.Count > 0 &&
                        _precedenceDict.ContainsKey(tokenQueue.Peek()))
                    {
                        continue;
                    }

                    if (operatorStack.Count > 0)
                    {
                        var tokenP = _precedenceDict[token];
                        while (operatorStack.Count >= 0)
                        {
                            if (operatorStack.Count > 0 &&
                                _precedenceDict.ContainsKey(operatorStack.Peek()) && 
                                tokenP >= _precedenceDict[operatorStack.Peek()])
                            {
                                outputQueue.Enqueue(operatorStack.Pop());
                            }
                            else
                            {
                                operatorStack.Push(token);
                                break;
                            }
                        }
                    }
                    else
                    {
                        operatorStack.Push(token);
                    }
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while ((operatorStack.Count > 0) && (operatorStack.Peek() != "("))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }

                    if (operatorStack.Count == 0)
                    {
                        errorMessage = "Mismatched Parentheses";
                        result = 0;
                        return false;
                    }
                    else
                    {
                        // Pop the matching parenthesis
                        operatorStack.Pop();
                    }
                }
                else     // Assume Operand
                {                
                    outputQueue.Enqueue(token);
                }
            }

            // Load Remaining Operators to Output
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            // Invoke the commands            
            while (outputQueue.Count > 0 && invokeResult)
            {
                var token = outputQueue.Dequeue();
                switch (token)
                {
                    case "+":
                        invokeResult = _invoker.Add();
                        break;
                    case "-":
                        invokeResult = _invoker.Subtract();
                        break;
                    case "*":
                        invokeResult = _invoker.Multiply();
                        break;
                    case "/":
                        invokeResult = _invoker.Divide();
                        break;
                    case "=":
                        invokeResult = _invoker.Equals();
                        break;
                    case "C":
                        invokeResult = _invoker.ClearPrevious();
                        break;
                    case "A":
                        invokeResult = _invoker.ClearAll();
                        break;
                    case "Q":
                        invokeResult = _invoker.Quit();
                        break;
                    case "R":
                        invokeResult = _invoker.Reciprocal();
                        break;
                    case "!":
                        invokeResult = _invoker.Factorial();
                        break;
                    default:
                        double val;
                        if (double.TryParse(token, out val))
                        {
                            invokeResult = _invoker.Operand(val);
                        }

                        break;
                }
            }

            result = _receiver.CurrentValue;
            errorMessage = _receiver.LastErrorMessage;
            return invokeResult;
        }
    }
}