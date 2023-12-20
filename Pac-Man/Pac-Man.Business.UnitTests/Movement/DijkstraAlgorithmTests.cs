using NSubstitute;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;

namespace Pac_Man.Business.UnitTests.Movement
{
    [TestClass]
    public class DijkstraAlgorithmTests
    {
        private IDijkstraAlgorithm? dijkstraAlgorithm;
        private IBoard? board;
        private IGraph? graph;

        [TestInitialize]
        public void TestInitialize()
        {
            GameCharacters gameCharacters = new GameCharacters();
            board = Substitute.For<Board>(gameCharacters);
            board.ClassicBoardGneration();
            graph = Substitute.For<Graph>(board, gameCharacters);
            dijkstraAlgorithm = Substitute.For<DijkstraAlgorithm>(graph);
        }

        [DataTestMethod]
        [DataRow("(8, 7)", "(9, 7)", "")]
        [DataRow("(9, 7)", "(10, 7)", "")]
        [DataRow("(1, 1)", "(2, 1)", "")]
        [DataRow("(8, 7)", "(10, 7)", "(9, 7)")]
        [DataRow("(10, 7)", "(8, 7)", "(9, 7)")]
        [DataRow("(1, 1)", "(3, 1)", "(2, 1)")]

        public void DijkstraAlgorithm_ShouldReturnShortestPathFromStartToFinish_WhenCalled(string startNode, string endNode, string intermediaryNode)
        {
            if (dijkstraAlgorithm == null)
                throw new NullReferenceException(nameof(dijkstraAlgorithm));

            var path = dijkstraAlgorithm.GetShortestPath(startNode, endNode);

            path.Keys.Should().Contain(startNode);
            path.Values.Should().Contain(endNode);
 
            if (intermediaryNode.Length == 0)
            {
                path.Count.Should().Be(1);
            }
            else
            {
                path.Count.Should().Be(2);

                path.Keys.Should().Contain(intermediaryNode);
            }

        }

        [DataTestMethod]
        [DataRow("(1, 2)", "(3, 2)", "(2, 2)")]
        [DataRow("(1, 3)", "(1, 5)", "(1, 4)")]
        
        public void DijkstraAlgorithm_ShouldIgnoreWallsInHisPath(string startNode, string endNode, string wallNode)
        {
            if (dijkstraAlgorithm == null)
                throw new NullReferenceException(nameof(dijkstraAlgorithm));

            var path = dijkstraAlgorithm.GetShortestPath(startNode, endNode);

            path.Keys.Should().NotContain(wallNode);
            path.Values.Should().NotContain(wallNode);

        }

        [DataTestMethod]
        [DataRow("(1, 2)", "(5, 11)")]
        [DataRow("(3, 11)", "(5, 11)")]
        [DataRow("(3, 11)", "(17, 11)")]
        [DataRow("(3, 1)", "(17, 11)")]
        
        public void DijkstraAlgorithm_ShouldReturnAnEmptyPathIfCantReachToDestination(string startNode, string endNode)
        {
            if (dijkstraAlgorithm == null)
                throw new NullReferenceException(nameof(dijkstraAlgorithm));

            var path = dijkstraAlgorithm.GetShortestPath(startNode, endNode);

            path.Count.Should().Be(0);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            dijkstraAlgorithm = null;
        }
    }
}
