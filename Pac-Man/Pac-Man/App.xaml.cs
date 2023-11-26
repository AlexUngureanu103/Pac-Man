using Pac_Man.Pages;

namespace Pac_Man
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new LobbyWindowPage(); //for showing the LobbyWindow
        }
    }
}