using Pac_Man.Business.Movement.Ghost_Algorithms;

namespace Pac_Man.Business.Strategy
{
    public class ImpossibleStrategy : IStrategy
    {
        private readonly IGhostPathAlgorithms _ghostPathAlgorithms;

        public ImpossibleStrategy(IGhostPathAlgorithms ghostPathAlgorithms)
        {
            _ghostPathAlgorithms = ghostPathAlgorithms;
        }

        public KeyValuePair<int, int> MoveGhosts(KeyValuePair<string, MoveablesContainer> ghost, MoveablesContainer character)
        {
            var newPosition = _ghostPathAlgorithms.MainGhostMovements(ghost.Key, ghost.Value, character);

            return newPosition;
        }
    }
}
