using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class EasyStrategyTests
    {
        private IStrategy? easyStrategy;
        private IGhostPathAlgorithms? ghostPathAlgorithms;

        [TestInitialize]
        public void TestInitialize()
        {
            ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
            easyStrategy = Substitute.For<EasyStrategy>(ghostPathAlgorithms);
        }

        [TestMethod]
        public void EasyStrategy_MoveGhosts_ReturnsSamePosition()
        {
            if (ghostPathAlgorithms == null || easyStrategy == null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 7)
            };
            var character = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            var result = easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);


            result.Key.Should().Be(ghost.position.Key);
            result.Value.Should().Be(ghost.position.Value);
        }

        [TestMethod]
        public void EasyStrategy_MoveGhosts_ReturnsNewPosition()
        {
            if (ghostPathAlgorithms == null || easyStrategy == null)
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

            var result = easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);

            result.Key.Should().Be(11);
            result.Value.Should().Be(8);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            easyStrategy = null;
            ghostPathAlgorithms = null;
        }
    }
}
