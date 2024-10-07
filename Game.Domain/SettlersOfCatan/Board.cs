namespace Game.Domain;

using System.Collections.Generic;
using System.Linq;

public class Board
{
    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
public bool IsLocationOccupied(Location location)
    {
        return Settlements.Any(s => s.Location.Equals(location));
    } public bool IsValidLocation(Location location)
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

        player.AddSettlement(new Settlement(location));
        player.Resources.Wood--;
        player.Resources.Brick--;
        player.Resources.Wheat--;
        player.Resources.Sheep--;
        return true;
    } }