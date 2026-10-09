using Agentory.TaskApi.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agentory.TaskApi.Tests.Integration;

public sealed class StartupTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    [Fact]
    [Trait("Req", "TAC-6")]
    public void Startup_InMemorySqlite_DatabaseIsReachable()
    {
        // Creating the client boots the host, which runs Database.EnsureCreated() in Program.cs.
        using var client = factory.CreateClient();

        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        Assert.Equal("Microsoft.EntityFrameworkCore.Sqlite", dbContext.Database.ProviderName);
        Assert.Contains(":memory:", dbContext.Database.GetConnectionString(), StringComparison.Ordinal);
        Assert.True(dbContext.Database.CanConnect());
    }

    [Fact]
    [Trait("Req", "TAC-5")]
    public void Startup_TestHost_UsesFakeTimeProvider()
    {
        var timeProvider = factory.Services.GetRequiredService<TimeProvider>();

        Assert.Same(factory.TimeProvider, timeProvider);
    }
}
