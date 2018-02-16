// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

namespace Calculator
{
    // Support Execute with Return Value to Success/Fail Option
    public interface ICommand
    {
        bool Execute();
    }
}