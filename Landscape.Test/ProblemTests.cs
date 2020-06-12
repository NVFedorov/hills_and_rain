using System;
using NUnit.Framework;

namespace Landscape.Test
{
    public class ProblemTests
    {
        [Test]
        public void Should_Return_Zero_For_Downhill_No_Pits()
        {
            var landscape = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Should_Return_Zero_For_Uphill_No_Pits()
        {
            var landscape = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Should_Solve_For_Downhill_With_Pits()
        {
            var landscape = new int[] { 9, 7, 8, 5, 6, 3, 4, 1, 2 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Should_Solve_For_Uphill_With_Pits()
        {
            var landscape = new int[] { 2, 1, 4, 3, 6, 5, 8, 7, 9 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Should_Solve_For_Down_Vallye_Up()
        {
            var landscape = new int[] { 9, 8, 7, 6, 6, 6, 7, 8, 9 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Should_Return_Zero_For_Up_Down()
        {
            var landscape = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Should_Solve_For_Up_Down_Up_Down_Up()
        {
            var landscape = new int[] { 1, 2, 3, 2, 5, 1, 2, 3, 4 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Should_Solve_For_Start_With_Uphill()
        {
            var landscape = new int[] { 1, 2, 3, 4, 5, 4, 1, 3, 1 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Should_Solve_For_Complex_Pit()
        {
            var landscape = new int[] { 7, 2, 3, 4, 5, 4, 1, 3, 6 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Should_Solve_For_Two_Complex_Pits()
        {
            var landscape = new int[] { 9, 5, 2, 4, 5, 10, 4, 8, 3, 21 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(35, result);
        }

        [Test]
        public void Should_Solve_For_Two_Pits_With_Plato_Between()
        {
            var landscape = new int[] { 5, 1, 2, 1, 5, 5, 5, 5, 3, 21 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(13, result);
        }

        [Test]
        public void Should_Solve_For_Three_Pits()
        {
            var landscape = new int[] { 5, 2, 3, 4, 3, 4, 1, 3, 1 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Should_Solve_For_Three_Complex_Pits()
        {
            var landscape = new int[] { 10, 1, 5, 3, 9, 1, 3, 5, 3, 8, 3, 4, 5, 5, 4, 7, 1 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(52, result);
        }

        [Test]
        public void Should_Return_Zero_When_Landscape_Length_Is_One()
        {
            var landscape = new int[1];
            var result = Problem.Solve(landscape);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Should_Return_Zero_When_Flat()
        {
            var landscape = new int[Problem.MaxLandscapeSize];
            var result = Problem.Solve(landscape);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Should_Throw_Exceptions_For_WrongData()
        {
            var landscape = new int[] { 12, 32, 0, -1 };
            var exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The hill heights values must be between 0 and {Problem.MaxHeightValues}"));

            landscape = new int[] { 12, 32, -1, 1 };
            exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The hill heights values must be between 0 and {Problem.MaxHeightValues}"));

            landscape = new int[] { 12, Problem.MaxHeightValues + 1, 0 };
            exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The hill heights values must be between 0 and {Problem.MaxHeightValues}"));

            landscape = new int[Problem.MaxLandscapeSize + 1];
            exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The max landscape size is {Problem.MaxLandscapeSize}"));
        }

        // just in case
        [Test]
        public void Should_Solve_For_Long_Downhill()
        {
            var landscape = new int[] { 5, 2, 3, 4, 3, 2, 1, 4, 1 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Should_Solve_For_LongDownhill_2()
        {
            var landscape = new int[] { 5, 4, 3, 2, 1, 5, 4, 5, 6 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(11, result);
        }

        [Test]
        public void Should_Solve_For_Uphill_With_Small_Pits()
        {
            var landscape = new int[] { 1, 3, 2, 4, 3, 5, 4, 3, 7 };
            var result = Problem.Solve(landscape);
            Assert.AreEqual(5, result);
        }
    }
}