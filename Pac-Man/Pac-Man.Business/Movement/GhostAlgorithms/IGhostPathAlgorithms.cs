namespace Pac_Man.Business.Movement.Ghost_Algorithms
{
    public interface IGhostPathAlgorithms
    {
        KeyValuePair<int, int> MainGhostMovements(string ghostName, MoveablesContainer ghost, MoveablesContainer player);
    }
}