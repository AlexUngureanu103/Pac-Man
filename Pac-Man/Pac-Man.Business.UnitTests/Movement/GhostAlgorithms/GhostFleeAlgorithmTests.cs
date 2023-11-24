using FluentAssertions;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement.GhostAlgorithms;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Movement.GhostAlgorithms
{
    [TestClass]
    public class GhostFleeAlgorithmTests
    {
        private Graph graph;

        [TestInitialize]
        public void TestInitialize()
        {
            var board = new Board();
            graph = new Graph(board);
        }

        [TestMethod]
        [Ignore]
        public void Flee_ShouldReturnNothing_WhenThereIsNoPath()
        {
            var ghost = new MoveablesContainer(new Ghost());
            ghost.position = new KeyValuePair<int, int>(0, 0);
            var player = new MoveablesContainer(new Character());
            player.position = new KeyValuePair<int, int>(1, 1);

            var ghostFleeAlgorithm = new GhostFleeAlgorithm(graph);

            // Act
            var result = ghostFleeAlgorithm.Flee(ghost, player);

            // Assert
            result.Key.Should().Be("");
            result.Value.Should().Be("");
        }
    }
}
