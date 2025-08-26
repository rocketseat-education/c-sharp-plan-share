using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;
using PlanShare.App.Network.Storage.Preferences.User;

namespace PlanShare.App.ViewModels.Pages.Dashboard;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    public string userName;
    
    public DashboardViewModel(IUserStorage userStorage, INavigationService navigationService) : base(navigationService)
    {
        UserName = userStorage.Get().Name;
    }

    [RelayCommand]
    public async Task SeeProfile() => await _navigationService.GoToAsync(RoutePages.USER_UPDATE_PROFILE_PAGE);
}