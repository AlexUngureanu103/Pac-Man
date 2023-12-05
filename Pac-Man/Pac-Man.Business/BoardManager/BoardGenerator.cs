using Pac_Man.Domain.Models;

namespace Pac_Man.Business.BoardManager
{
    public class BoardGenerator
    {

        public static List<Piece> GenerateClassicBoard(Dictionary<string, MoveablesContainer> ghosts, int rows, int columns)
        {
            var classicBoardConfiguration = new List<Piece>(rows * columns);

            GnerateFirstRow(classicBoardConfiguration, rows);
            GenerateSecondRow(classicBoardConfiguration);
            GenerateThirdRow(classicBoardConfiguration);
            GenerateForthRow(classicBoardConfiguration);
            GenerateFifthRow(classicBoardConfiguration);
            GenerateSixthRow(classicBoardConfiguration);
            GenerateSeventhRow(classicBoardConfiguration);
            GenerateEightRow(classicBoardConfiguration);
            GenerateNinethRow(classicBoardConfiguration);
            GenerateTenthRow(classicBoardConfiguration);
            GenerateEleventhRow(classicBoardConfiguration);
            GenerateTwelvethRow(classicBoardConfiguration, ghosts);
            GenerateEleventhRowBack(classicBoardConfiguration);
            GenerateTenthRow(classicBoardConfiguration);
            GenerateNinethRow(classicBoardConfiguration);
            GenerateEightRow(classicBoardConfiguration);
            GenerateSeventhRow(classicBoardConfiguration);
            GenerateSixthRow(classicBoardConfiguration);
            GenerateFifthRow(classicBoardConfiguration);
            GenerateForthRow(classicBoardConfiguration);
            GenerateThirdRow(classicBoardConfiguration);
            GenerateSecondRow(classicBoardConfiguration);
            GnerateFirstRow(classicBoardConfiguration, rows);

            return classicBoardConfiguration;
        }

        #region Classic Board Generation
        private static void GenerateEleventhRowBack(List<Piece> boardConfiguration)
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

        private static void GenerateTwelvethRow(List<Piece> boardConfiguration, Dictionary<string, MoveablesContainer> ghosts)
        {
            boardConfiguration.Add(new Wall());
            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(ghosts["Blinky"].piece);
            ghosts["Blinky"].position = new KeyValuePair<int, int>(11, 9);

            boardConfiguration.Add(ghosts["Pinky"].piece);
            ghosts["Pinky"].position = new KeyValuePair<int, int>(11, 10);

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(ghosts["Inky"].piece);
            ghosts["Inky"].position = new KeyValuePair<int, int>(11, 12);

            boardConfiguration.Add(ghosts["Clyde"].piece);
            ghosts["Clyde"].position = new KeyValuePair<int, int>(11, 13);

            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 7; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());
        }

        private static void GenerateEleventhRow(List<Piece> boardConfiguration)
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

        private static void GenerateTenthRow(List<Piece> boardConfiguration)
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

        private static void GenerateNinethRow(List<Piece> boardConfiguration)
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

        private static void GenerateEightRow(List<Piece> boardConfiguration)
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

        private static void GenerateSeventhRow(List<Piece> boardConfiguration)
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
        private static void GenerateSixthRow(List<Piece> boardConfiguration)
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

        private static void GenerateFifthRow(List<Piece> boardConfiguration)
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

        private static void GenerateForthRow(List<Piece> boardConfiguration)
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

        private static void GenerateThirdRow(List<Piece> boardConfiguration)
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

        private static void GenerateSecondRow(List<Piece> boardConfiguration)
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

        private static void GnerateFirstRow(List<Piece> boardConfiguration, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                boardConfiguration.Add(new Wall());
            }
        }

        #endregion
    }
}
