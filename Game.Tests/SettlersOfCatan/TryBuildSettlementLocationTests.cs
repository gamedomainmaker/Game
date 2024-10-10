using Game.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;

namespace Game.Tests;

public class TryBuildSettlementLocationTests
{
    private Player? player;
    private Player? player1;
    private Player? player2;

    private readonly ILogger<Board> _logger;

    public TryBuildSettlementLocationTests(ITestOutputHelper output)
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
public void CannotBuildSettlementOnInvalidLocation()
{
    // Arrange
    player = new Player { Name = "Player1", Resources = new Resources(1, 1, 1, 1, 0) };

    var board = new Board(_logger);
    var invalidLocation = new Location(-1, -1);

    // Act
    var result = board.TryBuildSettlement(player, invalidLocation);

    // Assert
    Assert.False(result, "Player was able to build a settlement on an invalid location.");
}
    [Fact]
[Trait("HasTicket", "Id-8dcc3554-dbb4-47f3-89d3-311c126f49da")]public void CannotBuildOnOccupiedLocation_withOccupiedLocationTest()
    {
        // Arrange
        player1 = new Player { Resources = new Resources(1, 1, 1, 1, 0) };
        player2 = new Player { Resources = new Resources(1, 1, 1, 1, 0) };
        var board = new Board(_logger);
        var location = new Location(3, 3);

        // Player 1 builds a settlement at the location.
        board.TryBuildSettlement(player1, location);

        // Act
        var result = board.TryBuildSettlement(player2, location);

        // Assert
        Assert.False(result, "Player 2 was able to build a settlement on a location occupied by Player 1.");
    }

    [Fact]
[Trait("HasTicket", "Id-8dcc3554-dbb4-47f3-89d3-311c126f49da")]    public void CanBuildSettlementOnLocation()
    {
        // Arrange
        player1 = new Player { Resources = new Resources(1, 1, 1, 1, 0) };
        var board = new Board(_logger);
        var location = new Location(3, 3);

        // Act
        var result = board.TryBuildSettlement(player1, location);

        // Assert
        Assert.True(result, "Player 1 was not able to build a settlement.");
    }
}