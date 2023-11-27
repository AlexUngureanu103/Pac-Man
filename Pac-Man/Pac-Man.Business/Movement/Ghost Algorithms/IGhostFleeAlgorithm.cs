namespace Pac_Man.Business.Movement.Ghost_Algorithms
{
    public interface IGhostFleeAlgorithm
    {
        KeyValuePair<string, string> Flee(MoveablesContainer ghost, MoveablesContainer player);
    }
}