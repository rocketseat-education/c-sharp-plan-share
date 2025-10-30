using CommonTestUtilities.Navigation;
using Moq;
using PlanShare.App.Navigation;
using PlanShare.App.ViewModels.Pages.OnBoarding;
using Shouldly;
using ViewModels.Tests.Extensions;

namespace ViewModels.Tests.Pages.OnBording;
public class OnBoardingViewModelTests
{
    [Fact]
    public async Task Success_LoginWithEmailAndPassword()
    {
        var (viewModel, navigationService) = CreateViewModel();
        var act = async () => await viewModel.LoginWithEmailAndPasswordsCommand.ExecuteAsync(null);
        await act.ShouldNotThrowAsync();

        navigationService.Verify(service => service.GoToAsync("welisson"), Times.Once);
    }

    private (OnBoardingViewModel viewModel, Mock<INavigationService> navigationService) CreateViewModel()
    {
        var navigationService = NavigationServiceBuilder.Build();
        var viewModel = new OnBoardingViewModel(navigationService.Object);
        return (viewModel, navigationService);
    }
}
