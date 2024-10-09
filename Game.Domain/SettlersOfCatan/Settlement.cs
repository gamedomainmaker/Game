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
    public bool UpgradeToCity(Player player) {
        // Your logic to upgrade a settlement to a city
        IsUpgraded = true;
            return true;
    }
    public bool IsLocationValid(Location location) {
    // Logic to validate if the location is free
    return true; // Placeholder for validation logic
}
    public bool BuildSettlement(Player player, int requiredWood, int requiredBrick, int requiredWheat) {
    if (HasSufficientResources(player, requiredWood, requiredBrick)) {
        player.Resources.Wood -= requiredWood;
        player.Resources.Brick -= requiredBrick;
        player.Resources.Wheat -= requiredWheat;
        // Logic to add settlement to player's settlements...
        return true;
    }
    return false;
}
    private bool HasSufficientResources(Player player, int woodRequired, int brickRequired) {
    return player.Resources.Wood >= woodRequired && player.Resources.Brick >= brickRequired;
}
    public bool UpgradeSettlement(Player player) {
            // Your logic to upgrade the settlement
            return true;
    }
    public bool IsUpgraded { get; private set; } = false;
    }
}