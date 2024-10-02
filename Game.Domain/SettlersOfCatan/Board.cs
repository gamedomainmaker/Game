public class Board
{
    public bool TryBuildSettlement(Player player, Location location)
    {
        // Check if the player has sufficient resources
        if (player.Resources.Wood < 1 || player.Resources.Brick < 1 || player.Resources.Wheat < 1 || player.Resources.Sheep < 1)
        {
            return false; // Not enough resources
        }
        // Further validation can be added here based on game rules...

        return true; // Placeholder for successful settlement building
    }
}