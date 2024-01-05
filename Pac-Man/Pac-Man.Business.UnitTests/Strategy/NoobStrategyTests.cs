using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class NoobStrategyTests
    {
        private IGhostFleeAlgorithm? ghostFleeAlgorithm;

        [TestInitialize]
        public void TestInitialize()
        {
            ghostFleeAlgorithm = Substitute.For<IGhostFleeAlgorithm>();
        }

        [TestMethod]
        public void NoobStrategy_MoveGhosts_ReturnsSamePosition()
        {
            var noobStrategy = new NoobStrategy(ghostFleeAlgorithm);

            if (ghostFleeAlgorithm == null || noobStrategy == null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 7)
            };
            var character = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            ghostFleeAlgorithm.Flee(ghost, character).Returns(new KeyValuePair<string, string>("", ""));

            var result = noobStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);

            result.Key.Should().Be(ghost.position.Key);
            result.Value.Should().Be(ghost.position.Value);
        }

        [TestMethod]
        public void NoobStrategy_MoveGhosts_ReturnsNewPosition()
        {
            var noobStrategy = new NoobStrategy(ghostFleeAlgorithm);

            if (ghostFleeAlgorithm == null || noobStrategy == null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 8)
            };
            var character = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            ghostFleeAlgorithm.Flee(ghost, character).Returns(new KeyValuePair<string, string>("(11, 8)", "(11, 9)"));

            var result = noobStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Pinky", ghost), character);

            result.Key.Should().Be(11);
            result.Value.Should().Be(9);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ghostFleeAlgorithm = null;
        }
    }
}
