namespace Game.Domain.SettlersOfCatan;

public class Board
{
public bool TryBuildSettlement(Player player, Location location)
{
    // Check if the location is valid
    if (location.X < 0 || location.Y < 0) return false; // Invalid location

    // Check if the settlement at the location is already occupied
    if (IsOccupied(location)) return false; // Occupied location

    // Check if the player has sufficient resources
    if (player.Resources.Wood < 1 || player.Resources.Brick < 1 || player.Resources.Wheat < 1 || player.Resources.Sheep < 1)
    {
        return false; // Not enough resources
    }

    // Check if the player has reached the maximum number of settlements
    if (player.Settlements.Count >= player.MaxSettlements)
    {
        return false; // Maximum settlements limit reached
    }

    // If all checks pass, build the settlement
    Settlement newSettlement = new Settlement(); // Create a new settlement
    player.Settlements.Add(newSettlement); // Assuming settlements are stored in a list
    return true; // Successful settlement building
} public bool IsOccupied(Location location)
{
    // Logic to check if the location is occupied by any player
    return Settlements.Any(s => s.Location.Equals(location)); // Check against existing settlements
} public List<Settlement> Settlements { get; set; } = new List<Settlement>(); }