﻿using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void Wall_ShouldHaveCorrectFlags_WhenCreated()
        {
            var wall = new Wall();

            wall.canBeEaten.Should().BeFalse();
            wall.canMove.Should().BeFalse();
            wall.canMoveIn.Should().BeFalse();
            wall.Icon.Should().BeEmpty();
            wall.Should().BeAssignableTo<Piece>();
        }

        [TestMethod]
        public void Wall_ToString_ReturnsW()
        {
            var wall = new Wall();
            var expected = "W  ";

            var actual = wall.ToString();

            actual.Should().Be(expected);
        }
    }
}
