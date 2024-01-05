using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class NormalStrategyTests
    {
        private IStrategy? normalStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            var ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
            normalStrategy = Substitute.For<NormalStrategy>(ghostPathAlgorithms);
        }

        [TestMethod]
        public void NormalStrategy_MoveGhosts_Returns()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
            normalStrategy = null;
        }
    }
}
