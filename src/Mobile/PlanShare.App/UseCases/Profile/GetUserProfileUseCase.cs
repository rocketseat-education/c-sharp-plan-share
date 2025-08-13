using PlanShare.App.Extensions;
using PlanShare.App.Models.ValueObjects;
using PlanShare.App.Network.Api;
using static Android.Graphics.ColorSpace;

namespace PlanShare.App.UseCases.Profile;
public class GetUserProfileUseCase : IGetUserProfileUseCase
{
    private readonly IUserApi _userApi;

    public GetUserProfileUseCase(IUserApi userApi)
    {
        _userApi = userApi;
    }

    public async Task<Result<Models.User>> Execute()
    {
        var response = await _userApi.GetProfile();

        var model = new Models.User
        {
            Name = response.Content.Name,
            Email = response.Content.Email,
        };

        if (response.IsSuccessful)
        {
            return Result<Models.User>.Success(model);
        }

        var errorResponse = await response.Error.GetResponseError();

        return Result<Models.User>.Failure(errorResponse.Errors);
    }
}
