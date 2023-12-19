using Pac_Man.Domain;
using Pac_Man.Domain.Models;

namespace Pac_Man.Business.BoardManager
{
    public class BoardGenerator
    {

        public static List<Piece> GenerateClassicBoard(Dictionary<string, MoveablesContainer> ghosts, int rows, int columns)
        {
            var classicBoardConfiguration = new List<Piece>(rows * columns);

            GnerateFirstRow(classicBoardConfiguration, columns);
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
            GnerateFirstRow(classicBoardConfiguration, columns);

            return classicBoardConfiguration;
        }

        public static List<Piece> GenerateSmallerBoard(Dictionary<string, MoveablesContainer> ghosts, int rows, int columns)
        {
            var classicBoardConfiguration = new List<Piece>(rows * columns);

            GnerateFirstRow(classicBoardConfiguration, columns);
            GenerateSecondRowSmall(classicBoardConfiguration);
            GenerateThirdRowSmall(classicBoardConfiguration);
            GenerateFourthRowSmall(classicBoardConfiguration);
            GenerateThirdRowSmall(classicBoardConfiguration);
            GenerateSixRowSmall(classicBoardConfiguration);
            GenerateSevenRowSmall(classicBoardConfiguration);
            GenerateEightRowSmall(classicBoardConfiguration);
            GenerateNineRowSmall(classicBoardConfiguration);
            GenerateTenthRowSmall(classicBoardConfiguration);
            GenerateElevenRowSmall(classicBoardConfiguration);
            GenerateTwelveRowSmall(classicBoardConfiguration, ghosts);
            Generate13RowSmall(classicBoardConfiguration);
            Generate14RowSmall(classicBoardConfiguration);
            GnerateFirstRow(classicBoardConfiguration, columns);

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
            boardConfiguration.Add(ghosts[Ghosts.Blinky].piece);
            ghosts[Ghosts.Blinky].position = new KeyValuePair<int, int>(11, 9);

            boardConfiguration.Add(ghosts[Ghosts.Pinky].piece);
            ghosts[Ghosts.Pinky].position = new KeyValuePair<int, int>(11, 10);

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(ghosts[Ghosts.Inky].piece);
            ghosts[Ghosts.Inky].position = new KeyValuePair<int, int>(11, 12);

            boardConfiguration.Add(ghosts[Ghosts.Clyde].piece);
            ghosts[Ghosts.Clyde].position = new KeyValuePair<int, int>(11, 13);

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

        #region Smaller Board Generation
        private static void GenerateSecondRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 8; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 8; i++)
            {
                boardConfiguration.Add(new Food());
            }
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateThirdRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateFourthRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 3; i++)
            {
                boardConfiguration.Add(new Empty());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 3; i++)
            {
                boardConfiguration.Add(new Empty());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateSixRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 18; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());

        }

        private static void GenerateSevenRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 8; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateEightRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 4; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 4; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateNineRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            
            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateTenthRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 10; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateElevenRowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 3; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(new Empty());

            for (int i = 0; i < 3; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void GenerateTwelveRowSmall(List<Piece> boardConfiguration, Dictionary<string, MoveablesContainer> ghosts)
        {
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());

            boardConfiguration.Add(ghosts[Ghosts.Blinky].piece);
            ghosts[Ghosts.Blinky].position = new KeyValuePair<int, int>(11, 7);

            boardConfiguration.Add(ghosts[Ghosts.Pinky].piece);
            ghosts[Ghosts.Pinky].position = new KeyValuePair<int, int>(11, 8);

            boardConfiguration.Add(new Empty());
            boardConfiguration.Add(new Empty());

            boardConfiguration.Add(ghosts[Ghosts.Inky].piece);
            ghosts[Ghosts.Inky].position = new KeyValuePair<int, int>(11, 11);

            boardConfiguration.Add(ghosts[Ghosts.Clyde].piece);
            ghosts[Ghosts.Clyde].position = new KeyValuePair<int, int>(11, 12);

            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 5; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());

        }

        private static void Generate13RowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());

            for (int i = 0; i < 8; i++)
            {
                boardConfiguration.Add(new Wall());
            }

            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }

        private static void Generate14RowSmall(List<Piece> boardConfiguration)
        {
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

            for (int i = 0; i < 10; i++)
            {
                boardConfiguration.Add(new Food());
            }

            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Food());
            boardConfiguration.Add(new Wall());
            boardConfiguration.Add(new Wall());

        }
        #endregion
    }
}
