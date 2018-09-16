using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTest.Tests
{
    [TestClass]
    public class StupidMathsTests
    {
        #region Homework1

        //1. Функция удаляет из списка каждый второй элемент(на вход элементы массива перечисленные через запятую в строке, к примеру, "1.2, 2, 3.5").

        #region RemoveEvens

        [TestMethod]
        public void RemoveEvens()
        {
            var input = "";
            var shouldBe = "";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void RemoveEvens_SuggestedTest()
        {
            var input = "1.2, 2, 3.5";
            var shouldBe = "1.2, 3.5";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void RemoveEvens_OneElement()
        {
            var input = "10";
            var shouldBe = "10";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void RemoveEvens_TwoElements()
        {
            var input = "1, 5.2";
            var shouldBe = "1";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void RemoveEvens_Commas()
        {
            var input = ",,,,,";
            var shouldBe = ",,";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void RemoveEvens_InputLetters()
        {
            var input = "a, b, c, d, e, f, g, h";
            var shouldBe = "a, c, e, g";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void RemoveEvens_InputLettersNumbers()
        {
            var input = "aa, b, ccc, ddd, 11, ef, gh, 98";
            var shouldBe = "aa, ccc, 11, gh";
            var reallyIs = StupidMaths.RemoveEvens(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        #endregion RemoveEvens

        //2. Найти корни квадратного уравнения, заданного своими коэффициентами.Предусмотреть все возможные случаи (два действительных корня, один корень, нет корней). На вход коэф.a,b,c(тип double).

        #region SolveEquations

        [TestMethod]
        public void SolveEquation()
        {
            var input = new double[] {0, 0, 0};
            var shouldBe = new double[] { };
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_NoRoots()
        {
            var input = new double[] {1, 0, 1};
            var shouldBe = new double[] { };
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_NoRootsBigNumbers()
        {
            var input = new double[] {1000000, 1, 1000000};
            var shouldBe = new double[] { };
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_OneZeroRoot()
        {
            var input = new double[] {1, 0, 0};
            var shouldBe = new double[] {0};
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_OneNegativeRoot()
        {
            var input = new double[] {1, 2, 1};
            var shouldBe = new double[] {-1};
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_OneRealRoot()
        {
            var input = new double[] {1, -Math.Sqrt(2) * 2, 2};
            var shouldBe = new double[] {Math.Sqrt(2)};
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_TwoOppositeRoots()
        {
            var input = new double[] {1, 0, -1};
            var shouldBe = new double[] {1, -1};
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_TwoDifferentRoots()
        {
            var input = new double[] {-1, -2, 15};
            var shouldBe = new double[] {3, -5};
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_NegativeInfinity()
        {
            var input = new double[] {double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity};
            var shouldBe = new double[] { };
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_PositiveInfinity()
        {
            var input = new double[] {double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity};
            var shouldBe = new double[] { };
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        [TestMethod]
        public void SolveEquation_Epsilon()
        {
            var input = new double[] {double.Epsilon, double.Epsilon, double.Epsilon};
            var shouldBe = new double[] { };
            var reallyIs = StupidMaths.SolveEquaiton(input[0], input[1], input[2]);
            CollectionAssert.AreEquivalent(shouldBe, reallyIs);
        }

        #endregion SolveEquations

        //3. Положения ферзей на шахматной доске заданы списком пар(горизонталь, вертикаль). Определить, имеется ли пара ферзей, бьющих друг друга.

        #region DoCapture

        [TestMethod]
        public void DoCapture()
        {
            var input = new Tuple<byte, byte>[] { };
            var shouldBe = false;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void DoCapture_OnePiece()
        {
            var input = new[]
            {
                new Tuple<byte, byte>(0, 0)
            };
            var shouldBe = false;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void DoCapture_BigNumbers()
        {
            var input = new[]
            {
                new Tuple<byte, byte>(99, 99),
                new Tuple<byte, byte>(120, 120)
            };

            var shouldBe = false;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void DoCapture_LikeKnights()
        {
            var input = new[]
            {
                new Tuple<byte, byte>(0, 0),
                new Tuple<byte, byte>(1, 2)
            };
            var shouldBe = false;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void DoCapture_LikeKnightsButMorePieces()
        {
            var input = new[]
            {
                new Tuple<byte, byte>(0, 0),
                new Tuple<byte, byte>(1, 2),
                new Tuple<byte, byte>(2, 4),
                new Tuple<byte, byte>(3, 6)
            };
            var shouldBe = false;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void DoCapture_FourCorners()
        {
            var input = new[]
            {
                new Tuple<byte, byte>(0, 0),
                new Tuple<byte, byte>(7, 7),
                new Tuple<byte, byte>(0, 7),
                new Tuple<byte, byte>(7, 0)
            };
            var shouldBe = true;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void DoCapture_FullBoard()
        {
            var input = new[]
            {
                new Tuple<byte, byte>(0, 0),
                new Tuple<byte, byte>(0, 1),
                new Tuple<byte, byte>(0, 2),
                new Tuple<byte, byte>(0, 3),
                new Tuple<byte, byte>(0, 4),
                new Tuple<byte, byte>(0, 5),
                new Tuple<byte, byte>(0, 6),
                new Tuple<byte, byte>(0, 7),
                new Tuple<byte, byte>(1, 0),
                new Tuple<byte, byte>(1, 1),
                new Tuple<byte, byte>(1, 2),
                new Tuple<byte, byte>(1, 3),
                new Tuple<byte, byte>(1, 4),
                new Tuple<byte, byte>(1, 5),
                new Tuple<byte, byte>(1, 6),
                new Tuple<byte, byte>(1, 7),
                new Tuple<byte, byte>(2, 0),
                new Tuple<byte, byte>(2, 1),
                new Tuple<byte, byte>(2, 2),
                new Tuple<byte, byte>(2, 3),
                new Tuple<byte, byte>(2, 4),
                new Tuple<byte, byte>(2, 5),
                new Tuple<byte, byte>(2, 6),
                new Tuple<byte, byte>(2, 7),
                new Tuple<byte, byte>(3, 0),
                new Tuple<byte, byte>(3, 1),
                new Tuple<byte, byte>(3, 2),
                new Tuple<byte, byte>(3, 3),
                new Tuple<byte, byte>(3, 4),
                new Tuple<byte, byte>(3, 5),
                new Tuple<byte, byte>(3, 6),
                new Tuple<byte, byte>(3, 7),
                new Tuple<byte, byte>(4, 0),
                new Tuple<byte, byte>(4, 1),
                new Tuple<byte, byte>(4, 2),
                new Tuple<byte, byte>(4, 3),
                new Tuple<byte, byte>(4, 4),
                new Tuple<byte, byte>(4, 5),
                new Tuple<byte, byte>(4, 6),
                new Tuple<byte, byte>(4, 7),
                new Tuple<byte, byte>(5, 0),
                new Tuple<byte, byte>(5, 1),
                new Tuple<byte, byte>(5, 2),
                new Tuple<byte, byte>(5, 3),
                new Tuple<byte, byte>(5, 4),
                new Tuple<byte, byte>(5, 5),
                new Tuple<byte, byte>(5, 6),
                new Tuple<byte, byte>(5, 7),
                new Tuple<byte, byte>(6, 0),
                new Tuple<byte, byte>(6, 1),
                new Tuple<byte, byte>(6, 2),
                new Tuple<byte, byte>(6, 3),
                new Tuple<byte, byte>(6, 4),
                new Tuple<byte, byte>(6, 5),
                new Tuple<byte, byte>(6, 6),
                new Tuple<byte, byte>(6, 7),
                new Tuple<byte, byte>(7, 0),
                new Tuple<byte, byte>(7, 1),
                new Tuple<byte, byte>(7, 2),
                new Tuple<byte, byte>(7, 3),
                new Tuple<byte, byte>(7, 4),
                new Tuple<byte, byte>(7, 5),
                new Tuple<byte, byte>(7, 6),
                new Tuple<byte, byte>(7, 7),
            };
            var shouldBe = true;
            var reallyIs = StupidMaths.DoCapture(input);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        #endregion DoCapture

        #endregion Homework1

        #region Lesson1

        #region Sum

        [TestMethod]
        public void Sum1()
        {
            var array = new[] {9};
            var shouldBe = 9;
            var reallyIs = StupidMaths.Sum(array);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void Sum2()
        {
            var array = new[] {1, 2};
            var shouldBe = 3;
            var reallyIs = StupidMaths.Sum(array);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void Sum3()
        {
            var array = new[] {1, 4, 3};
            var shouldBe = 8;
            var reallyIs = StupidMaths.Sum(array);
            Assert.AreEqual(shouldBe, reallyIs);
        }

        #endregion Sum

        #region ParseNumbers

        [TestMethod]
        public void ParseNumbers1()
        {
            var input = "1, 3, 5, 7, 8";
            var shouldBe = new[] {1, 3, 5, 7, 8};
            var reallyIs = StupidMaths.ParseNumbers(input);
            CollectionAssert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void ParseNumbers2()
        {
            var input = "1";
            var shouldBe = new[] {1};
            var reallyIs = StupidMaths.ParseNumbers(input);
            CollectionAssert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void ParseNumbers3()
        {
            var input = "";
            var shouldBe = new int[0];
            var reallyIs = StupidMaths.ParseNumbers(input);
            CollectionAssert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void ParseNumbers4()
        {
            var input = " , ";
            var shouldBe = new int[0];
            var reallyIs = StupidMaths.ParseNumbers(input);
            CollectionAssert.AreEqual(shouldBe, reallyIs);
        }

        [TestMethod]
        public void ParseNumbers5()
        {
            var input = "ж, о, п, 2  5    а";
            var shouldBe = new[] {2, 5};
            var reallyIs = StupidMaths.ParseNumbers(input);
            CollectionAssert.AreEqual(shouldBe, reallyIs);
        }

        #endregion ParseNumbers

        #endregion Lesson1
    }
}