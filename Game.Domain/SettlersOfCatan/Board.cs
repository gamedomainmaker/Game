namespace Game.Domain;

public class Board
{
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
    }

    public bool IsLocationOccupied(Location location)
    {
        // Check if the location is occupied by any player
        return Settlements.Any(s => s.Location.Equals(location)); // Check if any settlement is present at the location
    }

    public bool IsValidLocation(Location location)
    {
        // Implement your logic to validate the location
        return location != null && 
               location.X >= 0 && location.Y >= 0 && 
               !Settlements.Any(s => s.Location.Equals(location)); 
    }

    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
}