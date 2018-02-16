// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

namespace Calculator
{
    public class Operand : ICommandValue
    {
        private readonly IReceiver _receiver;

        public Operand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public bool Execute(double v1)
        {
            return _receiver.Operand(v1);
        }
    }
}