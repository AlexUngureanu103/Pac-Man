﻿using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class GhostTests
    {
        [TestMethod]
        public void Ghost_ShouldHaveCorrectFlags_WhenCreated()
        {
            var ghost = new Ghost();

            ghost.canBeEaten.Should().BeFalse();
            ghost.canMove.Should().BeTrue();
            ghost.canMoveIn.Should().BeTrue();
            ghost.Icon.Should().BeEmpty();
            ghost.Should().BeAssignableTo<Piece>();
        }
    }
}
