﻿using System;
using NUnit.Framework;

namespace TDD_Katas_project.StringCalculator
{
    [TestFixture]
    public class TestCalculator
    {
        [TestCase("")]
        [TestCase(null)]
        [Test]
        public void AddReturnZeroWhenSuppliedEmptyOrNullString(string numbers)
        {
            var result = Calculator.Add(numbers);
            Assert.That(result, Is.EqualTo(0));
        }
        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("0,1,2,3,4,555", 565)]
        [Test]
        public void AddReturnNumberWhenSuppliedSingleNumberInString(string number, int expectedResult)
        {
            var result = Calculator.Add(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [TestCase("1,2,3", 6)]
        [TestCase("3\n2", 5)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2\n3,4,5", 15)]
        [Test]
        public void AddReturSumWhenSuppliedNumbersInStringWithNewLineAsDelimiter(string numbers, int expectedResult)
        {
            var result = Calculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [TestCase("0,1", 1)]
        [TestCase("0,1,1", 2)]
        [TestCase("0,2", 2)]
        [TestCase("0,2,2", 4)]
        [TestCase("0,3", 3)]
        [TestCase("0,3,2", 5)]
        [TestCase("0,3,3", 6)]
        [TestCase("0,3,2,", 5)]
        [Test]
        public void AddReturnSumWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = Calculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [TestCase("0,3,1001,", 3)]
        [Test]
        public void AddReturnSumByIgnoringMoreThanThousandWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = Calculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [TestCase("//;\n1;2", 3)]
        [Test]
        public void Add_WhenGivenDefinedDelimiter_UsesThatDelimiter(string input, int expectation)
        {
            var result = Calculator.Add(input);

            Assert.That(result, Is.EqualTo(expectation));
        }
        [TestCase("1,-1", -1)]
        [Test]
        public void AddThrowArgumentExceptionWhenSuppliedStringDoesNotMeetRule(string numbers, int beyondRuleNumber)
        {
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Add(numbers));

            Assert.That(exception.Message, Is.EqualTo(string.Format("string contains [{0}], which does not meet rule. entered number should not negative.", beyondRuleNumber)));

        }
    }
}
