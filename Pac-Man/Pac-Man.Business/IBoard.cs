using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public interface IBoard
    {
        IGameCharacters GameCharacters { get; set; }

        int Rows { get; set; }
        int Columns { get; set; }

        Piece this[int row, int column] { get; set; }

        void ClassicBoardGneration();
        bool CheckIfGhostSeesThePlayer(string ghostName);
        void SwitchPieces(KeyValuePair<int, int> position1, KeyValuePair<int, int> position2);
    }
}
