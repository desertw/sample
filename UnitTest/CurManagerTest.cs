using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Common;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for CurManagerTest and is intended
    ///to contain all CurManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CurManagerTest
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
        ///A test for CurManager Constructor
        ///</summary>
        [TestMethod()]
        public void CurManagerConstructorTest()
        {
            CurManager target = new CurManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAllCurrencyCode
        ///</summary>
        [TestMethod()]
        public void GetAllCurrencyCodeTest()
        {
            CurrencyCodes expected = null; // TODO: Initialize to an appropriate value
            CurrencyCodes actual;
            actual = CurManager.GetAllCurrencyCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCurRates
        ///</summary>
        [TestMethod()]
        public void GetCurRatesTest()
        {
            string fromCode = string.Empty; // TODO: Initialize to an appropriate value
            string toCode = string.Empty; // TODO: Initialize to an appropriate value
            CurrencyRates expected = null; // TODO: Initialize to an appropriate value
            CurrencyRates actual;
            actual = CurManager.GetCurRates(fromCode, toCode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
