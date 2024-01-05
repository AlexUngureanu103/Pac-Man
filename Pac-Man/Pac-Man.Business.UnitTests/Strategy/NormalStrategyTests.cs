using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class NormalStrategyTests
    {
        private IStrategy? normalStrategy;
        private IGhostPathAlgorithms? ghostPathAlgorithms;

        [TestInitialize]
        public void TestInitialize()
        {
            ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
            normalStrategy = Substitute.For<NormalStrategy>(ghostPathAlgorithms);
        }

        [TestMethod]
        public void NormalStrategy_MoveGhosts_ReturnsSamePosition()
        {
            if (ghostPathAlgorithms == null || normalStrategy == null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 7)
            };
            var character = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            normalStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            normalStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            normalStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            var result = normalStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);


            result.Key.Should().Be(ghost.position.Key);
            result.Value.Should().Be(ghost.position.Value);
        }

        [TestMethod]
        public void NormalStrategy_MoveGhosts_ReturnsNewPosition()
        {
            if (ghostPathAlgorithms == null || normalStrategy == null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 7)
            };
            var character = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(11, 8));

            var result = normalStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);

            result.Key.Should().Be(11);
            result.Value.Should().Be(8);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            normalStrategy = null;
            ghostPathAlgorithms = null;
        }
    }
}
