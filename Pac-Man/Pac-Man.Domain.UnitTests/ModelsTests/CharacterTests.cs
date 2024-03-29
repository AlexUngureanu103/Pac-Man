﻿using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void Character_ShouldHaveCorrectFlags_WhenCreated()
        {
            var character = new Character();

            character.canBeEaten.Should().BeFalse();
            character.canMove.Should().BeTrue();
            character.canMoveIn.Should().BeTrue();
            character.Icon.Should().BeEmpty();
            character.Should().BeAssignableTo<Piece>();
        }

        [TestMethod]
        public void Character_ToString_ReturnsC()
        {
            var character = new Character();
            var expected = "P  ";

            var actual = character.ToString();

            actual.Should().Be(expected);
        }
    }
}
