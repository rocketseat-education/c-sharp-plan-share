using CommunityToolkit.Mvvm.ComponentModel;
using PlanShare.App.Navigation;
using PlanShare.App.Network.Storage.Preferences.User;

namespace PlanShare.App.ViewModels.Pages.User.Profile;

public partial class UserProfileViewModel : ViewModelBase
{

    [ObservableProperty]
    public string userName;

    [ObservableProperty] public Models.User model;

    private readonly INavigationService _navigationService;

    public UserProfileViewModel(IUserStorage userStorage, INavigationService navigationService)
    {
        UserName = userStorage.Get().Name;

        Model = new Models.User
        {
            Name = "Neil Angelo",
            Email = "neil.angelo@hotmail.com",
        };

        _navigationService = navigationService;
    }
}