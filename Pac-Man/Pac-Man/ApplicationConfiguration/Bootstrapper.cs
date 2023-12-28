using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Movement.GhostAlgorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Pages;
using Pac_Man.ViewModels;

namespace Pac_Man.ApplicationConfiguration
{
    public class Bootstrapper
    {
        public static void BuildApp(IServiceCollection services)
        {
            RegisterPages(services);
            RegisterViewModels(services);
            RegisterGameBusiness(services);
            RegisterFactory(services);
            RegisterPopup(services);
        }

        private static void RegisterPages(IServiceCollection services)
        {
            services.AddScoped<GamePage>();
            services.AddScoped<AboutPage>();
            services.AddScoped<LobbyWindowPage>();
        }

        private static void RegisterPopup(IServiceCollection services)
        {
            services.AddScoped<PausePopupPage>();
            services.AddScoped<ControlsPopup>();
        }

        private static void RegisterViewModels(IServiceCollection services)
        {
            services.AddTransient<GameWindowViewModel>();
            services.AddTransient<LobbyWindowViewModel>();
        }

        private static void RegisterGameBusiness(IServiceCollection services)
        {
            services.AddSingleton<IGameCharacters, GameCharacters>();
            services.AddSingleton<IBoard, Board>();
            services.AddSingleton<IGraph, Graph>();
            services.AddSingleton<IDijkstraAlgorithm, DijkstraAlgorithm>();
            services.AddSingleton<IGhostFleeAlgorithm, GhostFleeAlgorithm>();
            services.AddSingleton<IGhostPathAlgorithms, GhostPathAlgorithms>();

            services.AddSingleton<IGameLogic, GameLogic>();

            RegisterStrategy(services);
        }

        private static void RegisterStrategy(IServiceCollection services)
        {
            services.AddSingleton<IStrategyFactory, StrategyFactory>();


            services.AddScoped<EasyStrategy>();
            services.AddScoped<NormalStrategy>();
            services.AddScoped<NoobStrategy>();
            services.AddScoped<ImpossibleStrategy>();
        }

        private static void RegisterFactory(IServiceCollection services)
        {
            services.AddScoped<IContentPageFactory, ContentPageFactory>();
            services.AddScoped<IPopupFactory, PopupFactory>();
        }
    }
}
