using NUnit.Framework;
using System;
using warsztat4;

namespace warsztat4test
{
    public class StringCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "1,2")]
        [TestCase(3, "1\n2")]
        [TestCase(6, "1\n2,3")]
        [TestCase(6, "//;\n1;2;3")]
        [TestCase(6, "//[*][%]\n1*2%3")]
        [TestCase(2, "//;\n1001;2")]
        public void ShouldReturnSum(int testResult, string numbers)
        {
            var stringCalculator = new StringCalculator();

            Assert.That(() => stringCalculator.Add(numbers), Is.EqualTo(testResult));
        }

        [Test]
        public void ShouldReturnZeroByEmptyString()
        {
            var stringCalculator = new StringCalculator();

            Assert.That(() => stringCalculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        public void ShouldThrowException()
        {
            var stringCalculator = new StringCalculator();

            Assert.That(() => stringCalculator.Add("a,b,c"), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void ShouldThrowArgumentException()
        {
            var stringCalculator = new StringCalculator();

            Assert.That(() => stringCalculator.Add("-1,-2,3"), Throws.TypeOf<ArgumentException>().With.Message.Contain("negatives not allowed"));
        }
    }
}