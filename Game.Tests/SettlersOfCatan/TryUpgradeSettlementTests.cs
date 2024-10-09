using Game.Domain;
using Xunit;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
[Fact][Trait("HasTicket", "Id-f2f1bb65-d572-4306-befe-f8ef8f4b53df")]public void CanUpgradeSettlementToCity()
{
    // Arrange
    var player = new Player();
    player.Resources.Wheat = 2;
    player.Resources.Stone = 3;
    var location = new Location(1, 2);
    var board = new Board();
    board.TryBuildSettlement(player, location); // Ensure a settlement exists

    // Act
    var result = board.TryUpgradeSettlement(player, location);

    // Assert
    Assert.True(result);
    Assert.Equal(0, player.Resources.Wheat);
    Assert.Equal(0, player.Resources.Stone);
} [Fact]public void CanNotUpgradeSettlementToCity()
    {
        var board = new Board();
        var player = new Player();
        var resources = new Resources(0, 0, 1, 0, 0); // Insufficient resources: not enough Wheat and Stone
        player.Resources = resources;
        var location = new Location(0, 0);

        board.TryBuildSettlement(player, location);

        var result = board.TryUpgradeSettlement(player, location);

        Assert.False(result);
    }
}