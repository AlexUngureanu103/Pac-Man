using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;

namespace Pac_Man.Business.Strategy
{
    public class NoobStrategy : IStrategy
    {
        private readonly IGhostFleeAlgorithm _ghostFleeAlgorithm;

        public NoobStrategy(IGhostFleeAlgorithm ghostFleeAlgorithm)
        {
            _ghostFleeAlgorithm = ghostFleeAlgorithm;
        }

        public KeyValuePair<int, int> MoveGhosts(KeyValuePair<string, MoveablesContainer> ghost, MoveablesContainer character)
        {
            var nextMove = _ghostFleeAlgorithm.Flee(ghost.Value, character);
            if (nextMove.Key == "" && nextMove.Value == "" || nextMove.Value == "")
            {
                return ghost.Value.position;
            }

            return PositionConverter.ConvertPositionsFromString(nextMove.Value);
        }
    }
}
