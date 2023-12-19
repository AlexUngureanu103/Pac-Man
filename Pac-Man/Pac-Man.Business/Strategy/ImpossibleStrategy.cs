using Pac_Man.Business.Movement.Ghost_Algorithms;

namespace Pac_Man.Business.Strategy
{
    public class ImpossibleStrategy : IStrategy
    {
        private readonly IGhostFleeAlgorithm _ghostFleeAlgorithm;
        private readonly IGhostPathAlgorithms _ghostPathAlgorithms;

        public ImpossibleStrategy(IGhostFleeAlgorithm ghostFleeAlgorithm, IGhostPathAlgorithms ghostPathAlgorithms)
        {
            _ghostFleeAlgorithm = ghostFleeAlgorithm;
            _ghostPathAlgorithms = ghostPathAlgorithms;
        }

        public KeyValuePair<int, int> MoveGhosts(KeyValuePair<string, MoveablesContainer> ghost, MoveablesContainer character)
        {
            var newPosition = _ghostPathAlgorithms.MainGhostMovements(ghost.Key, ghost.Value, character);

            return newPosition;
        }
    }
}
