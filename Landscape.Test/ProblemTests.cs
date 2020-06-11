using System;
using NUnit.Framework;

namespace Landscape.Test
{
    public class ProblemTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTest()
        {
            var landscape = new int[] { 5, 2, 3, 4, 5, 4, 1, 3, 1};
            var result = Problem.Solve(landscape);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void WrongDataTest()
        {
            var landscape = new int[] { 12, 32, 0, -1 };
            var exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The hill heights values must be between 0 and {Problem.MaxHeightValues}"));

            landscape = new int[] { Problem.MaxHeightValues + 1 };
            exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The hill heights values must be between 0 and {Problem.MaxHeightValues}"));

            landscape = new int[Problem.MaxLandscapeSize];
            exc = Assert.Throws<ArgumentException>(() => Problem.Solve(landscape));
            Assert.That(exc.Message, Is.EqualTo($"The max landscape size is {Problem.MaxLandscapeSize}"));
        }
    }
}