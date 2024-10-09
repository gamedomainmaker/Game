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
    public void BuildSettlement(Player player) {
        if(HasSufficientResources(player, 1, 1)) {
            player.Resources.Wood -= 1;
            player.Resources.Brick -= 1;
            // Logic to create a new settlement
        } else {
            throw new InvalidOperationException("Insufficient resources to build settlement.");
        }
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