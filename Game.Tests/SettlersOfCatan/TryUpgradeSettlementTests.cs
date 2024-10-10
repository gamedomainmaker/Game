using Game.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    private Player player { get; set; } = new Player();
    private List<Settlement> settlements { get; set; } = new List<Settlement>();
    private readonly ILogger<Board> _logger;

    public TryUpgradeSettlementTests(ITestOutputHelper output)
    {
        // Configure Serilog to log to both console and file
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Sink(new XunitSink(output)) // Use custom sink
            .CreateLogger();

        // Configure logging for the test
        var serviceCollection = new ServiceCollection()
            .AddLogging(builder =>
            {
                builder.AddSerilog();
            });
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _logger = serviceProvider.GetRequiredService<ILogger<Board>>();
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
[Trait("HasTicket", "Id-52fe213c-e224-473f-b2c1-01bdff653b90")]public void BuildSettlement(int x, int y)
    {
        var location = new Location(x, y);
        var settlement = new Settlement(location, player);
        Assert.True(player.TryBuildSettlement(location)); // Assert improved
        Assert.Contains(settlement, player.Settlements);
    }

    [Fact]
[Trait("HasTicket", "Id-de2e0a37-0080-45ac-a140-875e34037fcd")]    public void Correctly_Upgrades_Settlement_With_Sufficient_Resources() {
    // Arrange
    player.Resources.Wood = 2;
    player.Resources.Brick = 1;
    player.Resources.Wheat = 1;
    var location = new Location(0, 0);
    var settlement = new Settlement(location, player);
    player.TryBuildSettlement(location); // Ensure the settlement is built
    // Act
    var result = player.CanUpgradeSettlement(settlement);
    // Assert
    Assert.True(result);
}

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
        var player = new Player();
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
        var player = new Player();
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
        var player = new Player();
        player.Resources = new Resources(0, 0, 0, 0, 0); // Not enough resources
        var location = new Location(1, 1);
        // Act
        var result = player.TryBuildSettlement(location);
        // Assert
        Assert.False(result);
    }
    [Fact]
[Trait("HasTicket", "Id-87c73faa-e2af-4257-907a-fc51df32b4b1")]public void CannotUpgradeSettlementWithInsufficientResources()
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
[Trait("HasTicket", "Id-52fe213c-e224-473f-b2c1-01bdff653b90")]public void CheckResourcesForUpgrade() {
    // Arrange
    var player = new Player();
    player.Resources = new Resources(1, 0, 2, 0, 1); // Setting resources for testing
    var location = new Location(0, 0);
    var settlement = new Settlement(location, player);
    // Act
    var result = settlement.TryUpgradeSettlement(player);
    // Assert
    Assert.True(result);
}
}