using Pac_Man.Domain.Models;
using System.Collections;

namespace Pac_Man.Business
{
    public class Board
    {
        private List<Piece> boardConfiguration;

        Character character = new Character();
        public KeyValuePair<int, int> characterPosition;

        Dictionary<string, Ghost> ghosts = new Dictionary<string, Ghost> {
            {"Blinky", new Ghost()},
            {"Pinky", new Ghost()},
            {"Inky", new Ghost()},
            {"Clyde", new Ghost()},
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
            boardConfiguration.Add(ghosts["Blinky"]);
            ghostsPositions["Blinky"] = new KeyValuePair<int, int>(12, 9);
            
            boardConfiguration.Add(ghosts["Pinky"]);
            ghostsPositions["Pinky"] = new KeyValuePair<int, int>(12, 10);

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(ghosts["Inky"]);
            ghostsPositions["Inky"] = new KeyValuePair<int, int>(12, 12);

            boardConfiguration.Add(ghosts["Clyde"]);
            ghostsPositions["Clyde"] = new KeyValuePair<int, int>(12, 13);

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
            this[possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value] = character;
            characterPosition = new KeyValuePair<int, int>(possibleSpawnPoints[randomIndex].Key, possibleSpawnPoints[randomIndex].Value);
        }
    }
}