using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;
public partial class OnBoardingViewModel
{
    [RelayCommand]
    public async Task LoginWithEmailAndPasswords() => await Shell.Current.GoToAsync(RoutPages.LOGIN_PAGE);

    [RelayCommand]
    public void LoginWithGoogle()
    {
        AppTheme currentTheme = Application.Current.RequestedTheme;
        Application.Current.UserAppTheme = currentTheme == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;
    }

    [RelayCommand]
    public async Task RegisterUserAccount() => await Shell.Current.GoToAsync(RoutPages.USER_REGISTER_ACCOUNT_PAGE);
}
