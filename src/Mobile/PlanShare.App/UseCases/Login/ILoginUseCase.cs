using PlanShare.App.Models.ValueObjects;

namespace PlanShare.App.UseCases.Login;

public interface ILoginUseCase
{
    Task<Result> Execute(Models.Login model);
}