using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTest.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        #region inputData

        [TestMethod]
        [TestCategory("CalculatorInputData")]
        public void CalculateOnePlusOne()
        {
            var calculator = new Calculator();
            calculator.EnterNumber(N.One);
            calculator.SetOperation(Op.Add);
            calculator.EnterNumber(N.One);
            var result = calculator.SetOperation(Op.Equals);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        [TestCategory("CalculatorInputData")]
        public void CalculateOnePlusOnePlusOne()
        {
            var calculator = new Calculator();
            calculator.EnterNumber(N.One);
            calculator.SetOperation(Op.Add);
            calculator.EnterNumber(N.One);
            calculator.SetOperation(Op.Add);
            calculator.EnterNumber(N.One);
            var result = calculator.SetOperation(Op.Equals);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("CalculatorInputData")]
        public void CalculateOnePlusTwoPlusThree()
        {
            var calculator = new Calculator();
            calculator.EnterNumber(1);
            calculator.SetOperation(Op.Add);
            calculator.EnterNumber(2);
            calculator.SetOperation(Op.Add);
            calculator.EnterNumber(3);
            var result = calculator.SetOperation(Op.Equals);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [TestCategory("CalculatorInputData")]
        public void CalculateOperations()
        {
            var calculator = new Calculator();
            calculator.EnterNumber(1);
            calculator.SetOperation(Op.Multiply);
            calculator.EnterNumber(16);
            calculator.SetOperation(Op.Subtract);
            calculator.EnterNumber(N.Seven);
            var result = calculator.SetOperation(Op.Equals);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        [TestCategory("CalculatorInputData")]
        public void BigNumbers()
        {
            var calculator = new Calculator();
            calculator.EnterNumber(double.MaxValue);
            calculator.SetOperation(Op.Multiply);
            calculator.EnterNumber(2);
            var result = calculator.SetOperation(Op.Equals);
            Assert.AreEqual(double.PositiveInfinity, result);
        }

        [TestMethod]
        [TestCategory("CalculatorInputData")]
        public void SequentialNumbers()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(N.One);
            caluclator.EnterNumber(23);
            caluclator.SetOperation(Op.Add);
            caluclator.EnterNumber(N.Three);
            caluclator.EnterNumber(2);
            caluclator.EnterNumber(1);
            var result = caluclator.SetOperation(Op.Equals);
            Assert.AreEqual(444, result);
        }

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void NegativeNumbers()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(-1);
            caluclator.SetOperation(Op.Add);
            caluclator.EnterNumber(-1);
            var result = caluclator.SetOperation(Op.Equals);
            Assert.AreEqual(-2, result);
        }

        #endregion

        #region outputData

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void EqualOne()
        {
            var calculator = new Calculator();
            double result = 0;
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                calculator.EnterNumber(1d / n);
                result = calculator.SetOperation(Op.Add);
            }
            Assert.AreEqual(1, result);

        }
        
        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void RandomEqual()
        {
            var t = new Random();
            var calculator = new Calculator();
            var result = 0d;
            var actual = 0d;
            for (int i = 0; i < 6; i++)
            {
                int n = t.Next();
                calculator.EnterNumber(n);
                result = calculator.SetOperation(Op.Add);
                actual += n;
            }
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void EqualTwo()
        {
            var calculator = new Calculator();
            calculator.EnterNumber(1);
            calculator.SetOperation(Op.Divide);
            calculator.EnterNumber(19);
            calculator.SetOperation(Op.Multiply);
            calculator.EnterNumber(38);
            var result = calculator.SetOperation(Op.Equals);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void EqualZero()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(-1);
            caluclator.SetOperation(Op.Subtract);
            caluclator.EnterNumber(-1);
            var result = caluclator.SetOperation(Op.Equals);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void EqualZero2()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(1);
            caluclator.SetOperation(Op.Multiply);
            caluclator.EnterNumber(0d);
            var result = caluclator.SetOperation(Op.Equals);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void Infinities()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(double.PositiveInfinity);
            caluclator.SetOperation(Op.Add);
            caluclator.EnterNumber(double.NegativeInfinity);
            var result = caluclator.SetOperation(Op.Equals);
            Assert.AreEqual((double.PositiveInfinity + double.NegativeInfinity), result);
        }

        [TestMethod]
        [TestCategory("CalculatorOutputData")]
        public void Epsilons()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(double.Epsilon);
            caluclator.SetOperation(Op.Add);
            caluclator.EnterNumber(double.Epsilon);
            var result = caluclator.SetOperation(Op.Equals);
            Assert.AreEqual((double.Epsilon + double.Epsilon), result);
        }

        #endregion

        #region dataRange

        [TestMethod]
        [TestCategory("CalculatorDataRange")]
        public void Infinity() => Infinities();

        [TestMethod]
        [TestCategory("CalculatorDataRange")]
        public void Epsilon() => Epsilons();

        [TestMethod]
        [TestCategory("CalculatorDataRange")]
        public void NaNs()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(Double.NaN);
            caluclator.SetOperation(Op.Add);
            caluclator.EnterNumber(Double.NaN);
            var result = caluclator.SetOperation(Op.Equals);
            var actual = Double.NaN;
            actual += Double.NaN;
            Assert.AreEqual(result, actual);
        }

        #endregion

        #region Exceptions

        [TestMethod]
        [TestCategory("CalculatorExceptions")]
        public void DivideByZero()
        {
            var caluclator = new Calculator();
            caluclator.EnterNumber(1);
            caluclator.SetOperation(Op.Divide);
            caluclator.EnterNumber(0d);
            double result = 0d;
            Assert.ThrowsException<DivideByZeroException>(() => result = caluclator.SetOperation(Op.Equals));
        }

        #endregion

        //классы входных данных
        //классы выходных данных
        //границы данных
        //выходные/исключительные ситуации
    }
}