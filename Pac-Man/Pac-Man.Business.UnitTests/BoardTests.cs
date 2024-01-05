using NSubstitute;
using Pac_Man.Business.GraphRepresentation;

namespace Pac_Man.Business.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        private IGameCharacters? gameCharacters;
        [TestInitialize]
        public void TestInitialize()
        {
            gameCharacters = Substitute.For<IGameCharacters>();
        }

        [DataTestMethod]
        [DataRow("Clyde")]
        [DataRow("Pinky")]
        [DataRow("Inky")]
        [DataRow("Blinky")]
        public void Board_CheckIfGhostSeesThePlayer_ReturnFalseWhenGameStarts(string ghostName)
        {
            if(gameCharacters == null)
            {
                Assert.Fail();
            }

            var board = new Board(gameCharacters);

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
            gameCharacters = null;
        }
    }
}
