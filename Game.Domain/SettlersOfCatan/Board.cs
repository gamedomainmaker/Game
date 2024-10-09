namespace Game.Domain;

using System.Collections.Generic;
using System.Linq;

public class Board
{
    public List<Settlement> Settlements { get; set; } = new List<Settlement>();

    public bool IsLocationOccupied(Location location)
    {
        return Settlements.Any(s => s.Location.Equals(location));
    }

    public bool IsValidLocation(Location location)
    {
        return location != null &&
               location.X >= 0 && location.Y >= 0;
    }

    public bool TryBuildSettlement(Player player, Location location)
    {
        if (location == null || !IsValidLocation(location)) return false;
        if (player.Resources.Wood < 1 || player.Resources.Brick < 1 || player.Resources.Wheat < 1 || player.Resources.Sheep < 1) return false;
        if (player.SettlementCount() >= player.MaxSettlements) return false;
        if (IsLocationOccupied(location)) return false;

        var settlement = new Settlement(location);
        Settlements.Add(settlement);
        player.AddSettlement(settlement);
        player.Resources.Wood--;
        player.Resources.Brick--;
        player.Resources.Wheat--;
        player.Resources.Sheep--;
        return true;
    }

    public bool IsOccupied(Location location)
    {
        return Settlements.Any(s => s.Location.Equals(location));
    }
public bool TryUpgradeSettlement(Player player, Location location)
{
    // Check if the player has enough resources
    if (player.Resources.Wheat < 2 || player.Resources.Stone < 3)
    {
        Console.WriteLine("Insufficient resources for upgrade.");
        return false;
    }

    // Check if the player has a settlement at the specified location
    if (!player.Settlements.Any(s => s.Location.Equals(location)))
    {
        Console.WriteLine("No settlement present at the specified location.");
        return false;
    }

    // Proceed with upgrade logic here...
    // Deduct resources
    player.Resources.Wheat -= 2;
    player.Resources.Stone -= 3;

    // Upgrade settlement to city logic...
    Console.WriteLine("Settlement upgraded to city.");
    return true;
} }