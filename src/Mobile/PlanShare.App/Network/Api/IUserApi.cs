using PlanShare.Communication.Requests;
using PlanShare.Communication.Responses;
using Refit;

namespace PlanShare.App.Network.Api;

public interface IUserApi
{
    [Post("/users")]
    Task<ApiResponse<ResponseRegisteredUserJson>> Register([Body] RequestRegisterUserJson request);

    [Get("/users")]
    Task<IApiResponse<ResponseUserProfileJson>> GetProfile();
}
