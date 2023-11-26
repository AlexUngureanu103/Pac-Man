using Pac_Man.Domain.Models;

namespace Pac_Man.Business
{
    public class Board
    {
        private List<Piece> boardConfiguration;

        public MoveablesContainer Character = new(new Character());

        public Dictionary<string, MoveablesContainer> Ghosts = new()
        {
            {"Blinky", new MoveablesContainer (new Ghost())},
            {"Pinky", new MoveablesContainer (new Ghost())},
            {"Inky", new MoveablesContainer (new Ghost())},
            {"Clyde", new MoveablesContainer (new Ghost())},
        };

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Board()
        {
            ClassicBoardGneration();
            SpawnPlayerBasicBoard();
        }

        #region Classic Board Generation

        private void ClassicBoardGneration()
        {
            Rows = 23;
            Columns = 23;

            boardConfiguration = new List<Piece>(Rows * Columns);

            GnerateFirstRow();
            GenerateSecondRow();
            GenerateThirdRow();
            GenerateForthRow();
            GenerateFifthRow();
            GenerateSixthRow();
            GenerateSeventhRow();
            GenerateEightRow();
            GenerateNinethRow();
            GenerateTenthRow();
            GenerateEleventhRow();
            GenerateTwelvethRow();
            GenerateEleventhRowBack();
            GenerateTenthRow();
            GenerateNinethRow();
            GenerateEightRow();
            GenerateSeventhRow();
            GenerateSixthRow();
            GenerateFifthRow();
            GenerateForthRow();
            GenerateThirdRow();
            GenerateSecondRow();
            GnerateFirstRow();
        }

        private void GenerateEleventhRowBack()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
        }

        private void GenerateTwelvethRow()
        {
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(Ghosts["Blinky"].piece);
            Ghosts["Blinky"].position = new KeyValuePair<int, int>(11, 9);

            boardConfiguration.Add(Ghosts["Pinky"].piece);
            Ghosts["Pinky"].position = new KeyValuePair<int, int>(11, 10);

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(Ghosts["Inky"].piece);
            Ghosts["Inky"].position = new KeyValuePair<int, int>(11, 12);

            boardConfiguration.Add(Ghosts["Clyde"].piece);
            Ghosts["Clyde"].position = new KeyValuePair<int, int>(11, 13);

            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
        }

        private void GenerateEleventhRow()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
        }

        private void GenerateTenthRow()
        {
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 9; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
        }

        private void GenerateNinethRow()
        {
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
        }

        private void GenerateEightRow()
        {
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 3; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 9; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 3; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
        }

        private void GenerateSeventhRow()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
        }
        private void GenerateSixthRow()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());


            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
        }

        private void GenerateFifthRow()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
        }

        private void GenerateForthRow()
        {
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
        }

        private void GenerateThirdRow()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
        }

        private void GenerateSecondRow()
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 13; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
        }

        private void GnerateFirstRow()
        {
            for (int i = 0; i < Rows; i++)
            {
                boardConfiguration.Add(new Wall());
            }
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
            this[possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value] = Character.piece;
            Character.position = new KeyValuePair<int, int>(possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value);
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

        public bool GhostSeesThePlayer(string ghostName)
        {
            var ghostPositions = Ghosts[ghostName].position;

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
    }
}