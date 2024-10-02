namespace Game.Domain.SettlersOfCatan;

public class Board
{
    public bool TryBuildSettlement(Player player, Location location)
    {
        if (location.X < 0 || location.Y < 0) return false;

        if (IsOccupied(location)) return false; // Occupied location

        if (player.Resources.Wood < 1 || player.Resources.Brick < 1 || player.Resources.Wheat < 1 || player.Resources.Sheep < 1)
        {
            return false; // Not enough resources
        }

        if (player.Settlements.Count >= player.MaxSettlements)
        {
            return false; // Maximum settlements limit reached
        }

        Settlement newSettlement = new Settlement();
        player.Settlements.Add(newSettlement);
        return true;
    }

    public bool IsOccupied(Location location)
    {
        // Check if the location is occupied by any player
        return Settlements.Any(s => s.Location.Equals(location)); // Check if any settlement is present at the location
    }

    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
}