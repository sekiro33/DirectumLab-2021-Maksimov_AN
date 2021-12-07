using NUnit.Framework;
using System;

namespace Task_8.Tests
{
  public class ValueComparatorTests
  {
    [Test]
    [TestCase(25, 2130, -21414, ExpectedResult = 2130)]
    [TestCase(0, 0, 0, ExpectedResult = 0)]
    [TestCase(-200, -190, -10, ExpectedResult = -10)]
    [TestCase(-0.00001, -0.01, -1.001, ExpectedResult = -0.00001)]
    [TestCase("aaa", "aaaaa", null, ExpectedResult = "aaaaa")]
    public object GetMaxValueTest<T>(T firstValue, T secondValue, T thirdValue) where T : IComparable<T>
    {
      return ValueComparator<T>.CompareValues(firstValue, secondValue, thirdValue);
    }
  }
}