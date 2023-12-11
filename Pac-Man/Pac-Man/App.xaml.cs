using Pac_Man.ApplicationConfiguration;
using Pac_Man.Pages;

namespace Pac_Man
{
    public partial class App : Application
    {
        private readonly IContentPageFactory _contentPageFactory;
        public App(IContentPageFactory contentPageFactory)
        {
            _contentPageFactory = contentPageFactory;
            InitializeComponent();

            MainPage = _contentPageFactory.Create<LobbyWindowPage>();
        }
    }
}