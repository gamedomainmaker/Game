using Game.Domain;

namespace Game.Tests;

public class TryBuildSettlementLocationTests
{
    private Player? player;
    private Player? player1;
    private Player? player2;
[Fact]    public void CannotBuildSettlementOnInvalidLocation()
    {
        // Arrange
        player = new Player { Resources = new Resources(1, 1, 1, 1, 0) };

        var board = new Board();
        var invalidLocation = new Location(-1, -1);

        // Act
        var result = board.TryBuildSettlement(player, invalidLocation);

        // Assert
        Assert.False(result, "Player was able to build a settlement on an invalid location.");
    }
[Fact]    public void CannotBuildOnOccupiedLocation_withOccupiedLocationTest()
    {
        // Arrange
        player1 = new Player { Resources = new Resources(1, 1, 1, 1, 0) };
        player2 = new Player { Resources = new Resources(1, 1, 1, 1, 0) };
        var board = new Board();
        var location = new Location(3, 3);

        // Player 1 builds a settlement at the location.
        board.TryBuildSettlement(player1, location);

        // Act
        var result = board.TryBuildSettlement(player2, location);

        // Assert
        Assert.False(result, "Player 2 was able to build a settlement on a location occupied by Player 1.");
    }
}