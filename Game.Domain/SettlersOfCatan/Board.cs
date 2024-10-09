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
        if (location == null || !IsValidLocation(location)) return false; // Check for valid location
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
        // Check if the location is valid and occupied
        if (location == null || !IsLocationOccupied(location)) return false;

        // Find the existing settlement at the location
        var settlement = Settlements.FirstOrDefault(s => s.Location.Equals(location));
        if (settlement == null) return false;

        // Check if the player has enough resources to upgrade
        if (player.Resources.Wheat < 2 || player.Resources.Stone < 3) return false;

        // Adding debug logging for resource tracking
        Console.WriteLine($"Upgrading settlement at {location}. Player resources: Wheat - {player.Resources.Wheat}, Stone - {player.Resources.Stone}");

        // Upgrade the settlement logic here (you might want to modify the settlement type or increase its value)

        // Deduct the resources
        player.Resources.Wheat -= 2;
        player.Resources.Stone -= 3;

        return true;
    } }