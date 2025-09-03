using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;
using PlanShare.App.Resources;
using PlanShare.App.UseCases.User.ChangePassword;

namespace PlanShare.App.ViewModels.Pages.User.ChangePassword;
public partial class ChangeUserPasswordViewModel : ViewModelBase
{
    [ObservableProperty]
    public Models.ChangePassword model;

    public ChangeUserPasswordViewModel(INavigationService navigationService) : base(navigationService)
    {
    }

    [RelayCommand]
    public async Task ChangePassword()
    {
        
    }
}
