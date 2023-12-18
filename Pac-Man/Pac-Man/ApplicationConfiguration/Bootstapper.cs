using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Pages;
using Pac_Man.ViewModels;

namespace Pac_Man.ApplicationConfiguration
{
    public class Bootstapper
    {
        public static void BuildApp(MauiAppBuilder builder)
        {
            RegisterPages(builder);
            RegisterViewModels(builder);
            RegisterGameBusiness(builder);
            RegisterFactory(builder);
            RegisterPopup(builder);
        }

        private static void RegisterPages(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<GamePage>();
            builder.Services.AddScoped<AboutPage>();
            builder.Services.AddScoped<LobbyWindowPage>();
        }

        private static void RegisterPopup(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<PausePopupPage>();
        }

        private static void RegisterViewModels(MauiAppBuilder builder)
        {
            builder.Services.AddTransient<GameWindowViewModel>();
            builder.Services.AddTransient<LobbyWindowViewModel>();
        }

        private static void RegisterGameBusiness(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IGameCharacters, GameCharacters>();
            builder.Services.AddSingleton<IBoard, Board>();
            builder.Services.AddSingleton<IGraph, Graph>();
            builder.Services.AddSingleton<IDijkstraAlgorithm, DijkstraAlgorithm>();
            builder.Services.AddSingleton<IGhostFleeAlgorithm, GhostFleeAlgorithm>();
            builder.Services.AddSingleton<IGhostPathAlgorithms, GhostPathAlgorithms>();

            builder.Services.AddSingleton<GameLogic>();

            RegisterStrategy(builder);
        }

        private static void RegisterStrategy(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IStrategyFactory, StrategyFactory>();


            builder.Services.AddScoped<EasyStrategy>();
            builder.Services.AddScoped<NormalStrategy>();
            builder.Services.AddScoped<NoobStrategy>();
            builder.Services.AddScoped<ImpossibleStrategy>();
        }

        private static void RegisterFactory(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<IContentPageFactory, ContentPageFactory>();
            builder.Services.AddScoped<IPopupFactory, PopupFactory>();
        }
    }
}
