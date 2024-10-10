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
public void CannotBuildSettlementWithoutNecessaryResources() {
    // Arrange
    var player = new Player();
    var location = new Location(0, 0);
    
    // Act
    var result = player.TryBuildSettlement(location);
    
    // Assert
    Assert.False(result);
}

    [Fact]
[Trait("HasTicket", "Id-8dcc3554-dbb4-47f3-89d3-311c126f49da")]public void CanBuildSettlementWithSufficientResources()
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
[Trait("HasTicket", "Id-8dcc3554-dbb4-47f3-89d3-311c126f49da")]public void CannotBuildTwoSettlementWithoutNecessaryResources()
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
[Trait("HasTicket", "Id-8dcc3554-dbb4-47f3-89d3-311c126f49da")]    public void CanBuildTwoSettlementWithSufficientResources()
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
    [Fact]
public void CannotBuildSettlementOnOccupiedLocation() {
    // Arrange
    var player = new Player();
    player.Resources = new Resources(1, 0, 0, 0, 1);
    var board = new Board(_logger);
    var location = new Location(1, 1);
    board.TryBuildSettlement(player, location); // Build first settlement
    var result = board.TryBuildSettlement(player, location); // Attempting to build on the same location
    // Assert
    Assert.False(result, "Player was able to build a settlement on an occupied location.");
}
}