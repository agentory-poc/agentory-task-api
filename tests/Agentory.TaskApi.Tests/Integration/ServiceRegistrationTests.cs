using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;

namespace Agentory.TaskApi.Tests.Integration;

public sealed class ServiceRegistrationTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    [Fact]
    [Trait("Req", "TAC-3")]
    public void Startup_ProblemDetails_ServiceIsRegistered()
    {
        var problemDetailsService = factory.Services.GetService<IProblemDetailsService>();

        Assert.NotNull(problemDetailsService);
    }

    [Fact]
    [Trait("Req", "TAC-3")]
    public void Startup_ControllerJsonOptions_EnumsAsStringsAndIntegersRejected()
    {
        var serializerOptions = factory.Services
            .GetRequiredService<IOptions<MvcJsonOptions>>()
            .Value
            .JsonSerializerOptions;

        Assert.Equal("\"Monday\"", JsonSerializer.Serialize(DayOfWeek.Monday, serializerOptions));
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DayOfWeek>("1", serializerOptions));
    }
}
