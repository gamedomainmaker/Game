using Game.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;

namespace Game.Tests;

public class TryBuildSettlementResourceTests
{
    private Player? player;
    private readonly ILogger<Board> _logger;

    public TryBuildSettlementResourceTests(ITestOutputHelper output)
    {
        // Configure Serilog to log to both console and file
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Sink(new XunitSink(output)) // Use custom sink
            .CreateLogger();

        // Configure logging for the test
        var serviceCollection = new ServiceCollection()
            .AddLogging(builder =>
            {
                builder.AddSerilog();
            });
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _logger = serviceProvider.GetRequiredService<ILogger<Board>>();
    }
    [Fact]
    [Trait("HasTicket", "Id-74ad39d7-60bd-4aa4-bcb3-9749b7427a45")]
    public void CannotBuildSettlementWithoutNecessaryResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(0, 0, 0, 0, 0) };

        var board = new Board(_logger);
        var location = new Location(1, 1); // Arbitrary valid location

        // Act
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement without the necessary resources.");
    }

    [Fact]
    [Trait("HasTicket", "Id-74ad39d7-60bd-4aa4-bcb3-9749b7427a45")]
    public void CanBuildSettlementWithSufficientResources()
    {
        // Arrange
        player = new Player();
        player.Resources = new Resources(1, 1, 1, 0, 0); // Adequate resources
        var location = new Location(1, 1); // Fixing the location object

        // Act
        var canBuild = player.TryBuildSettlement(location);

        // Assert
        Assert.True(canBuild);
    }

    [Fact]
    [Trait("HasTicket", "Id-74ad39d7-60bd-4aa4-bcb3-9749b7427a45")]
    public void CannotBuildTwoSettlementWithoutNecessaryResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(1, 1, 1, 1, 0) };

        var board = new Board(_logger);
        var location = new Location(1, 1); // Arbitrary valid location

        // Act
        board.TryBuildSettlement(player, location);

        location = new Location(2, 2);
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement without the necessary resources.");
    }

    [Fact]
    public void CanBuildTwoSettlementWithSufficientResources()
    {
        // Arrange
        player = new Player
        {
            Resources = new Resources(2, 2, 2, 2, 0)
        };
        var board = new Board(_logger);
        var location = new Location(1, 1);

        // Act
        board.TryBuildSettlement(player, location);

        location = new Location(2, 2);
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.True(result, "Player was unable to build a settlement with sufficient resources.");
    }
}