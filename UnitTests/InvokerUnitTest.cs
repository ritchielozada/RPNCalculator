// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class InvokerUnitTest
    {
        // Special Case Handling for Factorial
        // if Input Parser blocks incorrect operand for Factorial
        // and enforce Factorial as an Operand value instead of Unary Operator
        // ex.  Regex = "([0-9]+!)" to block negative, decimal or invalid values
        [TestMethod]
        public void Invoker_T00_Factorial()
        {
            var receiver = new Receiver();
            var invoker = new Invoker(
                new Operand(receiver),
                new AddCommand(receiver),
                new SubtractCommand(receiver),
                new MultiplyCommand(receiver),
                new DivideCommand(receiver),
                new ReciprocalCommand(receiver),
                new FactorialCommand(receiver),
                new EqualsCommand(receiver),
                new ClearPreviousCommand(receiver),
                new ClearAllCommand(receiver),
                new QuitCommand(receiver)
            );

            invoker.Operand(5);
            var invokerResult = invoker.Factorial();
            var result = receiver.CurrentValue;
            Assert.IsTrue(invokerResult);
            Assert.AreEqual(120, result);
        }

        [TestMethod]
        public void Invoker_T01_FactorialError()
        {
            var receiver = new Receiver();
            var invoker = new Invoker(
                new Operand(receiver),
                new AddCommand(receiver),
                new SubtractCommand(receiver),
                new MultiplyCommand(receiver),
                new DivideCommand(receiver),
                new ReciprocalCommand(receiver),
                new FactorialCommand(receiver),
                new EqualsCommand(receiver),
                new ClearPreviousCommand(receiver),
                new ClearAllCommand(receiver),
                new QuitCommand(receiver)
            );

            invoker.Operand(-5);
            var invokerResult = invoker.Factorial();
            var result = receiver.CurrentValue;
            Assert.IsFalse(invokerResult);
            Assert.AreEqual(-5, result);
        }


        [TestMethod]
        public void Invoker_T02_FactorialNonIntError()
        {
            var receiver = new Receiver();
            var invoker = new Invoker(
                new Operand(receiver),
                new AddCommand(receiver),
                new SubtractCommand(receiver),
                new MultiplyCommand(receiver),
                new DivideCommand(receiver),
                new ReciprocalCommand(receiver),
                new FactorialCommand(receiver),
                new EqualsCommand(receiver),
                new ClearPreviousCommand(receiver),
                new ClearAllCommand(receiver),
                new QuitCommand(receiver)
            );

            invoker.Operand(1.1);
            var invokerResult = invoker.Factorial();
            var result = receiver.CurrentValue;
            Assert.IsFalse(invokerResult);
            Assert.AreEqual(1.1, result);
        }

        [TestMethod]
        public void Invoker_T03_FactorialPositiveInfinityError()
        {
            var receiver = new Receiver();
            var invoker = new Invoker(
                new Operand(receiver),
                new AddCommand(receiver),
                new SubtractCommand(receiver),
                new MultiplyCommand(receiver),
                new DivideCommand(receiver),
                new ReciprocalCommand(receiver),
                new FactorialCommand(receiver),
                new EqualsCommand(receiver),
                new ClearPreviousCommand(receiver),
                new ClearAllCommand(receiver),
                new QuitCommand(receiver)
            );

            invoker.Operand(double.PositiveInfinity);
            var invokerResult = invoker.Factorial();
            var result = receiver.CurrentValue;
            Assert.IsFalse(invokerResult);
            Assert.AreEqual(double.PositiveInfinity, result);
        }

        [TestMethod]
        public void Invoker_T03_FactorialNegativeInfinityError()
        {
            var receiver = new Receiver();
            var invoker = new Invoker(
                new Operand(receiver),
                new AddCommand(receiver),
                new SubtractCommand(receiver),
                new MultiplyCommand(receiver),
                new DivideCommand(receiver),
                new ReciprocalCommand(receiver),
                new FactorialCommand(receiver),
                new EqualsCommand(receiver),
                new ClearPreviousCommand(receiver),
                new ClearAllCommand(receiver),
                new QuitCommand(receiver)
            );

            invoker.Operand(double.NegativeInfinity);
            var invokerResult = invoker.Factorial();
            var result = receiver.CurrentValue;
            Assert.IsFalse(invokerResult);
            Assert.AreEqual(double.NegativeInfinity, result);
        }

        [TestMethod]
        public void Invoker_T03_FactorialNaNError()
        {
            var receiver = new Receiver();
            var invoker = new Invoker(
                new Operand(receiver),
                new AddCommand(receiver),
                new SubtractCommand(receiver),
                new MultiplyCommand(receiver),
                new DivideCommand(receiver),
                new ReciprocalCommand(receiver),
                new FactorialCommand(receiver),
                new EqualsCommand(receiver),
                new ClearPreviousCommand(receiver),
                new ClearAllCommand(receiver),
                new QuitCommand(receiver)
            );

            invoker.Operand(double.NaN);
            var invokerResult = invoker.Factorial();
            var result = receiver.CurrentValue;
            Assert.IsFalse(invokerResult);
            Assert.AreEqual(double.NaN, result);
        }
    }
}