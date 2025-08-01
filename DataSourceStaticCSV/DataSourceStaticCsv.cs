using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataSourceStaticCSV
{
    [TestClass]
    public class DataSourceStaticCsv
    {
        public TestContext TestContext { get; set; }

        private int _left = 0;
        private int _right = 0;
        private bool _areEqual = false;
        private int _sum = 0;
        private int _mul = 0;

        [ClassInitialize]
        public static void ClassInitializer(TestContext testContext)
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "ExampleInputData.csv",
            "ExampleInputData#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("ExampleInputData.csv")]
        [TestMethod]
        public void AreEqual()
        {
            _left = (int)TestContext.DataRow[0];
            _right = (int)TestContext.DataRow[1];
            _areEqual = (int)TestContext.DataRow[2] != 0;

            Assert.AreEqual(_left == _right, _areEqual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "ExampleInputData.csv",
            "ExampleInputData#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("ExampleInputData.csv")]
        [TestMethod]
        public void SumTest()
        {
            _left = (int)TestContext.DataRow[0];
            _right = (int)TestContext.DataRow[1];
            _sum = (int)TestContext.DataRow[3];

            Assert.AreEqual(_left + _right, _sum);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "ExampleInputData.csv",
            "ExampleInputData#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("ExampleInputData.csv")]
        [TestMethod]
        public void MulTest()
        {
            _left = (int)TestContext.DataRow[0];
            _right = (int)TestContext.DataRow[1];
            _mul = (int)TestContext.DataRow[4];

            Assert.AreEqual(_left * _right, _mul);
        }
    }
}
