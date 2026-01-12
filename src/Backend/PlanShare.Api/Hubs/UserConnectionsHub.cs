using Microsoft.AspNetCore.SignalR;

namespace PlanShare.Api.Hubs;

public class UserConnectionsHub : Hub
{
  
    public String GenerateCode()
    {
        var code = "1234";
        Console.WriteLine("Code received!");
        return code;
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
     
}