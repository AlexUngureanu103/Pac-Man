using NSubstitute;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement.GhostAlgorithms;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Movement.GhostAlgorithms
{
    [TestClass]
    public class GhostFleeAlgorithmTests
    {
        private IGameCharacters? gameCharacters;
        private IBoard? board;
        private IGraph? graph;

        [TestInitialize]
        public void TestInitialize()
        {
            gameCharacters = Substitute.For<GameCharacters>();
            board = Substitute.For<Board>(gameCharacters);
            board.ClassicBoardGneration();
            graph = Substitute.For<Graph>(board, gameCharacters);
        }

        [TestMethod]
        public void Flee_ShouldReturnNothing_WhenThereIsNoPath()
        {
            if (graph is null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 9)
            };
            var player = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            var ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);

            var result = ghostFleeAlgorithm.Flee(ghost, player);

            result.Key.Should().Be("");
            result.Value.Should().Be("");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            gameCharacters = null;
            board = null;
            graph = null;
        }
    }
}
