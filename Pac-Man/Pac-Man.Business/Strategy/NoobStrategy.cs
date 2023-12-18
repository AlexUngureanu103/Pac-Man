using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;

namespace Pac_Man.Business.Strategy
{
    public class NoobStrategy : IStrategy
    {
        private readonly IGhostFleeAlgorithm _ghostFleeAlgorithm;
        private readonly IGhostPathAlgorithms _ghostPathAlgorithms;

        public NoobStrategy(IGhostFleeAlgorithm ghostFleeAlgorithm, IGhostPathAlgorithms ghostPathAlgorithms)
        {
            _ghostFleeAlgorithm = ghostFleeAlgorithm;
            _ghostPathAlgorithms = ghostPathAlgorithms;
        }

        public KeyValuePair<int, int> MoveGhosts(KeyValuePair<string, MoveablesContainer> ghost, MoveablesContainer character)
        {
            var nextMove = _ghostFleeAlgorithm.Flee(ghost.Value, character);

            return PositionConverter.ConvertPositionsFromString(nextMove.Value);
        }
    }
}
