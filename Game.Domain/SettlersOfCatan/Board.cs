namespace Game.Domain;

using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

public class Board
{
    private readonly ILogger<Board> _logger;
    public List<Settlement> Settlements { get; set; } = new List<Settlement>();

    public Board(ILogger<Board> logger)
    {
        _logger = logger;
    }

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
    // Ensuring the location is valid before proceeding
    if (!IsValidLocation(location) || IsOccupied(location)) {
        return false; // Invalid or occupied location
    }
    // Ensure the player has enough resources before building
    if (!player.TryBuildSettlement(location)) {
        return false; // Player cannot build settlement
    }
    // Logic for building the settlement
    var settlement = new Settlement(location, player); // Pass player as owner
    Settlements.Add(settlement);
    return true;
}

    public bool IsOccupied(Location location)
    {
        return Settlements.Any(s => s.Location.Equals(location));
    }
    public bool TryUpgradeSettlement(Player player, Location location)
    {
        // Debug logging
        Console.WriteLine($"Attempting to upgrade settlement at {location} for player {player.Name}.");
        Console.WriteLine($"Player Resources: {player.Resources.ToString()}");

        // Check if player has enough resources
        if (player.Resources.Wheat < 2)
        {
            Console.WriteLine("Not enough Wheat.");
            return false;
        }
        if (player.Resources.Stone < 3)
        {
            Console.WriteLine("Not enough Stone.");
            return false;
        }

        // Check if the player has a settlement at the specified location
        if (!player.HasSettlementAt(location))
        {
            Console.WriteLine("No settlement exists at specified location.");
            return false;
        }

        // Upgrade logic...
        player.Resources.Wheat -= 2;
        player.Resources.Stone -= 3;
        // Additional upgrade logic here
        // Return true if upgrade was successful
        return true;
    }
    public bool IsLocationValid(Location location)
    {
        return IsValidLocation(location) && !IsOccupied(location);
    }
}