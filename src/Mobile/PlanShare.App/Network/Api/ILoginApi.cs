using PlanShare.Communication.Requests;
using PlanShare.Communication.Responses;
using Refit;

namespace PlanShare.App.Network.Api;

public interface ILoginApi
{
    [Post("/login")]
    Task<IApiResponse<ResponseRegisteredUserJson>> Login([Body] RequestLoginJson request);
}