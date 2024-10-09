using System.Collections.Generic;

namespace Game.Domain
{
    public class Settlement
    {
        public Location Location { get; private set; }
        public Settlement(Location location, Player player)
        {
            Location = location;
            player.Settlements.Add(this); // Assumes player.Settlements is writable
        }

        public bool UpgradeToCity(Player player)
        {
            // Upgrade logic implementation
            return true; // Placeholder for successful upgrade
        }
    }
}