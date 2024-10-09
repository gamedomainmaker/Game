using Game.Domain;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    private Player player { get; set; } = new Player();
    private List<Settlement> settlements { get; set; } = new List<Settlement>();

    public TryUpgradeSettlementTests() {
        Setup();
    }
    private void Setup()
{
    player = new Player();
    player.Resources = new Resources(2, 3, 0, 0, 0); // Enough resources for upgrade
    settlements = new List<Settlement>();
    // Initialize a settlement for testing
    var location = new Location(0, 0);
    var settlement = new Settlement(location, player);
    settlements.Add(settlement);
}

    [Fact] 
    public void CanUpgradeSettlementToCity() { /* Arrange logic */ }
    [Theory]
[InlineData(0, 0)]
[InlineData(1, 1)]
[Trait("HasTicket", "Id-8f5efd1b-2ba6-4c2b-9441-490c706db749")]public void BuildSettlement(int x, int y)
{
    var location = new Location(x, y);
    var settlement = new Settlement(location, player);
    Assert.True(player.TryBuildSettlement(location)); // Assert improved
    Assert.Contains(settlement, player.Settlements);
}

    [Fact]
    [Trait("HasTicket", "Id-822fc64b-7823-4d42-b8db-8399e616d86d")]
    public void Correctly_Upgrades_Settlement_With_Sufficient_Resources()
    {
        var resources = new Resources(2, 3, 0, 0, 0); // Enough resources for upgrade
        player.Resources = resources;
        var location = new Location(0, 0);

        var settlement = new Settlement(location, player); // Fixed constructor usage
        player.BuildSettlement(settlement);
        var result = settlement.UpgradeToCity(player);

        Assert.True(result);
    }

    [Fact]
    [Trait("HasTicket", "Id-822fc64b-7823-4d42-b8db-8399e616d86d")]
    public void Can_Not_Upgrade_Settlement_To_City()
    {
        var board = new Board();
        var resources = new Resources(0, 0, 1, 0, 0); // Insufficient resources: not enough Wheat and Stone
        board.TryBuildSettlement(player, settlements[0].Location);

        var result = board.TryUpgradeSettlement(player, settlements[0].Location);

        Assert.False(result);
    }
}