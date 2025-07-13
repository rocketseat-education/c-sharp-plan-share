using PlanShare.App.Data.Network.Api;
using PlanShare.App.Extensions;
using PlanShare.App.Models;
using PlanShare.App.Models.ValueObjects;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.User.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserApi _userApi;


    public RegisterUserUseCase(IUserApi userApi)
    {
        _userApi = userApi;
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
       
    }
}
