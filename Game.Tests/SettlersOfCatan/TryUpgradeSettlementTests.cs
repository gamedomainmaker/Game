using System.Numerics;
using Game.Domain;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
    [Fact]
[Trait("HasTicket", "Id-734404d6-adc7-4960-98f9-48c47bed13c1")]    public void CanUpgradeSettlementToCity()
    {
        var board = new Board();
        var player = new Player(); // Assuming a default constructor exists
        var location = new Location(0, 0); // Provide appropriate values for x and y

        // Call the method to be tested
        var result = board.TryUpgradeSettlement(player, location);

        Assert.True(result);
    }

    [Fact]
    public void CanNotUpgradeSettlementToCity()
    {
        var board = new Board();
        var player = new Player(); // Assuming a default constructor exists
        var location = new Location(0, 0); // Provide appropriate values for x and y

        // Call the method to be tested
        var result = board.TryUpgradeSettlement(player, location);

        Assert.False(result);
    }
}