namespace Pac_Man.ViewModels
{
    public class GameWindowViewModel : BaseVM
    {
        public GameWindowViewModel()
        {
        }

        public static void HandleKeyPress(char key)
        {
            switch (char.ToLower(key))
            {
                case 'w':
                    // Send "Up" option to GameLogic from InputKeyEnum.cs
                    break;
                case 'a':
                    // Send "Left" option to GameLogic from InputKeyEnum.cs
                    break;
                case 's':
                    // Send "Down" option to GameLogic from InputKeyEnum.cs
                    break;
                case 'd':
                    // Send "Right" option to GameLogic from InputKeyEnum.cs
                    break;
                default:
                    // Send "Invalid" option to GameLogic from InputKeyEnum.cs
                    break;
            }
        }
    }
}
