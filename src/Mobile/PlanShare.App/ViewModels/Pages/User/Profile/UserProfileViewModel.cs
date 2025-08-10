using CommunityToolkit.Mvvm.ComponentModel;
using PlanShare.App.Navigation;
using PlanShare.App.Network.Storage.Preferences.User;

namespace PlanShare.App.ViewModels.Pages.User.Profile;

public partial class UserProfileViewModel : ViewModelBase
{

    [ObservableProperty]
    public string userName;

    private readonly INavigationService _navigationService;

    public UserProfileViewModel(IUserStorage userStorage, INavigationService navigationService)
    {
        UserName = userStorage.Get().Name;
        _navigationService = navigationService;
    }
}