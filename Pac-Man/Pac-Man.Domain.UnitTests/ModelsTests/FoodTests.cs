using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void Food_ShouldHaveCorrectFlags_WhenCreated()
        {
            var character = new Food();

            character.canBeEaten.Should().BeTrue();
            character.canMove.Should().BeFalse();
            character.canMoveIn.Should().BeTrue();
            character.Icon.Should().BeEmpty();
        }
    }
}
