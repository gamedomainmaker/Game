using System.Numerics;
using Game.Domain;

namespace Game.Tests.SettlersOfCatan;

public class TryUpgradeSettlementTests
{
[Fact][Trait("HasTicket", "Id-674d9e8c-e6e1-465f-9f49-338d92c49d93")]public void CanUpgradeSettlementToCity()
    {
        var board = new Board();
        var player = new Player(); // Assuming a default constructor exists
        var location = new Location(0, 0); // Provide appropriate values for x and y

        // Call the method to be tested
        var result = board.TryUpgradeSettlement(player, location);

        Assert.True(result);
    }
[Fact]    public void CanNotUpgradeSettlementToCity()
    {
        var board = new Board();
        var player = new Player(); // Assuming a default constructor exists
        var location = new Location(0, 0); // Provide appropriate values for x and y

        // Call the method to be tested
        var result = board.TryUpgradeSettlement(player, location);

        Assert.False(result);
    }
}