// Licensed under the MIT License. See LICENSE in the project root for license information.
// 
// Reference Code Implementation for Command Pattern Based Calculator (Calculator 2018-02)
// 
// Ritchie Lozada (@rlozada)

using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CalculateUnitTests
    {
        [TestMethod]
        public void T00_Calculation()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("5+2=", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(7, result);
            parseResult = client.Parse("+3=", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void T01_CalculationWithClear()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("12 - 8 * 3 C + 5 =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void T01_CalculationWithClear2()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("12 C - 8 * 3 C + 5 C + 3 =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void T01_CalculationWithClear3()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("1 + 3 C =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void T02_Calculation()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("1/3=", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.IsTrue(Math.Abs(0.333333333333333 - result) < 0.000000001);
        }

        [TestMethod]
        public void T03_CalculationOperatorReplacement()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("1 * + - 3 =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void T04_Calculation()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("-10 * 5 - 20 / 4 =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(-55, result);
        }

        [TestMethod]
        public void T05_Calculation()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("5 1/X A + 9=", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(9, result);
        }


        [TestMethod]
        public void T06_Factorial()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("3! =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void T07_Factorial()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("5!=", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(120, result);
        }

        [TestMethod]
        public void T08_RpnPeek()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("=", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void T09_Quit()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("Q", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void T10_OperatorReplacement()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("2 * + 3 =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void T11_Factorial0()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("0! =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void T12_Factorial1()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("1! =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void T12_Factorial2()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("2! =", out result, out errorMessage);
            Assert.IsTrue(parseResult);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void T12_FactorialError()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("-5! =", out result, out errorMessage);
            // Token is BLOCKED for Factorial

            Assert.IsFalse(parseResult);
            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        public void T13_DivideByZero()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("1 / 0 =", out result, out errorMessage);
            Assert.IsFalse(parseResult);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void T14_ReciprocalDivideByZeroError()
        {
            var client = new Client();
            double result;
            string errorMessage;

            var parseResult = client.Parse("0 1/X =", out result, out errorMessage);
            Assert.IsFalse(parseResult);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void T15_MaximumInputLenError()
        {
            var client = new Client(10);
            double result;
            string errorMessage;

            var parseResult = client.Parse("1 + 2 + 3 =", out result, out errorMessage);
            Assert.IsFalse(parseResult);
            Assert.AreEqual(0, result);
        }
    }
}