using Game.Domain;
using Xunit;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    private Player player;
    [Fact] public void CanUpgradeSettlementToCity() { /* Arrange logic */ }
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
[Trait("HasTicket", "Id-b0303bbe-8709-4b54-994d-0bcfae4485ea")]public void BuildSettlement(int x, int y)
    {
        var location = new Location(x, y);
        var settlement = new Settlement(location);
        player.BuildSettlement(settlement);
        Assert.True(player.Settlements.Contains(settlement));
    }
    [Fact]
[Trait("HasTicket", "Id-b0303bbe-8709-4b54-994d-0bcfae4485ea")]public void Correctly_Upgrades_Settlement_With_Sufficient_Resources()
    {
        var resources = new Resources(2, 3, 0, 0, 0); // Enough resources for upgrade
        player.Resources = resources;
        var location = new Location(0, 0);

        var settlement = new Settlement(location);
        player.BuildSettlement(settlement);
        var result = settlement.UpgradeToCity(player);

        Assert.True(result);
    }
    [Fact]
    public void Setup() {
        player = new Player();
        player.Resources = new Resources(2, 2, 2, 0, 0); // Assign sufficient resources
        // Optionally add a default settlement for other tests if necessary
    }
}