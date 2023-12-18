using Pac_Man.Business.Movement.Ghost_Algorithms;

namespace Pac_Man.Business.Strategy
{
    public class EasyStrategy : IStrategy
    {
        private readonly IGhostFleeAlgorithm _ghostFleeAlgorithm;
        private readonly IGhostPathAlgorithms _ghostPathAlgorithms;


        private int turnCnt = 0;
        private int moveCnt = 0;
        private int moveOnTurn = 5;

        public EasyStrategy(IGhostFleeAlgorithm ghostFleeAlgorithm, IGhostPathAlgorithms ghostPathAlgorithms)
        {
            _ghostFleeAlgorithm = ghostFleeAlgorithm;
            _ghostPathAlgorithms = ghostPathAlgorithms;
        }

        public KeyValuePair<int, int> MoveGhosts(KeyValuePair<string, MoveablesContainer> ghost, MoveablesContainer character)
        {
            moveCnt++;
            if (moveCnt % 4 == 0)
            {
                turnCnt++;
                moveCnt = 0;
            }
            if (turnCnt % moveOnTurn == 0)
            {
                var newPosition = _ghostPathAlgorithms.MainGhostMovements(ghost.Key, ghost.Value, character);

                return newPosition;
            }


            return ghost.Value.position;
        }
    }
}
