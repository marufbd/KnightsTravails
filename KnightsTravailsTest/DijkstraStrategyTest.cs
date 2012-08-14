using KnightsTravails;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KnightsTravailsTest
{
    
    
    /// <summary>
    ///This is a test class for DijkstraStrategyTest and is intended
    ///to contain all DijkstraStrategyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DijkstraStrategyTest
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
        ///A test for GetShortestPathTo
        ///</summary>
        [TestMethod()]
        public void GetShortestPathToTest()
        {
            var board = new ChessBoard();
            var knightGraph = new KnightGraph(board);

            var pathStrategy = new DijkstraAlgorithm(board.Squares["b7"], knightGraph);
            var path = pathStrategy.GetShortestPathTo(board.Squares["a8"]);

            foreach (var square in path)
            {
                Console.WriteLine(square);
            }
        }      
       
    }
}
