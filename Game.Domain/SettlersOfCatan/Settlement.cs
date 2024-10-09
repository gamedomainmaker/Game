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
    public bool IsLocationValid(Location location) {
    // Logic to validate if the location is free
    return true; // Placeholder for validation logic
}
    }
}