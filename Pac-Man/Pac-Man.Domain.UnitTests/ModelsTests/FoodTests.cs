﻿using FluentAssertions;
using Pac_Man.Domain.Models;

namespace Pac_Man.Domain.UnitTests.ModelsTests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void Food_ShouldHaveCorrectFlags_WhenCreated()
        {
            var food = new Food();

            food.canBeEaten.Should().BeTrue();
            food.canMove.Should().BeFalse();
            food.canMoveIn.Should().BeTrue();
            food.Icon.Should().BeEmpty();
            food.Should().BeAssignableTo<Piece>();
        }

        [TestMethod]
        public void Food_ToString_ReturnsDot()
        {
            var food = new Food();
            var expected = ".  ";

            var actual = food.ToString();

            actual.Should().Be(expected);
        }
    }
}
