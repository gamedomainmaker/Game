namespace Game.Domain;

public class Board
{
    public bool TryBuildSettlement(Player player, Location location)
    {
        if (player.Resources.Wood < 1 || player.Resources.Brick < 1 || player.Resources.Wheat < 1 || player.Resources.Sheep < 1) return false;
        if (player.SettlementCount() >= player.MaxSettlements) return false;
        if (IsLocationOccupied(location) || location == null) return false;

        // Logic to build the settlement in the desired location should be here.
        player.AddSettlement(new Settlement(location)); // Check if location is valid and not already occupied
                                                        // Deduct resources from the player
        player.Resources.Wood--;
        player.Resources.Brick--;
        player.Resources.Wheat--;
        player.Resources.Sheep--;
        return true;
    }

    public bool IsOccupied(Location location)
    {
        // Check if the location is occupied by any player
        return Settlements.Any(s => s.Location.Equals(location)); // Check if any settlement is present at the location
    }

    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
public bool IsLocationOccupied(Location location)
    {
        // Check if the location is occupied by any player
        return Settlements.Any(s => s.Location.Equals(location)); // Check if any settlement is present at the location
    } }