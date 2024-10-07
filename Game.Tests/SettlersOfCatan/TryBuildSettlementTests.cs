using Game.Domain;
using Xunit;

namespace Game.Tests;

public class TryBuildSettlementTests
{
    private Player? player1;
    private Player? player2;
    private Player? player;
[Fact]    public void CannotBuildSettlementWithoutNecessaryResources()
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
[Fact]    public void CanBuildSettlementWithSufficientResources()
    {
        // Arrange
        player1 = new Player
        {
            Resources = new Resources(1, 1, 1, 1)
        };
        var board = new Board();
        var location = new Location(1, 1);

        // Act
        var result = board.TryBuildSettlement(player1, location);

        // Assert
        Assert.True(result, "Player was unable to build a settlement with sufficient resources.");
    }
[Fact]    public void CannotBuildSettlementOnInvalidLocation()
    {
        // Arrange
        player = new Player { Resources = new Resources(1, 1, 1, 1) };

        var board = new Board();
        var invalidLocation = new Location(-1, -1);

        // Act
        var result = board.TryBuildSettlement(player, invalidLocation);

        // Assert
        Assert.False(result, "Player was able to build a settlement on an invalid location.");
    }
[Fact][Trait("HasTicket", "Id-763a4c7b-99d4-4b6d-8998-b4fe40659bc0")]public void CannotBuildOnOccupiedLocation()
    {
        // Arrange
        player1 = new Player { Resources = new Resources(1, 1, 1, 1) };
        player2 = new Player { Resources = new Resources(1, 1, 1, 1) };
        var board = new Board();
        var location = new Location(0, 0);

        // Player 1 builds a settlement at the location.
        board.TryBuildSettlement(player1, location);

        // Act
        var result = board.TryBuildSettlement(player2, location);

        // Assert
        Assert.False(result, "Player 2 was able to build a settlement on a location occupied by Player 1.");
    }
[Fact]    [Trait("HasTicket", "Id-734404d6-adc7-4960-98f9-48c47bed13c1")]public void CannotBuildOnAlreadyOccupiedLocation()
    {
        // Arrange
        player1 = new Player { Resources = new Resources(1, 1, 1, 1) };
        player2 = new Player { Resources = new Resources(1, 1, 1, 1) };
        var board = new Board();
        var location = new Location(2, 2);

        // Player 1 builds a settlement at the location.
        board.TryBuildSettlement(player1, location);

        // Act
        var result = board.TryBuildSettlement(player2, location);

        // Assert
        Assert.False(result, "Player 2 was able to build a settlement on a location occupied by Player 1.");
    } }