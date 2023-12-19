namespace Pac_Man.Business.Strategy
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IStrategy GetStrategy(StrategyEnum strategy)
        {
            switch (strategy)
            {
                case StrategyEnum.Noob:
                    return _serviceProvider.GetService(_serviceProvider.GetService(typeof(NoobStrategy)).GetType()) as IStrategy;
                case StrategyEnum.Impossible:
                    return _serviceProvider.GetService(_serviceProvider.GetService(typeof(ImpossibleStrategy)).GetType()) as IStrategy;
                case StrategyEnum.Easy:
                    return _serviceProvider.GetService(_serviceProvider.GetService(typeof(EasyStrategy)).GetType()) as IStrategy;
                default:
                    return _serviceProvider.GetService(_serviceProvider.GetService(typeof(NormalStrategy)).GetType()) as IStrategy;
            }
        }
    }
}
