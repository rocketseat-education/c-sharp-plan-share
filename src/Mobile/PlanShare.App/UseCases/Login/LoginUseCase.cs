using PlanShare.App.Data.Network.Api;
using PlanShare.App.Models.ValueObjects;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly ILoginApi _loginApi;

    public LoginUseCase(ILoginApi loginApi)
    {
        _loginApi = loginApi;
    }

    public async Task Execute(Models.Login model)
    {
        var request = new RequestLoginJson  
        {
            Email = model.Email,
            Password = model.Password
        };

        var result = await _loginApi.Login(request);
    }
}