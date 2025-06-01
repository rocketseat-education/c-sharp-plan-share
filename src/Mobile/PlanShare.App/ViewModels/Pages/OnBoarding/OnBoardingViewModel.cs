using CommunityToolkit.Mvvm.Input;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;
public partial class OnBoardingViewModel
{
    [RelayCommand]
    public async Task LoginWithEmailAndPasswords()
    {
        await Shell.Current.GoToAsync("DoLoginPage");
    }

    [RelayCommand]
    public void LoginWithGoogle()
    {

    }
}
