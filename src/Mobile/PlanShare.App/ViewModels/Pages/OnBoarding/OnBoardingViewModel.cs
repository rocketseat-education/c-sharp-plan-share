using System.Windows.Input;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;
public class OnBoardingViewModel
{
    public ICommand LoginWithEmailAndPasswordCommand { get; set; }

    public OnBoardingViewModel()
    {
        LoginWithEmailAndPasswordCommand = new Command(LoginWithEmailAndPasswords);
    }
    public void LoginWithEmailAndPasswords()
    {

    }
}
