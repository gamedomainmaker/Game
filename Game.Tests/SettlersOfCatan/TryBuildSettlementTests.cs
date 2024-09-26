using System.Numerics;
using Xunit;

namespace Game.Tests.SettlersOfCatan;

public class TryBuildSettlementTests
{
    private Player player1;
    private Player player2;
    private Player player;

    [Fact]
    public void CannotBuildSettlementWithoutNecessaryResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(0, 0, 0, 0) };

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
        player = new Player { Resources = new Resources(1, 1, 1, 1) };

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
        player1 = new Player { Resources = new Resources(1, 1, 1, 1) };
        player2 = new Player { Resources = new Resources(1, 1, 1, 1) };
        player = new Player { Resources = new Resources(10, 10, 10, 10), MaxSettlements = 5 };

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
        player = new Player { Resources = new Resources(10, 10, 10, 10), MaxSettlements = 5 };

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