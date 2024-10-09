namespace Game.Domain
{
    public class Settlement
    {
        public Location Location { get; private set; }
        public Settlement(Location location, Player player)
        {
            Location = location;
            player.Settlements.Add(this);
        }
    public bool UpgradeToCity(Player player)
{
    if (player.Resources.CanAffordCityUpgrade()) {
        // Perform upgrade.
        return true;
    }
    return false;
}
    public bool IsLocationValid(Location location)
    {
        // Check if the location is on valid terrain and not near another settlement.
        // For the sake of example, this is a stubbed implementation.
        return true; // Update with actual logic.
    }
    }
}