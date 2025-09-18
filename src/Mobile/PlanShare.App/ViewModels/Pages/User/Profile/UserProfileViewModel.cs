using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Data.Storage.Preferences.User;
using PlanShare.App.Extensions;
using PlanShare.App.Navigation;
using PlanShare.App.Resources;
using PlanShare.App.UseCases.User.Profile;
using PlanShare.App.UseCases.User.Update;
using PlanShare.App.Constants;

namespace PlanShare.App.ViewModels.Pages.User.Profile;

public partial class UserProfileViewModel : ViewModelBase
{

    [ObservableProperty]
    public string userName;

    [ObservableProperty] public Models.User model;

    private readonly IGetUserProfileUseCase _getUserProfileUseCase;
    private readonly IUpdateUserUseCase _updateUserUseCase;

    public UserProfileViewModel(IUserStorage userStorage,
        INavigationService navigationService,
        IGetUserProfileUseCase getUserProfileUseCase,
        IUpdateUserUseCase updateUserUseCase
        ) : base(navigationService)
    {
        _getUserProfileUseCase = getUserProfileUseCase;
        _updateUserUseCase = updateUserUseCase; ;
    }

    [RelayCommand]
    public async Task Initialize()
    {
        StatusPage = Models.StatusPage.Loading;

        var result = await _getUserProfileUseCase.Execute();
        
        if (result.IsSuccess)
            Model = result.Response!;
        else
            await GoToPageWithErrors(result);


        StatusPage = Models.StatusPage.Default;

    }

    [RelayCommand]
    public async Task UpdateProfile()
    {
        StatusPage = Models.StatusPage.Sending;

        var result = Models.ValueObjects.Result.Success(); // await _updateUserUseCase.Execute(Model);
        if (result.IsSuccess) 
        {
            var font = Microsoft.Maui.Font.OfSize(FontFamily.MAIN_FONT_BLACK, 14);
            var snackBarOptions = new SnackbarOptions
            {
                BackgroundColor = Application.Current!.GetHighlightColor(),
                TextColor = Application.Current!.GetSecondaryColor(),
                CornerRadius = new CornerRadius(10),
                ActionButtonTextColor = Application.Current!.GetSecondaryColor(),
                Font = font,
                CharacterSpacing = 0.10
            };

            var duration = TimeSpan.FromSeconds(10);
            var snackBar = Snackbar.Make("Dados Atualizados com sucesso",
                action: null,
                actionButtonText: "fechar",
                duration,
                snackBarOptions);
            await snackBar.Show();
        }
        else
            await GoToPageWithErrors(result);

        StatusPage = Models.StatusPage.Default;
    }

    [RelayCommand]
    public async Task ChangePassword() => await _navigationService.GoToAsync(RoutePages.USER_CHANGE_PASSWORD_PAGE);

}