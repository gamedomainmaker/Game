using System.Collections.Generic;
using System.Linq;
using Game.Domain;

public class Player
{
    public string Name { get; set; }
    public Resources Resources { get; set; } = new Resources(0, 0, 0, 0, 0);
    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
    public bool HasSettlementAt(Location location) {
    // Logic to check if the player has a settlement at the given location
    // This should return true if a settlement exists; otherwise, false
    return Settlements.Any(settlement => settlement.Location.Equals(location));
}
    public bool TryBuildSettlement(Location location) {
        // Check if the location is valid and not occupied
        if (!Resources.HasSufficientResources(1, 0, 0, 0, 1)) {
            return false; // Not enough resources
        }
        if (!IsLocationValid(location) || IsLocationOccupied(location)) {
            return false; // Invalid or occupied location
        }
        // Additional logic for building a settlement
        return true; // Successful settlement build
    }
    public bool CanUpgradeSettlement(Settlement settlement) {
    // Logic to check if the player can upgrade the given settlement
    if (settlement.Owner != this) return false; // Only the owner can upgrade
    return CanUpgradeSettlementResources(); // Check resources and conditions
}
    public bool CanUpgradeSettlementResources() {
    // Ensure this checks correctly for all upgrade resources including wood and stone
    return Resources.Wheat >= 2 && Resources.Stone >= 1;
}
    public Resources OwnerResources => Resources;
    public bool IsLocationValid(Location location) {
    // Logic to determine if location is valid
    return true; // Placeholder for actual validation logic
}
    public bool IsLocationOccupied(Location location) {
    // Logic to determine if location is occupied
    return Settlements.Any(settlement => settlement.Location.Equals(location));
}
    public Player(string name) { Name = name; }
    // Implement other members
}