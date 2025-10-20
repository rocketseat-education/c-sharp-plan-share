using Azure.Core;
using CommonTestUtilities.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using PlanShare.Domain.Extensions;
using PlanShare.Exceptions;
using Shouldly;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Tests.InlineData;

namespace WebApi.Tests.User.Register;
public class RegisterUserTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _httpClient;
    public RegisterUserTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserBuilder.Build();
        var response = await _httpClient.PostAsJsonAsync("/users", request);
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}
