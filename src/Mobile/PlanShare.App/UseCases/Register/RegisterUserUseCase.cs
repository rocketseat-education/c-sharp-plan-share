using PlanShare.App.Data.Network.Api;
using PlanShare.App.Extensions;
using PlanShare.App.Models;
using PlanShare.App.Models.ValueObjects;
using PlanShare.App.Network.Storage.Preferences.User;
using PlanShare.App.Network.Storage.SecureStorage.Tokens;
using PlanShare.Communication.Requests;
using System.Text.Json;
using PlanShare.Communication.Responses;

namespace PlanShare.App.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserApi _userApi;
    private readonly IUserStorage _userStorage;
    private readonly ITokensStorage _tokensStorage;

    public RegisterUserUseCase(IUserApi userApi, IUserStorage userStorage, ITokensStorage tokensStorage)
    {
        _userApi = userApi;
        _userStorage = userStorage;
        _tokensStorage = tokensStorage;
    }

    public async Task Execute(UserRegisterAccount model)
    {
        var request = new RequestRegisterUserJson
        {
            Name = model.Name,
            Email = model.Email,
            Password = model.Password
        };

        var response = await _userApi.Register(request);

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
            var errorResponse = await response.Error.GetResponseError();
        }
    }
}