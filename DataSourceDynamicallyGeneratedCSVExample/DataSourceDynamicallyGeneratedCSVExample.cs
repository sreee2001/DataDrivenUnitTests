using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataSourceDynamicallyGenaratedCSVExample
{
    [TestClass]
    public class DataSourceDynamicallyGenaratedCSVExample
    {
        public TestContext TestContext { get; set; }

        private string left;
        private string right;

        [ClassInitialize]
        public static void ClassInitializer(TestContext testContext)
        {
            var param = new List<object> { "seed", "COV", "Has Selection?", "P10", "Mean", "Name", "SOme other Text", "GOS" };
            var geox62Data   = new List<object> { 1, 33, true, 0.99, 0.345, "abc", "no match", null };
            var geox2018Data = new List<object> { 1, 32, true, 0.99, 0.345, "Abc", "no match", null };

            if (geox62Data.Count != geox2018Data.Count && geox62Data.Count != param.Count)
            {
                Logger.LogMessage("Data Mismatch for Geox62 and Geox2018");
                return;
            }

            string[] csvData = new string[geox62Data.Count + 1];
            csvData[0] = "Param,Geox62,Geox2018";

            for (int i = 0; i < geox62Data.Count; i++)
            {
                csvData[i + 1] = param[i] + "," + geox62Data[i] + "," + geox2018Data[i];
            }

            File.WriteAllLines("TestingGeox.csv", csvData);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            left = TestContext.DataRow[1].ToString();
            right = TestContext.DataRow[2].ToString();
        }

        /// <summary>
        /// Executes a data-driven test using values from a CSV file.
        /// </summary>
        /// <remarks>
        /// This test method reads data sequentially from the specified CSV file and performs
        /// assertions based on the data. 
        /// The CSV file must be deployed alongside the test and contain the required
        /// columns for the test logic.
        /// This test will fail if the values in the "Geox62" and "Geox2018" columns do not match for each row.
        /// </remarks>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "TestingGeox.csv",
            "TestingGeox#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("TestingGeox.csv")]
        [TestMethod]
        public void DataDrivenComparisionTest()
        {
            Logger.LogMessage($"Running test with Column: {TestContext.DataRow[0]}");
            Assert.AreEqual(left, right, $"\n{TestContext.DataRow[0]} data mismatch. Geox62 : {left}, Geox 2012 : {right}");
        }
    }
}
