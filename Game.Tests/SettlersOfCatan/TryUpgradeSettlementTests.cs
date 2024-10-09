using Game.Domain;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
[Fact][Trait("HasTicket", "Id-f2f1bb65-d572-4306-befe-f8ef8f4b53df")] public void CanUpgradeSettlementToCity()
{
    var board = new Board();
    var player = new Player();
    var resources = new Resources(0, 0, 2, 0, 3); // Player resources: 2 Wheat, 3 Stone
    player.Resources = resources;
    var location = new Location(0, 0); // Location must have a settlement built

    board.TryBuildSettlement(player, location); // Build a settlement first

    // Attempt to upgrade the settlement
    var result = board.TryUpgradeSettlement(player, location);

    Assert.True(result);
} [Fact]    public void CanNotUpgradeSettlementToCity()
    {
        var board = new Board();
        var player = new Player();
        var resources = new Resources(0, 0, 1, 0, 0); // Insufficient resources: not enough Wheat and Stone
        player.Resources = resources;
        var location = new Location(0, 0); // This location should have a settlement to upgrade

        board.TryBuildSettlement(player, location);

        // Now attempt to upgrade the settlement with insufficient resources
        var result = board.TryUpgradeSettlement(player, location);

        Assert.False(result);
    }
}