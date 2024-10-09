namespace Game.Domain;

public class Player
{
    public Resources Resources { get; set; } = new Resources(0, 0, 0, 0, 0);
    public int MaxSettlements { get; set; }
    private List<Settlement> settlements;

    public Player()
    {
        settlements = new List<Settlement>();
        MaxSettlements = 5; // Default Max Settlements
    }
    public void AddSettlement(Settlement settlement) {
    settlements.Add(settlement);
}
    public int SettlementCount()
    {
        return settlements.Count;
    }
public List<Settlement> Settlements { get { return settlements; } } public string Name { get; set; } = string.Empty;     public bool HasSettlementAt(Location location)
{
    return Settlements.Any(s => s.Location.Equals(location));
}
public void BuildSettlement(Settlement location) {
        // Implementation to build a settlement at the specified location
    } public void BuildCity(Settlement settlement) {
    if (settlement.UpgradeToCity(this)) {
        // Logic to replace the settlement with a city
    }
} public bool TryUpgradeSettlement(Settlement settlement) {
    if (settlement.UpgradeToCity(this)) {
        // Logic to successful upgrade
        return true;
    }
    return false;
}     public bool HasResourcesForSettlement()
    {
        return Resources.Wood >= 1 && Resources.Brick >= 1 && Resources.Wheat >= 1;
    }
    public bool CanPlaceSettlement(Location location)
    {
        // Assuming you have some logic to check if a settlement can be placed at the location
        // Implement that logic here
        return true; // Placeholder logic
    }
    public bool CanBuildSettlement(Location location)
        {
            if (Settlements.Any(s => s.Location.Equals(location)))
                return false;
            // Additional logic for checking resources...
            return true;
        }
    public bool TryBuildSettlement(Location location) {
    const int requiredResources = 5; // Placeholder value for required resources
    if (!IsLocationValid(location) || !HasEnoughResourcesForSettlement()) { // Fixed the condition check
        return false;
    }
    // Deduct resources for the settlement
    DeductResourcesForSettlement();
    // Logic to build the settlement
    return true;
}
    public bool IsLocationValid(Location location)
{
    // Assuming you have access to settlements to validate the location against them.
    return settlements.Any(s => s.Location.Equals(location));
}
    public bool HasEnoughResourcesForSettlement()
{
    return Resources.Wood >= 1 && Resources.Brick >= 1 && Resources.Wheat >= 1;
}
    public void DeductResourcesForSettlement()
{
    Resources.Wood -= 1;
    Resources.Brick -= 1;
    Resources.Wheat -= 1;
}
    private const int RequiredResources = 5;
}