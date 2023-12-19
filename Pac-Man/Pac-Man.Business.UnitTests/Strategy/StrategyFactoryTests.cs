using NSubstitute;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;

namespace Pac_Man.Business.UnitTests.Strategy
{
    [TestClass]
    public class StrategyFactoryTests
    {
        private IServiceProvider? _serviceProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            var ghostFleeAlgorithm = Substitute.For<IGhostFleeAlgorithm>();
            var ghostPathAlgorithms = Substitute.For<IGhostPathAlgorithms>();

            _serviceProvider = Substitute.For<IServiceProvider>();

            _serviceProvider.GetService(typeof(NoobStrategy)).Returns(new NoobStrategy(ghostFleeAlgorithm, ghostPathAlgorithms));
            _serviceProvider.GetService(typeof(EasyStrategy)).Returns(new EasyStrategy(ghostFleeAlgorithm, ghostPathAlgorithms));
            _serviceProvider.GetService(typeof(NormalStrategy)).Returns(new NormalStrategy(ghostFleeAlgorithm, ghostPathAlgorithms));
            _serviceProvider.GetService(typeof(ImpossibleStrategy)).Returns(new ImpossibleStrategy(ghostFleeAlgorithm, ghostPathAlgorithms));
        }

        [DataTestMethod]
        [DataRow(StrategyEnum.Noob, typeof(NoobStrategy))]
        [DataRow(StrategyEnum.Easy, typeof(EasyStrategy))]
        [DataRow(StrategyEnum.Normal, typeof(NormalStrategy))]
        [DataRow(StrategyEnum.Impossible, typeof(ImpossibleStrategy))]

        public void CreateStrategy_WhenStrategyTypeIsEasy_ReturnsEasyStrategy(StrategyEnum strategyEnum, Type strategyType)
        {
            if (_serviceProvider is null)
                throw new NullReferenceException(nameof(_serviceProvider));

            var strategyFactory = new StrategyFactory(_serviceProvider);

            var strategy = strategyFactory.GetStrategy(strategyEnum);

            strategy.Should().BeOfType(strategyType);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _serviceProvider = null;
        }
    }
}