using Game.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;

namespace Game.Tests;

public class TryBuildSettlementLocationTests
{
    private Player? player;
    private ILogger<Board> _logger;
    public TryBuildSettlementLocationTests(ITestOutputHelper output) {
 // Configuration and logger initialization
 Log.Logger = new LoggerConfiguration()
 .WriteTo.Sink(new XunitSink(output)) // Use custom sink
 .CreateLogger();
 var serviceCollection = new ServiceCollection()
 .AddLogging(builder =>
 {
 builder.AddSerilog();
 });
 var serviceProvider = serviceCollection.BuildServiceProvider();
 _logger = serviceProvider.GetRequiredService<ILogger<Board>>();
 player1 = new Player("DefaultPlayer1");
 player2 = new Player("DefaultPlayer2");
}
    [Fact]
public void CannotBuildSettlementOnInvalidLocation()
{
    // Arrange
    player = new Player("Player1") { Resources = new Resources(1, 1, 1, 1, 0) };
    var board = new Board(_logger);
    var invalidLocation = new Location(-1, -1);

    // Act
    var result = board.TryBuildSettlement(player, invalidLocation);

    // Assert
    Assert.False(result, "Player was able to build a settlement on an invalid location.");
}
    [Fact]public void CannotBuildOnOccupiedLocation_withOccupiedLocationTest()
    {
        // Arrange
        player1 = new Player("blah") { Resources = new Resources(1, 1, 1, 1, 0) };
        player2 = new Player("blah") { Resources = new Resources(1, 1, 1, 1, 0) };
        var board = new Board(_logger);
        var location = new Location(3, 3);

        // Player 1 builds a settlement at the location.
        board.TryBuildSettlement(player1, location);

        // Act
        var result = board.TryBuildSettlement(player2, location);

        // Assert
        Assert.False(result, "Player 2 was able to build a settlement on a location occupied by Player 1.");
    }

    [Fact]    [Trait("HasTicket", "Id-baaed767-008e-4421-b31b-6577825f1897")]public void CanBuildSettlementOnLocation()
    {
        // Arrange
        player1 = new Player("blah") { Resources = new Resources(1, 1, 1, 1, 0) };
        var board = new Board(_logger);
        var location = new Location(3, 3);

        // Act
        var result = board.TryBuildSettlement(player1, location);

        // Assert
        Assert.True(result, "Player 1 was not able to build a settlement.");
    }
    private Player player1;
    private Player player2;
    [Fact] public void CannotBuildOnInsufficientResources() {
    // Arrange
    var player = new Player("Player1") { Resources = new Resources(0, 0, 0, 0, 0) };
    var board = new Board(_logger);
    var location = new Location(1, 1);

    // Act
    var result = board.TryBuildSettlement(player, location);

    // Assert
    Assert.False(result, "Player was able to build a settlement with insufficient resources.");
}
}