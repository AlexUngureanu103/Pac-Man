using FakeItEasy;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Pac_Man.Business;

namespace Pac_Man.Business.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        private Board _board;
        private IGameCharacters _gameCharacters;
        public BoardTests() {
            //Dependencies
            _gameCharacters = A.Fake<IGameCharacters>();

            //SUT
            _board = new Board(_gameCharacters);
        }

        [TestMethod]
        [DataRow("Clyde")]
        //[DataRow("Pinky")]
        //[DataRow("Inky")]
        //[DataRow("Blinky")]
        public void Board_CheckIfGhostSeesThePlayer_ReturnFalse(string ghostName)
        {
            //Arange
            var keyValue = new KeyValuePair<int, int>(11, 12);
            A.CallTo(() => _gameCharacters.Ghosts[ghostName].position).Returns(keyValue);

            //Act
            var result = _board.CheckIfGhostSeesThePlayer(ghostName);

            //Assert

            result.Should().BeFalse();
        }
    }
}
