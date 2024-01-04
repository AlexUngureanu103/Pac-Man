using NSubstitute;
using Pac_Man.Business.GraphRepresentation;

namespace Pac_Man.Business.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        private IBoard? board;

        [TestInitialize]
        public void TestInitialize()
        {
            var gameCharacters = new GameCharacters();
            board = Substitute.For<Board>(gameCharacters);
            board.SmallerBoardGneration();
        }

        [DataTestMethod]
        [DataRow("Clyde")]
        [DataRow("Pinky")]
        [DataRow("Inky")]
        [DataRow("Blinky")]
        public void Board_CheckIfGhostSeesThePlayer_ReturnFalseWhenGameStarts(string ghostName)
        {
            if (board is null)
            {
                Assert.Fail();
            }

            var result = board.CheckIfGhostSeesThePlayer(ghostName);

            result.Should().BeFalse();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            board = null;
        }
    }
}
