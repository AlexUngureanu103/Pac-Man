using NSubstitute;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Movement.GhostAlgorithms;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Movement.GhostAlgorithms
{
    [TestClass]
    public class GhostPathAlgorithmsTests
    {
        private IGameCharacters gameCharacters;
        private IBoard board;
        private IGraph graph;
        private IDijkstraAlgorithm dijkstraAlgorithm;
        private IGhostFleeAlgorithm ghostFleeAlgorithm;

        [TestInitialize]
        public void TestInitialize()
        {
            gameCharacters = new GameCharacters();
            board = Substitute.For<Board>(gameCharacters);
            graph = Substitute.For<Graph>(board, gameCharacters);
            dijkstraAlgorithm = Substitute.For<DijkstraAlgorithm>(graph);
            ghostFleeAlgorithm = Substitute.For<GhostFleeAlgorithm>(graph);
        }

        [DataTestMethod]
        [DataRow("Blinky", 8, 7, 9, 7, 9, 7)]
        [DataRow("Blinky", 7, 12, 9, 11, 7, 13)]
        [DataRow("Blinky", 7, 10, 9, 11, 7, 9)]

        [DataRow("Inky", 8, 7, 9, 7, 7, 7)]
        [DataRow("Inky", 7, 11, 9, 11, 7, 10)]
        [DataRow("Inky", 7, 12, 9, 11, 7, 11)]
        [DataRow("Inky", 7, 13, 9, 11, 7, 12)]
        [DataRow("Inky", 7, 14, 9, 11, 7, 15)]

        [DataRow("Pinky", 8, 7, 9, 7, 9, 7)]
        [DataRow("Pinky", 7, 11, 9, 11, 7, 12)]
        [DataRow("Pinky", 7, 10, 9, 11, 7, 11)]
        [DataRow("Pinky", 7, 9, 9, 11, 7, 10)]
        [DataRow("Pinky", 7, 8, 9, 11, 7, 7)]

        [DataRow("Clyde", 8, 7, 9, 7, 7, 7)]
        [DataRow("Clyde", 7, 12, 9, 11, 7, 13)]
        [DataRow("Clyde", 7, 10, 9, 11, 7, 9)]
        public void MainGhostMovements_ShouldReturnNextMove_WhenCalled(string ghostName, int ghostX, int gohstY, int playerX, int playerY, int expectedX, int expectedY)
        {
            var ghostPosition = new KeyValuePair<int, int>(ghostX, gohstY);
            var playerPosition = new KeyValuePair<int, int>(playerX, playerY);
            board[playerPosition.Key, playerPosition.Value] = new Character();
            board.GameCharacters.Character = new MoveablesContainer(new Character());
            board.GameCharacters.Character.position = playerPosition;
            board[ghostPosition.Key, ghostPosition.Value] = new Ghost();
            board.GameCharacters.Ghosts[ghostName].position = ghostPosition;

            var ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm, ghostFleeAlgorithm, board);
            var result = ghostPathAlgorithms.MainGhostMovements(ghostName, board.GameCharacters.Ghosts[ghostName], board.GameCharacters.Character);

            result.Key.Should().Be(expectedX);
            result.Value.Should().Be(expectedY);
        }

        [DataTestMethod]
        [DataRow("Invalid")]
        [DataRow("Pac-Man")]
        [DataRow("Random")]
        public void MainGhostMovements_ShouldThrowException_WhenCalledWithInvalidGhostName(string ghostName)
        {
            var ghostPathAlgorithms = new GhostPathAlgorithms(dijkstraAlgorithm, ghostFleeAlgorithm, board);
            Action action = () => ghostPathAlgorithms.MainGhostMovements(ghostName, board.GameCharacters.Ghosts[ghostName], board.GameCharacters.Character);

            action.Should().Throw<KeyNotFoundException>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            gameCharacters = null;
            board = null;
            graph = null;
            dijkstraAlgorithm = null;
            ghostFleeAlgorithm = null;
        }
    }
}
