using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class EasyStrategyTests
    {
        private IGhostPathAlgorithms? ghostPathAlgorithms;

        [TestInitialize]
        public void TestInitialize()
        {
            ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
        }

        [TestMethod]
        public void EasyStrategy_MoveGhosts_ReturnsSamePosition()
        {
            Random random = new Random();

            var easyStrategy = new EasyStrategy(ghostPathAlgorithms);

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

            int min = 1;
            int max = 26;
            int multipleOfFour;

            do
            {
                int randomNumber = random.Next(min, max);
                multipleOfFour = randomNumber + (4 - randomNumber % 4);
            } while(multipleOfFour % 5 == 0);

            for (int i = 0; i < multipleOfFour; i++)
            {
               int randomNumber1 = random.Next(1, 20);
               int randomNumber2 = random.Next(1, 20);

               ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(randomNumber1, randomNumber2));
               easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
            }

            ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(11, 8));

            var result = easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);

            result.Key.Should().Be(ghost.position.Key);
            result.Value.Should().Be(ghost.position.Value);
        }

        [TestMethod]
        public void EasyStrategy_MoveGhosts_ReturnsNewPosition()
        {
            Random random = new Random();

            var easyStrategy = new EasyStrategy(ghostPathAlgorithms);

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

            int min = 1;
            int max = 8;
            int randomNumber = random.Next(min, max);

            int multipleOfFour = randomNumber + (4 - randomNumber % 4);

            int times = 0;

            while (times < 5)
            {
                for (int i = 0; i < multipleOfFour; i++)
                {
                    int randomNumber1 = random.Next(1, 20);
                    int randomNumber2 = random.Next(1, 20);

                    ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(randomNumber1, randomNumber2));
                    easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);
                }
                times++;
            }

            ghostPathAlgorithms.MainGhostMovements("Blinky", ghost, character).Returns(new KeyValuePair<int, int>(11, 8));

            var result = easyStrategy.MoveGhosts(new KeyValuePair<string, MoveablesContainer>("Blinky", ghost), character);

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
