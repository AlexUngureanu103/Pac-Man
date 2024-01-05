using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class EasyStrategyTests
    {
        private IStrategy? easyStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            var ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();
            easyStrategy = Substitute.For<EasyStrategy>(ghostPathAlgorithms);
        }

        [TestMethod]
        public void EasyStrategy_MoveGhosts_Returns()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {
            easyStrategy = null;
        }
    }
}
