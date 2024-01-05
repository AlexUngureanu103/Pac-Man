using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class ImpossibleStrategyTests
    {
        private IStrategy? impossibleStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            var ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
            impossibleStrategy = Substitute.For<ImpossibleStrategy>(ghostPathAlgorithms);
        }

        [TestMethod]
        public void ImpossibleStrategy_MoveGhosts_Returns()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
            impossibleStrategy = null;
        }
    }
}
