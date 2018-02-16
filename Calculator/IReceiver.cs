// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

namespace Calculator
{
    // Receiver Operations    
    public interface IReceiver
    {
        bool Operand(double v1);
        bool Add();
        bool Subtract();
        bool Multiply();
        bool Divide();
        bool Reciprocal();
        bool Factorial();
        bool Equals();
        bool ClearPrevious();
        bool ClearAll();
        bool Quit();
    }
}