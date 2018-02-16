// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

namespace Calculator
{
    // Invoker Class
    public class Invoker
    {
        private readonly ICommandValue _operand;
        private readonly ICommand _addCommand;
        private readonly ICommand _subtractCommand;
        private readonly ICommand _multiplyCommand;
        private readonly ICommand _divideCommand;
        private readonly ICommand _reciprocalCommand;
        private readonly ICommand _factorialCommand;
        private readonly ICommand _equalsCommand;
        private readonly ICommand _clearPreviousCommand;
        private readonly ICommand _clearAllCommand;
        private readonly ICommand _quitCommand;

        public Invoker(
            ICommandValue operand,
            ICommand addCommand,
            ICommand subtractCommand,
            ICommand multiplyCommand,
            ICommand divideCommand,
            ICommand reciprocalCommand,
            ICommand factorialCommand,
            ICommand equalsCommand,
            ICommand clearPreviousCommand,
            ICommand clearAllCommand,
            ICommand quitCommand
        )
        {
            _operand = operand;
            _addCommand = addCommand;
            _subtractCommand = subtractCommand;
            _multiplyCommand = multiplyCommand;
            _divideCommand = divideCommand;
            _reciprocalCommand = reciprocalCommand;
            _factorialCommand = factorialCommand;
            _equalsCommand = equalsCommand;
            _clearPreviousCommand = clearPreviousCommand;
            _clearAllCommand = clearAllCommand;
            _quitCommand = quitCommand;
        }

        public bool Operand(double v1)
        {
            return _operand.Execute(v1);
        }

        public bool Add()
        {
            return _addCommand.Execute();
        }

        public bool Subtract()
        {
            return _subtractCommand.Execute();
        }

        public bool Multiply()
        {
            return _multiplyCommand.Execute();
        }

        public bool Divide()
        {
            return _divideCommand.Execute();
        }

        public bool Reciprocal()
        {
            return _reciprocalCommand.Execute();
        }

        public bool Factorial()
        {
            return _factorialCommand.Execute();
        }

        public bool Equals()
        {
            return _equalsCommand.Execute();
        }

        public bool ClearPrevious()
        {
            return _clearPreviousCommand.Execute();
        }

        public bool ClearAll()
        {
            return _clearAllCommand.Execute();
        }

        public bool Quit()
        {
            return _quitCommand.Execute();
        }
    }
}