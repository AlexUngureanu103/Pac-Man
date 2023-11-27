using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Domain.Enums;
using Pac_Man.Domain.ObserverInterfaces;

namespace Pac_Man.Business
{
    public class GameLogic : IObserver, ISubject
    {
        private Board board;
        private Graph graph;
        private readonly DijkstraAlgorithm dijkstraAlgorithm;
        private readonly GhostFleeAlgorithm ghostFleeAlgorithm;
        private readonly GhostPathAlgorithms ghostPathAlgorithms;
        private GameStateEnum gameState;
        private PlayerStateEnum playerState;

        public string PlayerName { get; set; }

        public GameLogic(DijkstraAlgorithm dijkstraAlgorithm, GhostFleeAlgorithm ghostFleeAlgorithm, GhostPathAlgorithms ghostPathAlgorithms)
        {
            board = new Board();
            graph = new Graph(board);

            this.dijkstraAlgorithm = dijkstraAlgorithm;
            this.ghostFleeAlgorithm = ghostFleeAlgorithm;
            this.ghostPathAlgorithms = ghostPathAlgorithms;

            gameState = GameStateEnum.Lobby;
            playerState = PlayerStateEnum.Alive;
            this.ghostPathAlgorithms = ghostPathAlgorithms;
        }

        public void NotifyObservers()
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
