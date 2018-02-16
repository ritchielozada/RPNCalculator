﻿// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

namespace Calculator
{
    public class FactorialCommand : ICommand
    {
        private readonly IReceiver _receiver;

        public FactorialCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public bool Execute()
        {
            return _receiver.Factorial();
        }
    }
}