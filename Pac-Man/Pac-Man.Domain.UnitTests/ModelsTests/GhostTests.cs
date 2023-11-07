using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class GhostTests
    {
        [TestMethod]
        public void Ghost_ShouldHaveCorrectFlags_WhenCreated()
        {
            var character = new Ghost();

            character.canBeEaten.Should().BeFalse();
            character.canMove.Should().BeTrue();
            character.canMoveIn.Should().BeFalse();
            character.Icon.Should().BeEmpty();
        }
    }
}
