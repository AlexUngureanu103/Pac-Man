using System.Windows.Input;

namespace Pac_Man.ViewModels
{
    internal class LobbyWindowViewModel
    {
        public ICommand PlayButtonCommand { get; }
        public ICommand AboutButtonCommand { get; }

        public LobbyWindowViewModel()
        {
            PlayButtonCommand = new Command(PlayButtonAction);
            PlayButtonCommand = new Command(AboutButtonAction);
        }

        private void PlayButtonAction()
        {
            // Logic for Play Button action
        }

        private void AboutButtonAction()
        {
            // Logic for About Button action
        }
    }
}
