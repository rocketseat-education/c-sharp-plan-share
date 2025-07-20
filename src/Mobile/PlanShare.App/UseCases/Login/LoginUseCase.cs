using PlanShare.App.Data.Network.Api;
using PlanShare.App.Network.Storage.Preferences.User;
using PlanShare.App.Network.Storage.SecureStorage.Tokens;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly ILoginApi _loginApi;
    private readonly IUserStorage _userStorage;
    private readonly ITokensStorage _tokensStorage;

    public LoginUseCase(ILoginApi loginApi, IUserStorage userStorage, ITokensStorage tokensStorage)
    {
        _loginApi = loginApi;
        _userStorage = userStorage;
        _tokensStorage = tokensStorage;
    }
    
    public async Task Execute(Models.Login model)
    {
        var request = new RequestLoginJson
        {
            Email = model.Email,
            Password = model.Password
        };

        var result = await _loginApi.Login(request);

        var user = new Models.ValueObjects.User(result.Content.Id, result.Content.Name);
        var tokens = new Models.ValueObjects.Tokens(result.Content.Tokens.AccessToken, result.Content.Tokens.RefreshToken);

        _userStorage.Save(user);
        await _tokensStorage.Save(tokens);

    }

}