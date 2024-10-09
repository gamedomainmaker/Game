namespace Game.Domain
{
    public class Resources
    {
        public int Wood { get; set; }
        public int Brick { get; set; }
        public int Wheat { get; set; }
        public int Sheep { get; set; }
        public int Stone { get; set; }

        public Resources(int wood, int brick, int wheat, int sheep, int stone)
        {
            Wood = wood;
            Brick = brick;
            Wheat = wheat;
            Sheep = sheep;
            Stone = stone;
        }

        public bool CanAffordCityUpgrade()
        {
            return Wheat >= 2 && Stone >= 3; // Assuming costs for upgrade
        }
    public bool HasSufficientResources(Player player, int requiredWood, int requiredBrick, int requiredWheat) {
    return player.Resources.Wood >= requiredWood &&
           player.Resources.Brick >= requiredBrick &&
           player.Resources.Wheat >= requiredWheat;
}
    public int Ore { get; set; }
    }
}