using Microsoft.AspNetCore.SignalR;
using PlanShare.Application.UseCases.User.Connection.GenerateCode;

namespace PlanShare.Api.Hubs;

public class UserConnectionsHub : Hub
{
    private readonly IGenerateCodeUserConnectionUseCase generateCodeUserConnectionUseCase;

    public UserConnectionsHub(IGenerateCodeUserConnectionUseCase generateCodeUserConnectionUseCase)
    {
        this.generateCodeUserConnectionUseCase = generateCodeUserConnectionUseCase;
    }

    public async Task<String> GenerateCode()
    {
        var codeUserConnectionDto = await generateCodeUserConnectionUseCase.Execute();
        return codeUserConnectionDto.Code;
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
     
}