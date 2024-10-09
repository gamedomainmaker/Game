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
            // Add upgrade checks here (e.g., resource validation)
            if (player.Resources.CanAffordCityUpgrade()) {
                // Perform upgrade
                return true;
            }
            return false; // Indicate that upgrade cannot occur
        }
    }
}