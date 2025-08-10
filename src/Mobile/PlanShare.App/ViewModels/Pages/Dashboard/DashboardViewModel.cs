using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Navigation;
using PlanShare.App.Network.Storage.Preferences.User;

namespace PlanShare.App.ViewModels.Pages.Dashboard;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    public string userName;
    
    private readonly INavigationService _navigationService;

    public DashboardViewModel(IUserStorage userStorage, INavigationService navigationService)
    {
        UserName = userStorage.Get().Name;
        _navigationService = navigationService;
    }

    [RelayCommand]
    public async Task SeeProfile() => await _navigationService.GoToAsync(RoutePages.USER_UPDATE_PROFILE_PAGE);
}