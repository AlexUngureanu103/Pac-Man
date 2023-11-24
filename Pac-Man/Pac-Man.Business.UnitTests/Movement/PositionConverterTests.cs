using FluentAssertions;
using Pac_Man.Business.Movement;

namespace Pac_Man.Business.UnitTests.Movement
{
    [TestClass]
    public class PositionConverterTests
    {
        [TestMethod]
        public void ConvertPositionsFromString_ValidPositionString_ReturnsKeyValuePair()
        {
            var position = "(1, 2)";
            var expectedPosition = new KeyValuePair<int, int>(1, 2);

            var result = PositionConverter.ConvertPositionsFromString(position);

            result.Should().BeEquivalentTo(expectedPosition);
        }

        [DataTestMethod]
        [DataRow("(1,2)")]
        [DataRow("1, 2)")]
        [DataRow("(12)")]
        [DataRow("(1, 2")]
        [DataRow("(text, 2)")]
        [DataRow("(1, text)")]
        [DataRow("[1, text)")]
        [DataRow("(1, text]")]
        [DataRow("{1, text)")]
        [DataRow("(1, text}")]
        public void ConvertPositionsFromString_InvalidPositionString_ThrowsException(string position)
        {
            Action action = () => PositionConverter.ConvertPositionsFromString(position);

            action.Should().Throw<Exception>().WithMessage("Invalid position format");
        }

        [TestMethod]
        public void ConvertPositionsToString_ValidPosition_ReturnsString()
        {
            var position = new KeyValuePair<int, int>(1, 2);
            var expectedPosition = "(1, 2)";

            var result = PositionConverter.ConvertPositionsToString(position);

            result.Should().BeEquivalentTo(expectedPosition);
        }

        [TestMethod]
        public void ConvertPositionsToString_ValidPositions_ReturnsString()
        {
            var positionX = 1;
            var positionY = 2;
            var expectedPosition = "(1, 2)";

            var result = PositionConverter.ConvertPositionsToString(positionX, positionY);

            result.Should().BeEquivalentTo(expectedPosition);
        }
    }
}
    