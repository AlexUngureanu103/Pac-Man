using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class ImpossibleStrategyTests
    {
        private IGhostPathAlgorithms? ghostPathAlgorithms;

        [TestInitialize]
        public void TestInitialize()
        {
            ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
        }

        [TestMethod]
        public void ImpossibleStrategy_MoveGhosts_ReturnsNewPosition()
        {
            var impossibleStrategy = new ImpossibleStrategy(ghostPathAlgorithms);

            Random random = new Random();

            if (ghostPathAlgorithms == null || impossibleStrategy == null)
                Assert.Fail();

            var ghost = new MoveablesContainer(new Ghost())
            {
                position = new KeyValuePair<int, int>(11, 7)
            };
            var character = new MoveablesContainer(new Character())
            {
                position = new KeyValuePair<int, int>(1, 1)
            };

            int randomNumber = random.Next(2, 10);

            for (int i=0; i<randomNumber; i++)
            {
                int randomNumber1 = random.Next(1, 20);
                int randomNumber2 = random.Next(1, 20);

                ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(randomNumber1, randomNumber2));
                impossibleStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            }

            ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(11, 8));

            var result = impossibleStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);

            result.Key.Should().Be(11);
            result.Value.Should().Be(8);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ghostPathAlgorithms = null;
        }
    }
}
