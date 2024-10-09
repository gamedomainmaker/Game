namespace Game.Domain;

public class Settlement
{
    public Location Location { get; set; }

    public Settlement(Location location)
    {
        Location = location;
    }

    public bool CanUpgradeToCity(Player player)
    {
        // Check if the player has a settlement at this location
        if (player.HasSettlementAt(this.Location))
        {
            // Validate that the player has enough resources to upgrade
            return player.Resources.Wheat >= 2 && player.Resources.Stone >= 3;
        }
        return false;
    }

    public bool UpgradeToCity(Player player)
    {
        if (CanUpgradeToCity(player))
        {
            player.Resources.Wheat -= 2;
            player.Resources.Stone -= 3;
            return true;
        }
        return false;
    }

    public bool BuildSettlement(Player player)
    {
        // Assuming the method checks for sufficient resources and location availability
        return player.HasResourcesForSettlement() && player.CanPlaceSettlement(Location);
    }
    public bool CanBuildSettlement(Player player, Location location)
{
    return player.Resources.HasResources(ResourceType.Wood, 1) && player.Resources.HasResources(ResourceType.Brick, 1) 
        && !player.HasSettlementAt(location) && Board.IsLocationValid(location);
}
    public bool HasSettlementAt(Location location)
{
    return Settlements.Any(s => s.Location.Equals(location));
}
    public bool IsLocationValid(Location location)
    {
        return Board.IsValidLocation(location);
    }
    public Board Board { get; set; } = new Board();
    public Player Player { get; set; } = new Player();
    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
}