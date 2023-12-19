namespace Pac_Man.Business.Strategy
{
    public interface IStrategy
    {
        KeyValuePair<int, int> MoveGhosts(KeyValuePair<string, MoveablesContainer> ghost, MoveablesContainer character);
    }
}
