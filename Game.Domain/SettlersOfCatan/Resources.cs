public class Resources
{
    public int Wood { get; set; }
    public int Brick { get; set; }
    public int Sheep { get; set; }
    public int Wheat { get; set; }

    public Resources(int wood, int brick, int sheep, int wheat)
    {
        Wood = wood;
        Brick = brick;
        Sheep = sheep;
        Wheat = wheat;
    }
}