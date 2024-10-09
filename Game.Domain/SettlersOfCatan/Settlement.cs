using Game.Domain;

public class Settlement
{
    private Location? _location;
    public Location Location
{
    get => _location ?? throw new InvalidOperationException("Location is not set.");
    set => _location = value;
}

    public bool UpgradeToCity(Player player)
    {
        // Implementation code for upgrade to city
        return true;
    }
    public Settlement(Location location, Player owner) {
    _location = location;
    Owner = owner ?? throw new ArgumentNullException(nameof(owner));
}
    public Player Owner { get; private set; }
    public bool TryUpgradeSettlement(Player player) {
    if (!CanUpgradeSettlementResources()) return false; // Ensure resource validation
    // Logic to upgrade settlement to city
    return true; // Indicate success
}
    private bool CanUpgradeSettlementResources() {
    // Implement the logic to check if resources are sufficient for upgrading.
    // For now, returning true as a placeholder.
    return true;
}
}