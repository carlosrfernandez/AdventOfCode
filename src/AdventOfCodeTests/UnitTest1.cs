using System;
using AdventOfCode.Day4;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DateTimeExTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var sleep = new DateTime(2018, 12, 01, 0, 0, 0);
            var wake = new DateTime(2018, 12, 01, 4, 25, 0);

            const double expectedResult = 60 * 4 + 25 - 1;

            var result = sleep.SubtractMinutesFromOther(wake);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}