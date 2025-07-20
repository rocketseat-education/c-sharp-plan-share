using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.UseCases.Login;

namespace PlanShare.App.ViewModels.Pages.Login.DoLogin;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty]
    public Models.Login model;

    private readonly ILoginUseCase _loginUseCase;

    public LoginViewModel(ILoginUseCase loginUseCase)
    {
        Model = new Models.Login();
        _loginUseCase = loginUseCase;
    }

    [RelayCommand]
    public async Task DoLogin()
    {   
        StatusPage = Models.StatusPage.Sending;
        var result = await _loginUseCase.Execute(Model);
        StatusPage = Models.StatusPage.Default;
    }
}
