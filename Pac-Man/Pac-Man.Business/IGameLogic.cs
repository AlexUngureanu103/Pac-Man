using Pac_Man.Domain.Enums;
using Pac_Man.Domain.ObserverInterfaces;

namespace Pac_Man.Business
{
    public interface IGameLogic : ISubject, IObserver
    {
        GameStateEnum GameState { get; }
        PlayerStateEnum PlayerState { get; }
        int Lifes { get; }
        string PlayerName { get; set; }
        int Score { get; }

        void MoveCharacter(InputKeyEnum inputKey);
        void SetupGame();
        void StartGame();
        void StopGame();
    }
}