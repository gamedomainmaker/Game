using Game.Domain;
using Xunit;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    [Fact]
[Trait("HasTicket", "Id-0853f62d-5efa-4f40-817e-7c94283561b5")]    public void CanUpgradeSettlementToCity()
    {
        // Arrange
        var player = new Player();
        player.Resources.Wheat = 2;
        player.Resources.Stone = 3;
        var location = new Location(0, 0); // Using valid coordinates for the location
        player.BuildSettlement(location); // Ensure the settlement exists
        var board = new Board(); // Assuming a Board instance is already set up

        // Act
        bool result = board.TryUpgradeSettlement(player, location);

        // Assert
        Assert.True(result, "Expected to upgrade settlement, but got false.");
        Assert.Equal(0, player.Resources.Wheat); // Assert resource deduction
        Assert.Equal(0, player.Resources.Stone); // Assert resource deduction
    }

    [Fact]
    public void CanNotUpgradeSettlementToCity()
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

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void BuildSettlement(int x, int y) {
        // Implementation to build a settlement at the specified location
        var location = new Location(x, y);
        // Add further implementation here as required
    }
}