using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void Wall_ShouldHaveCorrectFlags_WhenCreated()
        {
            var character = new Wall();

            character.canBeEaten.Should().BeFalse();
            character.canMove.Should().BeFalse();
            character.canMoveIn.Should().BeFalse();
            character.Icon.Should().BeEmpty();
        }
    }
}
