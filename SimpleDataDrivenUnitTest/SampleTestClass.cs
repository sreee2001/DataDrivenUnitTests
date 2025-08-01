using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleDataDrivenUnitTest
{
    [TestClass]
    public class SampleTestClass
    {
        [DataTestMethod]
        [DataRow(2, 3, 5)] // Passing case
        [DataRow(10, 20, 30)] // Passing case
        [DataRow(-1, 1, 0)] // Passing case
        [DataRow(1, 2, 2)] // Failing case
        public void AdditionTest(int a, int b, int expected)
        {
            // Act
            int actual = a + b;

            // Assert
            Assert.AreEqual(expected, actual, $"Addition of {a} and {b} should be {expected}.");
        }
    }
}
