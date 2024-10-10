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
    // Logic to incorporate correct resource checks
    if (!player.CanUpgradeSettlementResources()) return false;
    // Existing logic to upgrade settlement to city
    return true; // Indicate upgrade success
}
    private bool CanUpgradeSettlementResources() {
    return Owner.Resources.HasSufficientResources(1, 0, 2, 0, 1);
}
}