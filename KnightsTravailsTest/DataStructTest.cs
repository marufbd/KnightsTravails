using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using KnightsTravails;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTravailsTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DataStructTest
    {
        public DataStructTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ChessBoard()
        {
            var board = new ChessBoard();

            foreach (var sq in board.Squares)
            {
                Console.WriteLine(sq.ToString() + String.Format("  r: {0}, c: {1}", sq.Value.RowPosition, sq.Value.ColPosition));
            }
            Assert.AreEqual("a1", board.Squares["a1"].ToString());
            Assert.AreEqual("a2", board.Squares["a2"].ToString());

            var square = board.GetSquare(5, 6);
            Assert.AreEqual(5, square.RowPosition);
            Assert.AreEqual(6, square.ColPosition);

            Assert.IsNull(board.GetSquare(0, 8));
            Assert.IsNotNull(board.GetSquare(8, 8));
            Assert.IsNotNull(board.GetSquare(1, 1));
        }


        [TestMethod]
        public void KnightGraph()
        {
            var board = new ChessBoard();
            var knightGraph = new KnightGraph(board);
            
            Assert.AreEqual(2, knightGraph.EdgesAdjacencyList[board.Squares["a1"]].Count);
            Assert.AreEqual(8, knightGraph.EdgesAdjacencyList[board.Squares["c3"]].Count);
            Assert.AreEqual(3, knightGraph.EdgesAdjacencyList[board.Squares["a2"]].Count);
            Assert.AreEqual(4, knightGraph.EdgesAdjacencyList[board.Squares["b2"]].Count);
            Assert.AreEqual(6, knightGraph.EdgesAdjacencyList[board.Squares["c2"]].Count);            
        }        
    }
}
