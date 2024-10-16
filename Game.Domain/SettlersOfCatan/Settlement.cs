using Game.Domain;

public class Settlement
{
    private Location? _location;
    public Location Location
{
    get => _location ?? throw new InvalidOperationException("Location is not set.");
    set => _location = value;
}
    public bool UpgradeToCity(Player player) {
    if(!player.CanUpgradeSettlementResources()) {
        return false; // not enough resources
    }
    // Implementation code for upgrade to city
    return true;
}
    public Settlement(Location location, Player owner) {
    _location = location;
    Owner = owner ?? throw new ArgumentNullException(nameof(owner));
}
    public Player Owner { get; private set; }
    public bool TryUpgradeSettlement(Player player) {
    if (!player.CanUpgradeSettlementResources()) return false;
    if (!player.HasSettlementAt(Location)) return false; // Ensure player has a settlement at the location
    return UpgradeToCity(player);
}
    private bool CanUpgradeSettlementResources(Player player) {
    return player.Resources.Wheat >= 2 && player.Resources.Stone >= 1;
}
}