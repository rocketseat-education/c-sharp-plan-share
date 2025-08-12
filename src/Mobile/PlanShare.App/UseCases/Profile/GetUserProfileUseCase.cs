using PlanShare.App.Data.Network.Api;
using PlanShare.App.Extensions;
using PlanShare.App.Models.ValueObjects;

namespace PlanShare.App.UseCases.Profile;
public class GetUserProfileUseCase : IGetUserProfileUseCase
{
    private readonly IUserApi _userApi;

    public GetUserProfileUseCase(IUserApi userApi)
    {
        _userApi = userApi;
    }

    public async Task<Result> Execute()
    {
        var response = await _userApi.GetProfile();

        if (response.IsSuccessful)
        {
            return Result.Success();
        }

        var errorResponse = await response.Error.GetResponseError();

        return Result.Failure(errorResponse.Errors);
    }
}
