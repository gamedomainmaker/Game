using System.Numerics;
using Xunit;
using Game;

namespace Game.Tests;

public class SettlersOfCatanTests
{
    [Fact]
    public void CannotBuildSettlementWithoutNecessaryResources()
    {
        // Arrange
        var player = new Player();
        player.Resources = new Resources(0, 0, 0, 0); // No resources

        var board = new Board();
        var location = new Location(1, 1); // Arbitrary valid location

        // Act
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement without the necessary resources.");
    }

    [Fact]
    public void CannotBuildSettlementOnInvalidLocation()
    {
        // Arrange
        var player = new Player();
        player.Resources = new Resources(1, 1, 1, 1); // Has the necessary resources

        var board = new Board();
        var invalidLocation = new Location(-1, -1); // Invalid location off the board

        // Act
        var result = board.TryBuildSettlement(player, invalidLocation);

        // Assert
        Assert.False(result, "Player was able to build a settlement on an invalid location.");
    }

    [Fact]
    public void CannotBuildSettlementOnOccupiedLocation()
    {
        // Arrange
        var player1 = new Player();
        var player2 = new Player();
        player1.Resources = new Resources(1, 1, 1, 1); // Has the necessary resources
        player2.Resources = new Resources(1, 1, 1, 1);

        var board = new Board();
        var location = new Location(1, 1); // Valid location

        // Act
        board.TryBuildSettlement(player1, location); // Player 1 builds a settlement
        var result = board.TryBuildSettlement(player2, location); // Player 2 tries to build on the same spot

        // Assert
        Assert.False(result, "Player was able to build a settlement on an already occupied location.");
    }

    [Fact]
    public void CannotBuildMoreThanMaxSettlements()
    {
        // Arrange
        var player = new Player();
        player.Resources = new Resources(10, 10, 10, 10); // Plenty of resources
        player.MaxSettlements = 5; // Limit the number of settlements a player can build

        var board = new Board();

        // Act
        for (int i = 0; i < player.MaxSettlements; i++)
        {
            board.TryBuildSettlement(player, new Location(i, i)); // Build settlements up to the limit
        }

        var result = board.TryBuildSettlement(player, new Location(6, 6)); // Try to build one more

        // Assert
        Assert.False(result, "Player was able to build more settlements than allowed.");
    }
}
