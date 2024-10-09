using Game.Domain;

namespace Game.Tests;

public class TryBuildSettlementResourceTests
{
    private Player? player;
[Fact]public void CannotBuildSettlementWithoutNecessaryResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(0, 0, 0, 0, 0) };

        var board = new Board();
        var location = new Location(1, 1); // Arbitrary valid location

        // Act
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement without the necessary resources.");
    }
[Fact][Trait("HasTicket", "Id-ebc36372-78d7-4569-b6e1-442a698d47b4")]public void CanBuildSettlementWithSufficientResources()
    {
        // Arrange
        player = new Player
        {
            Resources = new Resources(1, 1, 1, 1, 0)
        };
        var board = new Board();
        var location = new Location(1, 1);

        // Act
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.True(result, "Player was unable to build a settlement with sufficient resources.");
    }
[Fact]public void CannotBuildTwoSettlementWithoutNecessaryResources()
    {
        // Arrange
        player = new Player { Resources = new Resources(1, 1, 1, 1, 0) };

        var board = new Board();
        var location = new Location(1, 1); // Arbitrary valid location

        // Act
        board.TryBuildSettlement(player, location);

        location = new Location(2, 2);
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.False(result, "Player was able to build a settlement without the necessary resources.");
    }
[Fact][Trait("HasTicket", "Id-ebc36372-78d7-4569-b6e1-442a698d47b4")]public void CanBuildTwoSettlementWithSufficientResources()
    {
        // Arrange
        player = new Player
        {
            Resources = new Resources(2, 2, 2, 2, 0)
        };
        var board = new Board();
        var location = new Location(1, 1);

        // Act
        board.TryBuildSettlement(player, location);

        location = new Location(2, 2);
        var result = board.TryBuildSettlement(player, location);

        // Assert
        Assert.True(result, "Player was unable to build a settlement with sufficient resources.");
    }
}