using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
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
        }

        private static void RegisterPages(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<GamePage>();
            builder.Services.AddScoped<AboutPage>();
            builder.Services.AddScoped<LobbyWindowPage>();
        }

        private static void RegisterViewModels(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<GameWindowViewModel>();
            builder.Services.AddScoped<LobbyWindowViewModel>();
        }

        private static void RegisterGameBusiness(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<IGameCharacters, GameCharacters>();
            builder.Services.AddScoped<IBoard, Board>();
            builder.Services.AddScoped<IGraph, Graph>();
            builder.Services.AddScoped<IDijkstraAlgorithm, DijkstraAlgorithm>();
            builder.Services.AddScoped<IGhostFleeAlgorithm, GhostFleeAlgorithm>();
            builder.Services.AddScoped<IGhostPathAlgorithms, GhostPathAlgorithms>();

            builder.Services.AddScoped<GameLogic>();
        }

        private static void RegisterFactory(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<IContentPageFactory, ContentPageFactory>();
        }
    }
}
