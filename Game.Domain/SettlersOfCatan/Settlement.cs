namespace Game.Domain;

public class Settlement
{
    public Location Location { get; set; }

    public Settlement(Location location)
    {
        Location = location;
    }
public bool CanUpgradeToCity(Player player) {
    // Check if the player has a settlement at this location
    if (player.HasSettlementAt(this.Location)) {
        // Validate that the player has enough resources to upgrade
        return player.Resources.Wheat >= 2 && player.Resources.Stone >= 3;
    }
    return false;
}
public bool UpgradeToCity(Player player) {
    if (CanUpgradeToCity(player)) {
        player.Resources.Wheat -= 2;
        player.Resources.Stone -= 3;
        return true;
    }
    return false;
} }