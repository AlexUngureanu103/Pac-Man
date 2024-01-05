using FluentAssertions;

namespace Pac_Man.Domain.UnitTests
{
    [TestClass]
    public class GhostsTests
    {
        [TestMethod]
        public void Ghosts_Pinky_ReturnsPinky()
        {
            var expected = "Pinky";

            var actual = Ghosts.Pinky;

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Ghosts_Inky_ReturnsInky()
        {
            var expected = "Inky";

            var actual = Ghosts.Inky;

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Ghosts_Blinky_ReturnsBlinky()
        {
            var expected = "Blinky";

            var actual = Ghosts.Blinky;

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Ghosts_Clyde_ReturnsClyde()
        {
            var expected = "Clyde";

            var actual = Ghosts.Clyde;

            actual.Should().Be(expected);
        }
    }
}
