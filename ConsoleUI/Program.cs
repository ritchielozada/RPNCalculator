// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

using System;
using Calculator;

namespace ConsoleUI
{
    class Program
    {
        private const int MaxInputLen = 2048;

        static void Main()
        {
            var client = new Client(MaxInputLen);
            var terminateApp = false;

            Console.WriteLine("Enter Equation, {0} character limit (type 'Q' to exit):", MaxInputLen);
            Console.WriteLine();
            do
            {
                Console.Write(">");
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    var line = readLine.Trim();
                    terminateApp = line.Equals("Q");
                    if (!terminateApp && !string.IsNullOrEmpty(line))
                    {
                        string errorMessage;
                        double result;

                        if (client.Parse(line, out result, out errorMessage))
                        {
                            Console.WriteLine("Result: {0}", result);
                        }
                        else
                        {
                            Console.WriteLine("Error: {0}", errorMessage);
                        }
                    }
                }
            } while (!terminateApp);
        }
    }
}