using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Pac_Man.ApplicationConfiguration;
using Pac_Man.Business;
using Pac_Man.Business.GraphRepresentation;
using Pac_Man.Business.Movement;
using Pac_Man.Business.Movement.Ghost_Algorithms;
using Pac_Man.Business.Strategy;
using Pac_Man.Pages;
using Pac_Man.ViewModels;

namespace Pac_Man.UnitTests
{
    [TestClass]
    public class BootstrapperTests
    {
        [TestMethod]
        [Ignore("The dependencies from the MAUI app aren't visible, so the instances cannot be registerd.")]
        public void BuildApp_ShouldRegisterEveryDepencies_WhenCalled()
        {
            var services = new ServiceCollection();

            Bootstrapper.BuildApp(services);
            var serviceProvider = services.BuildServiceProvider();

            VerifyPages(serviceProvider);
            VerifyPopups(serviceProvider);
            VerifyViemModels(serviceProvider);
            VerifyGameBusiness(serviceProvider);
            VerifyStrategy(serviceProvider);
            VerifyFactory(serviceProvider);
        }

        private void VerifyPages(IServiceProvider serviceProvider)
        {
            Assert.IsNotNull(serviceProvider.GetService<GamePage>());
            Assert.IsNotNull(serviceProvider.GetService<AboutPage>());
            Assert.IsNotNull(serviceProvider.GetService<LobbyWindowPage>());
        }

        private void VerifyPopups(IServiceProvider serviceProvider)
        {
            Assert.IsNotNull(serviceProvider.GetService<PausePopupPage>());
            Assert.IsNotNull(serviceProvider.GetService<ControlsPopup>());
        }

        private void VerifyViemModels(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<GameWindowViewModel>().Should().NotBeNull();
            serviceProvider.GetService<LobbyWindowViewModel>().Should().NotBeNull();
        }

        private void VerifyGameBusiness(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<IGameCharacters>().Should().NotBeNull();
            serviceProvider.GetService<IBoard>().Should().NotBeNull();
            serviceProvider.GetService<IGraph>().Should().NotBeNull();
            serviceProvider.GetService<IDijkstraAlgorithm>().Should().NotBeNull();
            serviceProvider.GetService<IGhostFleeAlgorithm>().Should().NotBeNull();
            serviceProvider.GetService<IGhostPathAlgorithms>().Should().NotBeNull();
            serviceProvider.GetService<IGameLogic>().Should().NotBeNull();
        }

        private void VerifyStrategy(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<IStrategyFactory>().Should().NotBeNull();
            serviceProvider.GetService<EasyStrategy>().Should().NotBeNull();
            serviceProvider.GetService<NormalStrategy>().Should().NotBeNull();
            serviceProvider.GetService<NoobStrategy>().Should().NotBeNull();
            serviceProvider.GetService<ImpossibleStrategy>().Should().NotBeNull();
        }

        private void VerifyFactory(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<IContentPageFactory>().Should().NotBeNull();
            serviceProvider.GetService<IPopupFactory>().Should().NotBeNull();
        }
    }
}