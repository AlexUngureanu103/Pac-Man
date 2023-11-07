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
            var character = new Empty();

            character.canBeEaten.Should().BeFalse();
            character.canMove.Should().BeFalse();
            character.canMoveIn.Should().BeTrue();
            character.Icon.Should().BeEmpty();
        }
    }
}
