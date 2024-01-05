using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class EmptyTests
    {
        [TestMethod]
        public void Empty_ShouldHaveCorrectFlags_WhenCreated()
        {
            var emptySpace = new Empty();

            emptySpace.canBeEaten.Should().BeFalse();
            emptySpace.canMove.Should().BeFalse();
            emptySpace.canMoveIn.Should().BeTrue();
            emptySpace.Icon.Should().BeEmpty();
            emptySpace.Should().BeAssignableTo<Piece>();
        }

        [TestMethod]
        public void Empty_ToString_ReturnsEmpty()
        {
            var emptySpace = new Empty();
            var expected = "   ";

            var actual = emptySpace.ToString();

            actual.Should().Be(expected);
        }
    }
}
