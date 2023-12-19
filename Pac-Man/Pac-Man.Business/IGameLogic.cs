using Pac_Man.Domain.Enums;
using Pac_Man.Domain.ObserverInterfaces;

namespace Pac_Man.Business
{
    public interface IGameLogic
    {
        GameStateEnum GameState { get; }
        int Lifes { get; }
        string PlayerName { get; set; }
        PlayerStateEnum playerState { get; }
        int Score { get; }

        void GhostCharacterInteracts();
        void MoveCharacter(InputKeyEnum inputKey);
        void NotifyObservers(string state);
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void SetupGame();
        void StartGame();
        void StopGame();
        void Update(string state);
    }
}