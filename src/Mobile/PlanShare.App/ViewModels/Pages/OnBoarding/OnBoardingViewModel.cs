using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;
public partial class OnBoardingViewModel
{
    private readonly INavigationService _navigationService;

    public OnBoardingViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public async Task LoginWithEmailAndPasswords() => await _navigationService.GoToAsync(RoutPages.LOGIN_PAGE);

    [RelayCommand]
    public void LoginWithGoogle()
    {
        AppTheme currentTheme = Application.Current.RequestedTheme;
        Application.Current.UserAppTheme = currentTheme == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;
    }

    [RelayCommand]
    public async Task RegisterUserAccount() => await _navigationService.GoToAsync(RoutPages.USER_REGISTER_ACCOUNT_PAGE);
}
