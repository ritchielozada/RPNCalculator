# RPNCalculator
RPN Calculator Implementation using Command Pattern

#### Usage

Line based input for infix arithmetic equations. Supports the following operators:

- '+' Add
- '-' Subtract
- '\*' Multiply
- '/' Divide
- '1/X' Reciprocal
- '!' Factorial

- Parenthesis precedence

Supports Inline Clear (C) and All Clear (A) Functions


#### Notes

1. Input is based on Infix Equation, the Receiver is implemented internally using RPN (Reverse Polish Notation) to manage operator precedence on parsed equation vs. Interactive User calculator operand and operator value input.

2. RPN Calculator stack implemented with extensions to support Pop() and Peek() operations on empty collection, similar behavior on HP RPN Calculators.  Pop() and Peek() on empty stack returns '0' and operator results and last operand values on error are always pushed to the stack.

3. Unit Test Coverage is at 100% for all code blocks in Calculator DLL.

4. Implemented on Visual Studio Enterprise 2017 v15.5.6.  Dependent on MSTest.TestAdapter.1.2.0 and MSTest.TestFramework.1.2.0 for Test package.

5. Will support additional function operators such as SQR, POW and SQRT
