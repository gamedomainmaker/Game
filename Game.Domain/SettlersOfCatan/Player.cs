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

    public void AddSettlement(Settlement settlement)
    {
        settlements.Add(settlement);
    }
    public int SettlementCount()
    {
        return settlements.Count;
    }
public List<Settlement> Settlements { get { return settlements; } } public string Name { get; set; } = string.Empty; public bool HasSettlementAt(Location location)
{
    return Settlements.Any(settlement => settlement.Location.Equals(location));
} public void BuildSettlement(Settlement location) {
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
} }