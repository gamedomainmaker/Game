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
        if (location == null || !IsLocationOccupied(location)) return false;

        var settlement = Settlements.FirstOrDefault(s => s.Location.Equals(location));
        if (settlement == null) return false;

        // Check if the player has sufficient resources to upgrade
        if (player.Resources.Wheat < 2 || player.Resources.Stone < 3)
        {
            System.Console.WriteLine($"Insufficient resources: Wheat - {player.Resources.Wheat}, Stone - {player.Resources.Stone}");
            return false;
        }

        // Adding debug logging for resource tracking
        System.Console.WriteLine($"Attempting to upgrade settlement at {location}. Player resources: Wheat - {player.Resources.Wheat}, Stone - {player.Resources.Stone}");

        // Deduct the resources required for upgrading
        player.Resources.Wheat -= 2;
        player.Resources.Stone -= 3;

        // Assuming that the settlement will have some upgrade logic applied here

        return true;  // Indicate the upgrade was successful
    } }