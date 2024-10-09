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
    public bool TryBuildSettlement(Player player, Location location) {
    // Ensure the location is valid and not occupied
    if (!IsValidLocation(location) || IsLocationOccupied(location)) {
        return false;
    }

    // Assuming a new settlement can be created from the player's resources
    Settlement settlement = new Settlement(location, player); // Pass the player as well
    Settlements.Add(settlement);
    
    return true; // Indicate that the settlement was successfully built
}

    public bool IsOccupied(Location location)
    {
        return Settlements.Any(s => s.Location.Equals(location));
    }
public bool TryUpgradeSettlement(Player player, Location location) {
    // Debug logging
    Console.WriteLine($"Attempting to upgrade settlement at {location} for player {player.Name}.");
    Console.WriteLine($"Player Resources: {player.Resources.ToString()}");
    
    // Check if player has enough resources
    if (player.Resources.Wheat < 2) {
        Console.WriteLine("Not enough Wheat.");
        return false;
    }
    if (player.Resources.Stone < 3) {
        Console.WriteLine("Not enough Stone.");
        return false;
    }
    
    // Check if the player has a settlement at the specified location
    if (!player.HasSettlementAt(location)) {
        Console.WriteLine("No settlement exists at specified location.");
        return false;
    }
    
    // Upgrade logic...
    player.Resources.Wheat -= 2;
    player.Resources.Stone -= 3;
    // Additional upgrade logic here
    // Return true if upgrade was successful
    return true;
}     public bool IsLocationValid(Location location) {
    return IsValidLocation(location) && !IsOccupied(location);
}
}