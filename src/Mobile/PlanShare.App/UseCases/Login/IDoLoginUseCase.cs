using PlanShare.App.Models.ValueObjects;

namespace PlanShare.App.UseCases.Login;

public interface IDoLoginUseCase
{
    Task<Result> Execute(Models.Login model);
}