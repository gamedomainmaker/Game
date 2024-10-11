using Game.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    private Player player;
    private List<Settlement> settlements;
    private readonly ILogger<Board> _logger;
    public TryUpgradeSettlementTests(ITestOutputHelper output) 
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Sink(new XunitSink(output)) 
            .CreateLogger();

        var serviceCollection = new ServiceCollection()
            .AddLogging(builder =>
            {
                builder.AddSerilog();
            });
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _logger = serviceProvider.GetRequiredService<ILogger<Board>>();
        Setup();
    }

    private void Setup()
    {
        player = new Player("Test Player");
        settlements = new List<Settlement>();
        player.Resources = new Resources(2, 3, 0, 0, 0); // Enough resources for upgrade
        var location = new Location(0, 0);
        settlements.Add(new Settlement(location, player));
    }

    private void EnsureResourcesForUpgrade() {
        player.Resources = new Resources(2, 3, 1, 0, 1); // Required resources for upgrade
    }

    private void EnsureResourcesForSettlement() {
        player.Resources = new Resources(1, 0, 0, 0, 1); // Required resources for building a settlement
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void BuildSettlement(int x, int y) {
        EnsureResourcesForSettlement();
        var location = new Location(x, y);
        Assert.True(player.TryBuildSettlement(location)); // Assert improved
    }

    [Fact]
[Trait("HasTicket", "Id-19231067-76d7-43c6-a04d-e6974a5f4351")]public void Correctly_Upgrades_Settlement_With_Sufficient_Resources() {
        EnsureResourcesForUpgrade();
        var location = new Location(0, 0);
        var settlement = new Settlement(location, player);
        player.TryBuildSettlement(location);
        Assert.True(player.CanUpgradeSettlement(settlement));
    }

    // TODO: additional tests should use the new EnsureResourcesForSettlement and EnsureResourcesForUpgrade.
    [Fact]
    public void Can_Not_Upgrade_Settlement_To_City()
    {
        var board = new Board(_logger);
        var resources = new Resources(0, 0, 1, 0, 0); // Insufficient resources: not enough Wheat and Stone
        board.TryBuildSettlement(player, settlements[0].Location);

        var result = board.TryUpgradeSettlement(player, settlements[0].Location);

        Assert.False(result);
    }
    [Fact]
    public void CannotBuildSettlementWithoutNecessaryResources()
    {
        // Arrange
        var player = new Player("blah");
        var location = new Location(1, 1);
        player.Resources = new Resources(0, 0, 0, 0, 0); // No resources
                                                         // Act
        var result = player.TryBuildSettlement(location);
        // Assert
        Assert.False(result);
    }
    [Fact]
    public void CannotBuildSettlementAtOccupiedLocation()
    {
        // Arrange
        var player = new Player("blah");
        var location = new Location(0, 0);
        player.TryBuildSettlement(location); // First build
                                             // Act
        var result = player.TryBuildSettlement(location); // Attempt to build again
                                                          // Assert
        Assert.False(result);
    }
    [Fact]
    public void CannotBuildSettlementWithInsufficientResources()
    {
        // Arrange
        var player = new Player("blah");
        player.Resources = new Resources(0, 0, 0, 0, 0); // Not enough resources
        var location = new Location(1, 1);
        // Act
        var result = player.TryBuildSettlement(location);
        // Assert
        Assert.False(result);
    }
    [Fact]
    public void CannotBuildSettlementWithResourcesAsInt()
    {
        // Arrange
        var player = new Player("blah");
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
        var player = new Player("blah");
        // Act
        player.Resources = new Resources(0, 0, 0, 0, 0); // Proper resource initialization
                                                         // Assert
        Assert.IsType<Resources>(player.Resources);
    }
    [Fact]
public void Correctly_Fails_Upgrade_Settlement_With_Insufficient_Resources() {
    // Arrange
    player.Resources = new Resources(0, 0, 0, 0, 0); // Not enough resources for upgrade
    var location = new Location(2, 2);
    var settlement = new Settlement(location, player);
    // Act
    var result = settlement.TryUpgradeSettlement(player);
    // Assert
    Assert.False(result);
}
    [Fact]
public void CheckResourcesForUpgrade() {
    // Arrange
    var player = new Player("blah");
    player.Resources = new Resources(1, 0, 2, 0, 1); // Setting resources for testing
    var location = new Location(0, 0);
    var settlement = new Settlement(location, player);
    // Act
    var result = settlement.TryUpgradeSettlement(player);
    // Assert
    Assert.True(result);
}
    [Fact]
public void CannotUpgradeSettlementWithInsufficientResources() {
    // Arrange
    player.Resources = new Resources(0, 0, 0, 0, 0); // Not enough resources
    var location = new Location(2, 2);
    var settlement = new Settlement(location, player);
    // Act
    var result = settlement.TryUpgradeSettlement(player);
    // Assert
    Assert.False(result);
}
    private void SetupPlayerWithSufficientResources() { player.Resources = new Resources(2, 3, 1, 0, 1); }
    private void SetupSettlementForTesting() { var location = new Location(0, 0); var settlement = new Settlement(location, player); player.Settlements.Add(settlement); }
}