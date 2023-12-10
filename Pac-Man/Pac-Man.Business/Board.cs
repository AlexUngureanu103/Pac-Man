using Pac_Man.Business.BoardManager;
using Pac_Man.Domain;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public class Board : IBoard
    {
        private List<Piece> boardConfiguration = new List<Piece>();

        public IGameCharacters GameCharacters { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }

        public Board(IGameCharacters gameCharacters)
        {
            GameCharacters = gameCharacters;
            ClassicBoardGneration();
        }

        public void BoardRestart(IGameCharacters gameCharactersInitialPos)
        {
            if (gameCharactersInitialPos.Character.position.Key != GameCharacters.Character.position.Key || gameCharactersInitialPos.Character.position.Value != GameCharacters.Character.position.Value)
            {
                this[gameCharactersInitialPos.Character.position.Key, gameCharactersInitialPos.Character.position.Value] = GameCharacters.Character.piece;
                this[GameCharacters.Character.position.Key, GameCharacters.Character.position.Value] = new Empty();
            }

            this[gameCharactersInitialPos.Ghosts[Ghosts.Blinky].position.Key, gameCharactersInitialPos.Ghosts[Ghosts.Blinky].position.Value] = GameCharacters.Ghosts[Ghosts.Blinky].piece;
            this[GameCharacters.Ghosts[Ghosts.Blinky].position.Key, GameCharacters.Ghosts[Ghosts.Blinky].position.Value] = new Empty();

            this[gameCharactersInitialPos.Ghosts[Ghosts.Pinky].position.Key, gameCharactersInitialPos.Ghosts[Ghosts.Pinky].position.Value] = GameCharacters.Ghosts[Ghosts.Pinky].piece;
            this[GameCharacters.Ghosts[Ghosts.Pinky].position.Key, GameCharacters.Ghosts[Ghosts.Pinky].position.Value] = new Empty();

            this[gameCharactersInitialPos.Ghosts[Ghosts.Inky].position.Key, gameCharactersInitialPos.Ghosts[Ghosts.Inky].position.Value] = GameCharacters.Ghosts[Ghosts.Inky].piece; ;
            this[GameCharacters.Ghosts[Ghosts.Inky].position.Key, GameCharacters.Ghosts[Ghosts.Inky].position.Value] = new Empty();

            this[gameCharactersInitialPos.Ghosts[Ghosts.Clyde].position.Key, gameCharactersInitialPos.Ghosts[Ghosts.Clyde].position.Value] = GameCharacters.Ghosts[Ghosts.Clyde].piece;
            this[GameCharacters.Ghosts[Ghosts.Clyde].position.Key, GameCharacters.Ghosts[Ghosts.Clyde].position.Value] = new Empty();
        }

        #region Classic Board Generation

        public void ClassicBoardGneration()
        {
            Rows = 23;
            Columns = 23;

            boardConfiguration = BoardGenerator.GenerateClassicBoard(GameCharacters.Ghosts, Rows, Columns);
            SpawnPlayerBasicBoard();
        }



        private void SpawnPlayerBasicBoard()
        {
            List<KeyValuePair<int, int>> possibleSpawnPoints = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int>(3, 3),
                new KeyValuePair<int, int>(3, 19),
                new KeyValuePair<int, int>(19, 3),
                new KeyValuePair<int, int>(19, 19)
            };

            Random random = new Random();
            int randomIndex = random.Next(0, possibleSpawnPoints.Count);
            this[possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value] = GameCharacters.Character.piece;
            GameCharacters.Character.position = new KeyValuePair<int, int>(possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value);
        }

        #endregion

        public Piece this[int row, int column]
        {
            get { return boardConfiguration[row * Columns + column]; }
            set { boardConfiguration[row * Columns + column] = value; }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < Rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(this[i, j].ToString());
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public override string ToString()
        {
            var boardAsStruing = string.Empty + Environment.NewLine;

            for (int i = 0; i < Rows; i++)
            {
                boardAsStruing += Environment.NewLine;
                for (int j = 0; j < Columns; j++)
                {
                    boardAsStruing += this[i, j].ToString();
                }
            }
            boardAsStruing += Environment.NewLine;
            boardAsStruing += Environment.NewLine;
            boardAsStruing += Environment.NewLine;

            return boardAsStruing;
        }

        public bool CheckIfGhostSeesThePlayer(string ghostName)
        {
            var ghostPositions = GameCharacters.Ghosts[ghostName].position;

            for (int row = ghostPositions.Key + 1; row < Rows; row++)
            {
                if (!this[row, ghostPositions.Value].canMoveIn)
                {
                    break;
                }
                else if (this[row, ghostPositions.Value] is Character)
                {
                    return true;
                }
            }
            for (int row = ghostPositions.Key - 1; row > 0; row--)
            {
                if (!this[row, ghostPositions.Value].canMoveIn)
                {
                    break;
                }
                else if (this[row, ghostPositions.Value] is Character)
                {
                    return true;
                }
            }
            for (int column = ghostPositions.Value + 1; column < Columns; column++)
            {
                if (!this[ghostPositions.Key, column].canMoveIn)
                {
                    break;
                }
                else if (this[ghostPositions.Key, column] is Character)
                {
                    return true;
                }
            }
            for (int column = ghostPositions.Value - 1; column > 0; column--)
            {
                if (!this[ghostPositions.Key, column].canMoveIn)
                {
                    break;
                }
                else if (this[ghostPositions.Key, column] is Character)
                {
                    return true;
                }
            }

            return false;
        }

        public void SwitchPieces(KeyValuePair<int, int> oldPosition, KeyValuePair<int, int> newPosition)
        {
            (this[newPosition.Key, newPosition.Value], this[oldPosition.Key, oldPosition.Value]) = (this[oldPosition.Key, oldPosition.Value], this[newPosition.Key, newPosition.Value]);
        }

    }
}