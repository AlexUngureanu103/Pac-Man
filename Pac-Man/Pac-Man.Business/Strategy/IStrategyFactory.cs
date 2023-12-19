namespace Pac_Man.Business.Strategy
{
    public interface IStrategyFactory
    {
        IStrategy GetStrategy(StrategyEnum strategy);
    }
}
