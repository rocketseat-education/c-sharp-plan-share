using PlanShare.App.Models.ValueObjects;

namespace PlanShare.App.UseCases.User.Profile;
public interface IGetUserProfileUseCase
{
    public Task<Result<Models.User>> Execute();
}
