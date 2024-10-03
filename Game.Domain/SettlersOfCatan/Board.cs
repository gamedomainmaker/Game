namespace Game.Domain.SettlersOfCatan;

public class Board
{
public bool TryBuildSettlement(Player player, Location location)
    {
        // Check for valid location
        if (location.X < 0 || location.Y < 0) return false;

        // Check if the location is occupied by another player's settlement
        if (IsOccupied(location))
        {
            return false; // Can't build on an occupied location
        }

        // Ensure the player has enough resources to build a settlement
        if (player.Resources.Wood < 1 || player.Resources.Brick < 1 || player.Resources.Wheat < 1 || player.Resources.Sheep < 1)
        {
            return false; // Not enough resources
        }

        // Check if the player has reached their maximum settlements limit
        if (player.Settlements.Count >= player.MaxSettlements)
        {
            return false; // Maximum settlements limit reached
        }

        // Proceed to build the new settlement
        Settlement newSettlement = new Settlement { Location = location }; 
        player.Settlements.Add(newSettlement);
        Settlements.Add(newSettlement);
        return true;
    }     public bool IsOccupied(Location location)
    {
        // Check if the location is occupied by any player
        return Settlements.Any(s => s.Location.Equals(location)); // Check if any settlement is present at the location
    }

    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
}