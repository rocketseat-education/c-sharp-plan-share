using PlanShare.App.Models.ValueObjects;

namespace PlanShare.App.UseCases.Profile;
public interface IGetUserProfileUseCase
{
    public Task<Result> Execute();
}
