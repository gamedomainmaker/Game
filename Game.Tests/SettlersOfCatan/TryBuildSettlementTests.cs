using Game.Domain;

namespace Game.Tests;

public class TryBuildSettlementTests
{
    private Player? player1;
    private Player? player2;
    private Player? player;

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
    [Trait("HasTicket","Id-e572a51e-f30f-4b33-8203-ab6a0dac2f03")]
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
    public void CanBuildSettlementWithSufficientResources()
    {
        // Arrange
        player1 = new Player
        {
            Resources = new Resources(1, 1, 1, 1) // Ensure these values match the game's requirements for building a settlement
        };
        var board = new Board();
        var location = new Location(1, 1); // Valid location

        // Act
        var result = board.TryBuildSettlement(player1, location);

        // Assert
        Assert.True(result, "Player was unable to build a settlement with sufficient resources.");
    }

    [Fact]
    public void CannotBuildSettlementAboveMaxLimit()
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

    [Fact]
    public void CannotBuildSettlementWithoutAllResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(1, 0, 1, 1) }; // Missing one resource
        var board = new Board();
        var location = new Location(1, 1); // Valid location

        // Act
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement without all necessary resources.");
    }

    [Fact]
    [Trait("HasTicket","Id-e572a51e-f30f-4b33-8203-ab6a0dac2f03")]
    public void CannotBuildOnOccupiedLocation()
    {
        // Arrange
        player1 = new Player { Resources = new Resources(1, 1, 1, 1) };
        player2 = new Player { Resources = new Resources(1, 1, 1, 1) };
        var board = new Board();
        var location = new Location(0, 0); // Location to be occupied

        // Player 1 builds a settlement at the location.
        board.TryBuildSettlement(player1, location);

        // Act
        var result = board.TryBuildSettlement(player2, location); // Player 2 tries to build on the occupied spot

        // Assert
        Assert.False(result, "Player 2 was able to build a settlement on a location occupied by Player 1.");
    }

    [Fact]
    public void CannotBuildSettlementWithInsufficientResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(0, 1, 1, 1) }; // Not enough resources
        var board = new Board();
        var location = new Location(3, 3); // Valid location

        // Act
        var result = board.TryBuildSettlement(player, location); // Player with insufficient resources tries to build

        // Assert
        Assert.False(result, "Player with insufficient resources should not be able to build a settlement.");
    }

    [Fact]
    public void CannotBuildTwoSettlementWithInsufficientResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(1, 1, 2, 2) }; // Missing resources for second settlement
        var board = new Board();
        var location = new Location(3, 3); // Valid location

        // Act
        var result = board.TryBuildSettlement(player, location);
        
        // Assert
        Assert.True(result, "Player has resources and should be able to build a settlement.");

        // Act
        location = new Location(4, 4); // Valid location
        result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player now doesn't have enough resources and should not be able to build a settlement.");
    }
}