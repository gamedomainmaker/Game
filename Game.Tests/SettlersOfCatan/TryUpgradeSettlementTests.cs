using Game.Domain;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    private Player player { get; set; } = new Player();
    private List<Settlement> settlements { get; set; } = new List<Settlement>();
    public TryUpgradeSettlementTests()
{
    Setup();
    player.Resources = new Resources(2, 3, 0, 0, 0); // Enough resources for upgrade
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

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
[Trait("HasTicket", "Id-5fa20b41-09d7-42c7-b284-96386310bfb9")]public void BuildSettlement(int x, int y)
    {
        var location = new Location(x, y);
        var settlement = new Settlement(location, player);
        Assert.True(player.TryBuildSettlement(location)); // Assert improved
        Assert.Contains(settlement, player.Settlements);
    }
    [Fact]
[Trait("HasTicket", "Id-5fa20b41-09d7-42c7-b284-96386310bfb9")]public void Correctly_Upgrades_Settlement_With_Sufficient_Resources()
{
    // Arrange
    player = new Player();
    player.Resources = new Resources(2, 2, 0, 0, 0); // Adjusting resources for upgrade
    var location = new Location(0, 0);
    var settlement = new Settlement(location, player);
    settlements.Add(settlement);
    
    // Act
    var result = settlement.UpgradeSettlement(player);
    
    // Assert
    Assert.True(settlement.IsUpgraded);
}

    [Fact]
    public void Can_Not_Upgrade_Settlement_To_City()
    {
        var board = new Board();
        var resources = new Resources(0, 0, 1, 0, 0); // Insufficient resources: not enough Wheat and Stone
        board.TryBuildSettlement(player, settlements[0].Location);

        var result = board.TryUpgradeSettlement(player, settlements[0].Location);

        Assert.False(result);
    }
    [Fact]
public void CannotBuildSettlementWithoutNecessaryResources() {
    // Arrange
    var player = new Player();
    var location = new Location(1, 1);
    player.Resources = new Resources(0,0,0,0,0); // No resources
    // Act
    var result = player.TryBuildSettlement(location);
    // Assert
    Assert.False(result);
} 
    [Fact]
public void CannotBuildSettlementAtOccupiedLocation() {
    // Arrange
    var player = new Player();
    var location = new Location(0, 0);
    player.TryBuildSettlement(location); // First build
    // Act
    var result = player.TryBuildSettlement(location); // Attempt to build again
    // Assert
    Assert.False(result);
} 
    [Fact]
[Trait("HasTicket", "Id-5fa20b41-09d7-42c7-b284-96386310bfb9")]public void CanBuildSettlementWithSufficientResources() {
    // Arrange
    var player = new Player();
    player.Resources = new Resources(0, 0, 0, 0, 0); // Enough resources
    var location = new Location(2, 2);
    // Act
    var result = player.TryBuildSettlement(location);
    // Assert
    Assert.True(result);
} 
    [Fact]
public void CannotBuildSettlementWithInsufficientResources() {
    // Arrange
    var player = new Player();
    player.Resources = new Resources(0, 0, 0, 0, 0); // Not enough resources
    var location = new Location(1, 1);
    // Act
    var result = player.TryBuildSettlement(location);
    // Assert
    Assert.False(result);
} 
    [Fact]
[Trait("HasTicket", "Id-5fa20b41-09d7-42c7-b284-96386310bfb9")]public void CannotUpgradeSettlementWithInsufficientResources()
{
    // Arrange
    var player = new Player();
    player.Resources = new Resources(0, 0, 0, 0, 0); // No resources
    var location = new Location(1, 1);
    var settlement = new Settlement(location, player);
    // Act
    var result = settlement.UpgradeToCity(player);
    // Assert
    Assert.False(result);
}
    [Fact]
public void CannotBuildSettlementWithResourcesAsInt()
{
    // Arrange
    var player = new Player();
    var location = new Location(1, 1);
    player.Resources = new Resources(0, 0, 0, 0, 0); // No resources
    // Act
    var result = player.TryBuildSettlement(location);
    // Assert
    Assert.False(result);
}
    [Fact]
public void CannotSetResourcesAsResourcesObject()
{
    // Arrange
    var player = new Player();
    // Act
    player.Resources = new Resources(0, 0, 0, 0, 0); // Proper resource initialization
    // Assert
    Assert.IsType<Resources>(player.Resources);
}
    public Resources Resources { get; private set; } = new Resources(0, 0, 0, 0, 0);
}