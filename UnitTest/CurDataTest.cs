using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for CurDataTest and is intended
    ///to contain all CurDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CurDataTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetCurRates
        ///</summary>
        [TestMethod()]
        public void GetCurRatesTest()
        {
            string fromCode = string.Empty; // TODO: Initialize to an appropriate value
            string toCode = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<ExRate> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<ExRate> actual;
            actual = CurData.GetCurRates(fromCode, toCode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllCur
        ///</summary>
        [TestMethod()]
        public void GetAllCurTest()
        {
            IEnumerable<Currency> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Currency> actual;
            actual = CurData.GetAllCur();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CurData Constructor
        ///</summary>
        [TestMethod()]
        public void CurDataConstructorTest()
        {
            CurData target = new CurData();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
