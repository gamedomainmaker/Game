namespace Game.Domain;

public enum ResourceType
{
    Wood,
    Brick,
    Wheat,
    Sheep,
    Stone
}

public class Resources
{
    public int Wood { get; set; }
    public int Brick { get; set; }
    public int Wheat { get; set; }
    public int Sheep { get; set; }
    public int Stone { get; set; }
    public Resources(int wheat, int brick, int ore, int stone, int wood)
{
    Wheat = wheat;
    Brick = brick;
    Ore = ore;
    Stone = stone;
    Wood = wood;
}

    public bool HasResources(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                return Wood >= amount;
            case ResourceType.Brick:
                return Brick >= amount;
            case ResourceType.Wheat:
                return Wheat >= amount;
            case ResourceType.Sheep:
                return Sheep >= amount;
            case ResourceType.Stone:
                return Stone >= amount;
            default:
                throw new ArgumentException("Invalid resource type");
        }
    }
    public int Ore { get; set; }
}