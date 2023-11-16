using Pac_Man.Domain.Models;
using System.Collections;

namespace Pac_Man.Business
{
    public class Board
    {
        private List<Piece> boardConfiguration;

        MoveablesContainer character = new MoveablesContainer(new Character());

        Dictionary<string, MoveablesContainer> ghosts = new Dictionary<string, MoveablesContainer> {
            {"Blinky", new MoveablesContainer (new Ghost())},
            {"Pinky", new MoveablesContainer (new Ghost())},
            {"Inky", new MoveablesContainer (new Ghost())},
            {"Clyde", new MoveablesContainer (new Ghost())},
        };
        
        Dictionary<string, KeyValuePair<int, int>> ghostsPositions = new Dictionary<string, KeyValuePair<int, int>> {
            {"Blinky", new KeyValuePair<int, int>() },
            {"Pinky", new KeyValuePair<int, int>()},
            {"Inky", new KeyValuePair<int, int>()},
            {"Clyde", new KeyValuePair<int, int>()},
        };

        private int rows;
        private int columns;

        public Board()
        {
            ClassicBoardGneration();
            SpawnPlayerBasicBoard();
        }

        private void ClassicBoardGneration()
        {
            rows = 23;
            columns = 23;

            boardConfiguration = new List<Piece>(rows * columns);

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
            boardConfiguration.Add(ghosts["Blinky"].piece);
            ghosts["Blinky"].position = new KeyValuePair<int, int>(12, 9);
            
            boardConfiguration.Add(ghosts["Pinky"].piece);
            ghosts["Pinky"].position = new KeyValuePair<int, int>(12, 10);

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(ghosts["Inky"].piece);
            ghosts["Inky"].position = new KeyValuePair<int, int>(12, 12);

            boardConfiguration.Add(ghosts["Clyde"].piece);
            ghosts["Clyde"].position = new KeyValuePair<int, int>(12, 13);

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
            for (int i = 0; i < rows; i++)
            {
                boardConfiguration.Add(new Wall());
            }
        }

        public Piece this[int row, int column]
        {
            get { return boardConfiguration[row * columns + column]; }
            set { boardConfiguration[row * columns + column] = value; }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(this[i, j].ToString());
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
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
            this[possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value] = character.piece;
            character.position = new KeyValuePair<int, int>(possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value);
        }
    }
}