using Game.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;

namespace Game.Tests;

public class TryBuildSettlementTests
{
    private Player? player;
    private ILogger<Board> _logger;
    public TryBuildSettlementTests(ITestOutputHelper output)
    {
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
    [Fact]
    public void CannotBuildOnOccupiedLocation_withOccupiedLocationTest()
    {
        // Arrange
        player1 = new Player("Player1") { Resources = new Resources(1, 1, 1, 1, 0) };
        player2 = new Player("Player2") { Resources = new Resources(1, 1, 1, 1, 0) };
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
[Trait("HasTicket", "Id-bad55473-9d5e-4b0a-ae34-ba782e216651")]public void CanBuildSettlementOnLocation()
{
    // Arrange
    InitializePlayerResources(player1, 1, 0, 0, 0, 1);
    var board = new Board(_logger);
    var location = new Location(3, 3);
    // Act
    var result = board.TryBuildSettlement(player1, location);
    // Assert
    Assert.True(result, "Player 1 was not able to build a settlement.");
    Assert.True(player1.Resources.HasSufficientResources(1, 0, 0, 0, 1), "Player 1 did not have sufficient resources.");
}
    private Player player1;
    private Player player2;
    [Fact]
    public void CannotBuildOnInsufficientResources()
    {
        // Arrange
        var player = new Player("Player1") { Resources = new Resources(0, 0, 0, 0, 0) };
        var board = new Board(_logger);
        var location = new Location(1, 1);

        // Act
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement with insufficient resources.");
    }

    [Fact]
    public void CannotBuildSettlementWithoutNecessaryResources()
    {
        // Arrange
        var player = new Player("TestPlayer");
        var location = new Location(0, 0);

        // Act
        var result = player.TryBuildSettlement(location);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanBuildSettlementWithSufficientResources()
    {
        // Arrange
        player = new Player("TestPlayer");
        player.Resources = new Resources(1, 0, 0, 0, 1); // Set sufficient resources
        var location = new Location(1, 1); // Valid location

        // Act
        var canBuild = player.TryBuildSettlement(location);

        // Assert
        Assert.True(canBuild);
        Log.Information($"CanBuild: {canBuild} with resources {player.Resources.Wood}, {player.Resources.Brick}, {player.Resources.Wheat}, {player.Resources.Sheep}, {player.Resources.Stone}");
    }

    [Fact]
    public void CannotBuildTwoSettlementWithoutNecessaryResources()
    {
        // Arrange
        player = new Player("TestPlayer");
        player.Resources = new Resources(1, 1, 1, 1, 0);

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
[Trait("HasTicket", "Id-bad55473-9d5e-4b0a-ae34-ba782e216651")]public void CanBuildTwoSettlementWithSufficientResources()
    {
        // Arrange
        player = new Player("TestPlayer");
        player.Resources = new Resources(2, 2, 2, 2, 0); // Set to valid resources
        var board = new Board(_logger);
        var location1 = new Location(1, 1);
        var location2 = new Location(2, 2);

        // Act
        var result1 = board.TryBuildSettlement(player, location1);
        var result2 = board.TryBuildSettlement(player, location2);

        // Assert
        Assert.True(result1, "Player was unable to build the first settlement with sufficient resources.");
        Assert.True(result2, "Player was unable to build the second settlement with sufficient resources.");
        Assert.True(player.Resources.HasSufficientResources(0, 0, 0, 0, 0), "Player should have sufficient resources after building two settlements.");
    }

    [Fact]
    public void CannotBuildSettlementOnOccupiedLocation()
    {
        // Arrange
        var player = new Player("TestPlayer");
        player.Resources = new Resources(1, 0, 0, 0, 1);
        var board = new Board(_logger);
        var location = new Location(1, 1);
        board.TryBuildSettlement(player, location); // Build first settlement
        var result = board.TryBuildSettlement(player, location); // Attempting to build on the same location
        // Assert
        Assert.False(result, "Player was able to build a settlement on an occupied location.");
    }
    private void InitializePlayerResources(Player player, int wood, int brick, int wheat, int sheep, int stone) { player.Resources = new Resources(wood, brick, wheat, sheep, stone); }
}