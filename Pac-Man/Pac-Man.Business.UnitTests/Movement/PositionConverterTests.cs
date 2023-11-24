using Pac_Man.Business.Movement;

namespace Pac_Man.Business.UnitTests.Movement
{
    [TestClass]
    public class PositionConverterTests
    {
        [TestMethod]
        public void ConvertPositionsFromString_ShouldReturnsKeyValuePair_WhenValidPositionIsValid()
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
        public void ConvertPositionsFromString_ShouldThrowsException_WhenPositionIsInvalid(string position)
        {
            Action action = () => PositionConverter.ConvertPositionsFromString(position);

            action.Should().Throw<ArgumentException>().WithMessage("Invalid position format");
        }

        [TestMethod]
        public void ConvertPositionsToString_ShouldReturnString_WhenPositionIsValid()
        {
            var position = new KeyValuePair<int, int>(1, 2);
            var expectedPosition = "(1, 2)";

            var result = PositionConverter.ConvertPositionsToString(position);

            result.Should().BeEquivalentTo(expectedPosition);
        }

        [TestMethod]
        public void ConvertPositionsToString_ShouldReturnString_WhenPositionsAreValid()
        {
            var positionX = 1;
            var positionY = 2;
            var expectedPosition = "(1, 2)";

            var result = PositionConverter.ConvertPositionsToString(positionX, positionY);

            result.Should().BeEquivalentTo(expectedPosition);
        }
    }
}
