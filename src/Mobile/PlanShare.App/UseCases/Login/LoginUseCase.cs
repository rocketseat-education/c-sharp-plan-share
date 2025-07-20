using PlanShare.App.Models.ValueObjects;
using PlanShare.App.Network.Api;
using PlanShare.App.Network.Storage.Preferences.User;
using PlanShare.App.Network.Storage.SecureStorage.Tokens;
using PlanShare.Communication.Requests;
using PlanShare.Communication.Responses;
using System.Text.Json;

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

        var response = await _loginApi.Login(request);

        if (response.IsSuccessful)
        {
            var user = new Models.ValueObjects.User(response.Content.Id, response.Content.Name);
            var tokens = new Models.ValueObjects.Tokens(response.Content.Tokens.AccessToken,
                response.Content.Tokens.RefreshToken);

            _userStorage.Save(user);
            await _tokensStorage.Save(tokens);
        }
        else
        {
            var errors = await response.Error.GetContentAsAsync<ResponseErrorJson>();
        }
    }
}